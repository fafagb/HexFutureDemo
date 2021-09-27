using Domain.StudentModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StudentModel.Service.Interface
{
  public  interface IStudent
    {
        Task<bool> CreateStudent(StudentDTO studentDTO);




    }
}
