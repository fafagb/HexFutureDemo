using Domain.StudentModel.Core;
using Domain.StudentModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StudentModel.Service.Interface
{
  public  interface IStudent
    {
        Task<long> CreateStudent(StudentDTO studentDTO);


        /// <summary>
        /// 根据班级Id查询学生
        /// </summary>
        /// <param name="classIds"></param>
        /// <returns></returns>
        Task<IList<Student>> SelectStudent(List<long> students,string studentName);



    }
}
