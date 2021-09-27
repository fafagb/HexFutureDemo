using System;
using System.Threading.Tasks;
using Domain.StudentModel.Core;
using Domain.StudentModel.DTO;
using Domain.StudentModel.Service.Interface;
using EntAppFrameWork.DomainModel.Core.Service;
namespace Domain.StudentModel.Service.Impl
{
    public class StudentService : DomainServiceExtBase<Student, long>, IStudent
    {
        public async Task<bool> CreateStudent(StudentDTO studentDTO)
        {
            bool res = false;
            try
            {
                await this.TranAndSCExecuterAsync(async () =>
                {
                    

                    Student student = new Student();

                    student.Name = studentDTO.StudentName;
                    bool saveClassResult = await this.SaveAsync(student);

                    res = saveClassResult;
                });
            }
            catch (Exception ex)
            {
                LogErrorAsync($"添加班级异常信息{ex.Message.ToString()}");
            }
            return res;
        }
    }
}
