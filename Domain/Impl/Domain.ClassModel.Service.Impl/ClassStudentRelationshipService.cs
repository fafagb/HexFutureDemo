using Domain.ClassModel.Core;
using Domain.ClassModel.DTO;
using Domain.ClassModel.Relation;
using Domain.ClassModel.Service.Interface;
using Domain.StudentModel.Core;
using Domain.StudentModel.Service.Interface;
using EntAppFrameWork.DomainModel.Core.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace Domain.ClassModel.Service.Impl
{
    public class ClassStudentRelationshipService : DomainServiceExtBase<ClassStudentRelationship, long>, IClassStudentRelationship
    {
        public async Task<long> SetClassStudentRelationshipAsync(long classId, long studentId)
        {
            long relationshipId = 0;
            try
            {


                var entity = await this.Where(entity => entity.Student.Key == studentId).Top(1).FindTopAsync();

                if (entity.Count > 0)
                {
                    var modifyModel = entity[0];
                    modifyModel.GClass = new GClass(classId);

                    bool result = await this.SaveAsync(modifyModel);
                    if (result)
                        relationshipId = modifyModel.Key;
                }
                else
                {
                    ClassStudentRelationship relationship = new ClassStudentRelationship();
                    relationship.Student = new Student(studentId);
                    relationship.GClass = new GClass(classId);
                    bool result = await this.SaveAsync(relationship);
                    if (result)
                        relationshipId = relationship.Key;
                }


            }
            catch (Exception ex)
            {
                LogErrorAsync($"班级学生异常信息{ex.Message.ToString()}");
            }
            return relationshipId;
        }


        public async Task<long> CreateClassStudentRelationshipAsync(CreateStudentAndRelationshipDTO createStudentAndRelationshipDTO)
        {
            long relationshipId = 0;
            try
            {

                await TranAndSCExecuterAsync(async () =>
                {
                    long studentId = await this.InvokeService<IStudent>().CreateStudent(createStudentAndRelationshipDTO);
                    if (studentId == 0) return;
                    relationshipId = await this.InvokeService<IClassStudentRelationship>().SetClassStudentRelationshipAsync(createStudentAndRelationshipDTO.ClassId, studentId);


                    //ClassStudentRelationship relationship = new ClassStudentRelationship();
                    //relationship.Student = new Student(studentId);
                    //relationship.GClass = new GClass(createStudentAndRelationshipDTO.ClassId);
                    //bool result = await this.SaveAsync(relationship);
                    //if (result)
                    //    relationshipId = relationship.Key;
                });

            }
            catch (Exception ex)
            {
                LogErrorAsync($"班级学生异常信息{ex.Message.ToString()}");
            }
            return relationshipId;
        }







        public async Task<IList<ClassStudentRelationship>> SearchClassStudentRelationshipAsync()
        {
            IList<ClassStudentRelationship> relationship = new List<ClassStudentRelationship>();
            try
            {
                relationship = await
                            Select("ClassStudentRelationshipID", "Student.Name", "Class.Name")
                           .Start(1)
                           .Rows(10)
                          .SearchNPAsync();
            }
            catch (Exception ex)
            {
                LogErrorAsync($"异常信息{ex.Message.ToString()}");
            }
            return relationship;
        }




        public async Task<List<long>> SearchClassStudentRelationshipAsync(List<long> classIds)
        {
            var list = await Where(x => classIds.Equals(x.GClass.Key)).SearchNPAsync();
            return list.Select(x => x.Student.Key).ToList();

        }
    }
}
