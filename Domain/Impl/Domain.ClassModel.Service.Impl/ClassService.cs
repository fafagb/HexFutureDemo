﻿using Domain.ClassModel.Core;
using Domain.ClassModel.DTO;
using Domain.ClassModel.Service.Interface;
using Domain.StudentModel.Service.Interface;
using EntAppFrameWork.DomainModel.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Domain.StudentModel.Core;

namespace Domain.ClassModel.Service.Impl
{


    //  1、单表保存
    //（1）核心模型； 添加、修改班级（每个年级下班级名称不能重复）
    //（2）关联模型：学生调班


    public class ClassService : DomainServiceExtBase<GClass, long>, IClass
    {
        public async Task<bool> CreateClassAsync(string className, string grade)
        {

            bool res = false;
            try
            {
                await this.TranAndSCExecuterAsync(async () =>
                {
                    long gradeId = await this.InvokeService<IGrade>().CreateGradeAsync(grade);
                    // 每个年级下班级名称不能重复


                    var entity = await this.Where(entity => entity.Name == className && entity.Grade.Key == gradeId).Top(1).FindTopAsync();

                    if (entity.Count > 0) return;


                    GClass cla = new GClass();
                    cla.Grade = new Grade(gradeId);
                    cla.Name = className;



                    bool saveClassResult = await this.SaveAsync(cla);

                    res = gradeId > 0 && saveClassResult;
                });
            }
            catch (Exception ex)
            {
                LogErrorAsync($"添加班级异常信息{ex.Message.ToString()}");
            }
            return res;


        }


        // 5、单表删除
        //（1）学生移除班级

        public async Task<bool> DeleteClassAsync(long classId)
        {
            bool res = false;
            try
            {
                res = await RemoveAsync(new GClass(classId));
            }
            catch (Exception ex)
            {
                LogErrorAsync($"删除班级异常信息{ex.Message.ToString()}");
            }
            return res;
        }


        //3、单表查询  多条件查询：①年级、②班级名称模糊（可为空）
        //（1）查询某年级下班级列表
        public async Task<IList<GClass>> SearchClassesAsync(long gradeId, string className)
        {
            IList<GClass> list = new List<GClass>();
            try
            {

                //   list = await Where(x => x.Grade.Key == gradeId && x.Name.Contains(className)).SearchNPAsync();
                list = await Where(x => x.Grade.Key == gradeId).Where(
                     Like<GClass>(m => m.Name.Contains(className), true))
                     .SearchNPAsync();




            }
            catch (Exception ex)
            {
                LogErrorAsync($"获取班级异常信息{ex.Message.ToString()}");
            }
            return list;
        }

        public async Task<bool> UpdateClassNameAsync(long classId, string className)
        {
            bool res = false;
            try
            {
                GClass cla = await GetByKeyAsync(classId);
                cla.Name = className;
                res = await this.SaveAsync(cla);
            }
            catch (Exception ex)
            {
                LogErrorAsync($"修改班级异常信息{ex.Message.ToString()}");
            }
            return res;
        }



        public async Task<IList<Student>> SelectStudentByMulCons(long gradeId, string className, string studentName)
        {


            var list = await SearchClassesAsync(gradeId, className);
            var classIds = list.Select(x => x.Key).ToList();
            var students = await this.InvokeService<IClassStudentRelationship>().SearchClassStudentRelationshipAsync(classIds);

            return await this.InvokeService<IStudent>().SelectStudent(students);


        }



    }
}
