using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.StudentModel.Core;
using Domain.StudentModel.DTO;
using Domain.StudentModel.Service.Interface;
using EntAppFrameWork.DomainModel.Core.Service;
namespace Domain.StudentModel.Service.Impl
{
    public class StudentService : DomainServiceExtBase<Student, long>, IStudent
    {
        public async Task<long> CreateStudent(StudentDTO studentDTO)
        {
            long studentId = 0;
            try
            {

                var entity = await this.Where(entity => entity.Name == studentDTO.StudentCode).Top(1).FindTopAsync();
                if (entity.Count > 0) return studentId;

                Student student = new Student();

                student.Name = studentDTO.StudentName;
                student.Sex = studentDTO.Sex;
                student.StudentCode = studentDTO.StudentCode;
                bool saveClassResult = await this.SaveAsync(student);

                studentId = student.Key;


            }
            catch (Exception ex)
            {
                LogErrorAsync($"添加学生异常信息{ex.Message.ToString()}");
            }
            return studentId;
        }

        public async Task<IList<Student>> SelectStudent(List<long> students)
        {
           return await Where(x => students.Equals(x.Key)).SearchNPAsync();
            
            
                    
        }




    }
}
