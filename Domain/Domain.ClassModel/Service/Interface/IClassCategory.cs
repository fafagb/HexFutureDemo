using Domain.ClassModel.Core;
using Domain.ClassModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Domain.ClassModel.Service.Interface
{
    public interface IClassCategory
    {
        Task<long> CreateClassCategoryAsync(string classCategoryName);
        Task<IList<ClassCategory>> SearchClassCategoriesAsync(string categoryName);

        Task<bool> SaveClassCategoryToRedisAsync(IList<ClassCategoryDTO> classCategories);
        Task<IList<ClassCategoryDTO>> SearchClassCategoryFromRedisAsync();
        Task<bool> UpdateClassCategotyNameAsync(long categoryId, string categoryName);
    }
}
