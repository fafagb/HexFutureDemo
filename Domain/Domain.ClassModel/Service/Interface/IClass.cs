using Domain.ClassModel.Core;
using Domain.ClassModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ClassModel.Service.Interface
{
    public interface IClass
    {

        Task<bool> CreateClassAsync(ClassDTO classDTO);
        Task<IList<GClass>> SearchClassesAsync(long id, string className);
        Task<bool> DeleteClassAsync(long classId);
        Task<bool> UpdateClassNameAsync(long classId, string className);


    }
}
