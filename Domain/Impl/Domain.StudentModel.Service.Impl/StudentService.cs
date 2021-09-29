using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.StudentModel.Core;
using Domain.StudentModel.DTO;
using Domain.StudentModel.Service.Interface;
using EntAppFrameWork.DomainModel.Core.Service;
using EntAppFrameWork.DomainModel.Core.Specification;

namespace Domain.StudentModel.Service.Impl
{
    public class StudentService : DomainServiceExtBase<Student, long>, IStudent
    {
        public async Task<long> CreateStudent(StudentDTO studentDTO)
        {
            long studentId = 0;
            try
            {
                string code = studentDTO.StudentCode;
                var entity = await this.Where(entity => entity.StudentCode == code).Top(1).FindTopAsync();
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

        public async Task<IList<Student>> SelectStudent(List<long> students, string studentName)
        {
            IList<ISpecification> specList = new List<ISpecification>();
            specList.Add(SpecIn<Student>(c => c.Key, students.ToArray()));
            if (!string.IsNullOrEmpty(studentName))
            {
                specList.Add(Equal<Student>(x => x.Name == studentName));
            }
            var list = await this.Where<Student, long>(And<Student>(specList)).SearchNPAsync();
            return list;

        }




    }
}
