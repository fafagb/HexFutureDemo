
using Domain.ClassModel.DTO;
using Domain.ClassModel.Relation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Domain.ClassModel.Service.Interface
{
   


    public interface IClassStudentRelationship
    {
        Task<long> SetClassStudentRelationshipAsync(long classId, long studentId);
        Task<IList<ClassStudentRelationship>> SearchClassStudentRelationshipAsync();


       Task<long> CreateClassStudentRelationshipAsync(CreateStudentAndRelationshipDTO createStudentAndRelationshipDTO);


        Task<List<long>> SearchClassStudentRelationshipAsync(List<long> classIds);



        Task<bool> DeleteClassStudentRelationshipAsync(long studentId,long classId);



        Task<bool> DeleteClassStudentRelationshipAsync(long classId);
    }
}
