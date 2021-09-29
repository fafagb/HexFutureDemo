using WebApiCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

using System.Collections.Generic;
using Domain.ClassModel.DTO;
using Domain.ClassModel.Service.Interface;
using ManageClassWebApi.Model;
using Domain.ClassModel.Core;
using Domain.ClassModel.Service;
using Domain.ClassModel.Relation;
using Domain.StudentModel.DTO;
using Domain.StudentModel.Service.Interface;

namespace ManageClassWebApi.Controllers
{
    [AllowAnonymous]
    public class ManageClassController : ApiBaseController
    {
        #region 管理班级
        
        /// <summary>
        /// 创建班级
        /// </summary>
        /// <param name="classDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> CreateClassAsync([FromBody]ClassDTO classDTO)
        {
            return await this.InvokeService<IClass>().CreateClassAsync(classDTO.ClassName, classDTO.GradeName);


        }

        /// <summary>
        /// 获取班级列表
        /// </summary>
        /// <param name="gradeName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<RepClass>> SearchClassesAsync(long gradeId, string className)
        {
            IList<RepClass> repClasss = new List<RepClass>();
            IList<GClass> list = await this.InvokeService<IClass>().SearchClassesAsync(gradeId, className);
            foreach (var item in list)
            {
                repClasss.Add(new RepClass
                {
                    ClassName = item.Name,
                    gradeName = item.Grade.Name
                });
            }
            return repClasss;
        }
        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="classDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<bool> DeleteClassAsync(long classId)
        {
            if (classId == 0)
                return false;
            return await this.InvokeService<IClass>().DeleteClassAsync(classId);
        }
        /// <summary>
        /// 修改班级名称
        /// </summary>
        /// <param name="ClassDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> UpdateClassNameAsync([FromBody]ClassDTO classDTO)
        {
            if (string.IsNullOrWhiteSpace(classDTO.ClassName) || classDTO.ClassId == 0)
                return false;
            return await this.InvokeService<IClass>().UpdateClassNameAsync(classDTO.ClassId, classDTO.ClassName);
        }

        /// <summary>
        /// 获取学生列表
        /// </summary>
        /// <param name="classDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<RepStudent>> GetStudentListByMulCons(long gradeId, string className,string studentName)
        {
            if (gradeId == 0)
                return null;
            var list = await this.InvokeService<IClass>().SelectStudentByMulCons(gradeId, className, studentName);
            IList<RepStudent> students = new List<RepStudent>();
            foreach (var item in list)
            {
                students.Add(new RepStudent()
                {
                  
                    StudentName = item.Name,
                     Sex= item.Sex,
                      StudentCode = item.StudentCode
                });
            }
            return students;

        }




        #endregion


        #region 学生
        /// <summary>
        /// 创建学生
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<long> CreateStudentAsync([FromBody]StudentDTO studentDTO)
        {
            return await this.InvokeService<IStudent>().CreateStudent(studentDTO);
        }



        #endregion


        #region 年级
        /// <summary>
        /// 新建年级
        /// </summary>
        /// <param name="gradeNameStr"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<long> CreateGradeAsync(string gradeName)
        {
            return await this.InvokeService<IGrade>().CreateGradeAsync(gradeName);
        }
        /// <summary>
        /// 获取年级列表
        /// </summary>
        /// <param name="gradeName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<GradeDTO>> SearchGradeAsync(string gradeName)
        {
            IList<GradeDTO> repClassCategories = new List<GradeDTO>();
            IList<Grade> list = await this.InvokeService<IGrade>().SearchClassCategoriesAsync(gradeName);
            foreach (var item in list)
            {
                repClassCategories.Add(new GradeDTO()
                {
                    GradeId = item.Key,
                    GradeName = item.Name
                });
            }
            return repClassCategories;
        }
        /// <summary>
        /// 修改年级分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> UpdateGradeNameAsync([FromBody] GradeDTO GradeDTO)
        {
            if (GradeDTO.GradeId == 0 || string.IsNullOrWhiteSpace(GradeDTO.GradeName))
                return false;
            return await this.InvokeService<IGrade>().UpdateGradeNameAsync(GradeDTO.GradeId, GradeDTO.GradeName);
        }

        /// <summary>
        /// 保存年级到redis
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<bool> SaveGradeToRedisAsync()
        {
            IList<GradeDTO> repGrade = await SearchGradeAsync("");
            bool res = await this.InvokeService<IGrade>().SaveGradeToRedisAsync(repGrade);
            return res;
        }

        /// <summary>
        /// 从redis查询年级
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<GradeDTO>> SearchGradeFromRedisAsync()
        {
            IList<GradeDTO> list = await this.InvokeService<IGrade>().SearchGradeFromRedisAsync();
            return list;
        }



        /// <summary>
        /// 从redis删除年级
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<bool> DeleteGradeFromRedisAsync()
        {
             await this.InvokeService<IGrade>().DeleteGradeFromRedisAsync();
            return true;
        }




        #endregion

        #region 班级学生关系


        /// <summary>
        /// 设置学生及关系
        /// </summary>
        /// <param name="classStudentRelationshipDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<long> SetClassStudentRelationshipAsync([FromBody] ClassStudentRelationshipDTO classStudentRelationshipDTO)
        {
            return await this.InvokeService<IClassStudentRelationship>().SetClassStudentRelationshipAsync(classStudentRelationshipDTO.ClassId, classStudentRelationshipDTO.StudentId);
        }



        /// <summary>
        /// 创建学生并设置班级
        /// </summary>
        /// <param name="classStudentRelationshipDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<long> CreateClassStudentRelationshipAsync([FromBody] CreateStudentAndRelationshipDTO createStudentAndRelationshipDTO)
        {
            return await this.InvokeService<IClassStudentRelationship>().CreateClassStudentRelationshipAsync(createStudentAndRelationshipDTO);
        }




     
        /// <summary>
        /// 获取班级学生关系
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<RepClassStudentRelationship>> SearchClassStudentRelationshipAsync()
        {
            IList<RepClassStudentRelationship> repRelationship = new List<RepClassStudentRelationship>();
            IList<ClassStudentRelationship> list = await this.InvokeService<IClassStudentRelationship>().SearchClassStudentRelationshipAsync();
            foreach (var item in list)
            {
                repRelationship.Add(new RepClassStudentRelationship
                {
                    StudentName = item.Student.Name,

                    ClassName = item.GClass.Name
                });
            }
            return repRelationship;
        }

        [HttpGet]
        public async Task<bool> DeleteClassStudentRelationshipAsync(long studentId, long classId)
        {

            return await this.InvokeService<IClassStudentRelationship>().DeleteClassStudentRelationshipAsync(studentId, classId);
        }


     


        #endregion
    }
}
