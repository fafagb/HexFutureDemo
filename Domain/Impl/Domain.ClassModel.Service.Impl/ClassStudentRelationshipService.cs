using Domain.ClassModel.Core;
using Domain.ClassModel.Relation;
using Domain.ClassModel.Service.Interface;
using Domain.StudentModel.Core;
using EntAppFrameWork.DomainModel.Core.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.ClassModel.Service.Impl
{
    public class ClassStudentRelationshipService : DomainServiceExtBase<ClassStudentRelationship, long>, IClassStudentRelationship
    {
        public async Task<long> CreateClassStudentRelationshipAsync(long classId, long studentId)
        {
            long relationshipId = 0;
            try
            {
                ClassStudentRelationship relationship = new ClassStudentRelationship();
                relationship.Student = new Student(studentId);
                relationship.GClass = new GClass(classId);
                bool result = await this.SaveAsync(relationship);
                if (result)
                    relationshipId = relationship.Key;
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
    }
}
