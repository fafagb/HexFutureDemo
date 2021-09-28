using Domain.ClassModel.Core;
using Domain.ClassModel.DTO;
using Domain.StudentModel.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ClassModel.Service.Interface
{
    public interface IClass
    {

        Task<bool> CreateClassAsync(string className, string grade);


        Task<IList<GClass>> SearchClassesAsync(long gradeId, string className);


        Task<IList<Student>> SelectStudentByMulCons(long gradeId, string className, string studentName);


        Task<bool> DeleteClassAsync(long classId);
        Task<bool> UpdateClassNameAsync(long classId, string className);


    }
}
