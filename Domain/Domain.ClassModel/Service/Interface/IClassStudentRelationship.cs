
using Domain.ClassModel.Relation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Domain.ClassModel.Service.Interface
{
   


    public interface IClassStudentRelationship
    {
        Task<long> CreateClassStudentRelationshipAsync(long classId, long studentId);
        Task<IList<ClassStudentRelationship>> SearchClassStudentRelationshipAsync();
    }
}
