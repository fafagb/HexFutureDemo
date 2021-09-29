using Domain.ClassModel.Core;
using Domain.ClassModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Domain.ClassModel.Service.Interface
{
    public interface IGrade
    {
        Task<long> CreateGradeAsync(string gradeName);
        Task<IList<Grade>> SearchClassCategoriesAsync(string gradeName);

        Task<bool> SaveGradeToRedisAsync(IList<GradeDTO> grades);
        Task<IList<GradeDTO>> SearchGradeFromRedisAsync();
        Task<bool> UpdateGradeNameAsync(long gradeId, string gradeName);


        Task<bool> DeleteGradeFromRedisAsync();



        
    }
}
