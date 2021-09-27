using Domain.ClassModel.Core;
using Domain.ClassModel.DTO;
using Domain.ClassModel.Service.Interface;
using EntAppFrameWork.DomainModel.Core.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ClassModel.Service.Impl
{
    public class ClassCategoryService : DomainServiceExtBase<ClassCategory, long>, IClassCategory
    {
        public async Task<long> CreateClassCategoryAsync(string classCategoryName)
        {
            long categoryId = 0;
            try
            {
                //查询年级是否存在
                var ebookCategory = await this.Where(entity => entity.Name == classCategoryName).Top(10).FindTopAsync();
                //存在返回年级Id
                if (ebookCategory.Count > 0)
                    categoryId = ebookCategory[0].Key;
                //不存在新建年级
                else
                {
                    ClassCategory category = new ClassCategory();
                    category.Name = classCategoryName;
                    bool result = await this.SaveAsync(category);
                    if (result)
                        categoryId = category.Key;
                }
            }
            catch (Exception ex)
            {
                LogErrorAsync($"创建年级异常信息{ex.Message}");
            }
            return categoryId;
        }

        public async Task<bool> SaveClassCategoryToRedisAsync(IList<ClassCategoryDTO> classCategories)
        {
            bool res = false;
            string redisKey = "ClassCategory";
            try
            {
                res = await this.ExecRedisAsync("DomainCacheDBPool", async rc =>
                     await rc.SetAsync(redisKey, JsonConvert.SerializeObject(classCategories))
                );
            }
            catch (Exception ex)
            {
                LogErrorAsync($"保存年级到redis异常信息{ex.Message}");
            }
            return res;
        }

        public async Task<IList<ClassCategory>> SearchClassCategoriesAsync(string categoryName)
        {
            IList<ClassCategory> classCategories = new List<ClassCategory>();
            try
            {
                classCategories = await Where(
                       GreaterEqualThan("Name", categoryName))
                      .Start(1)
                      .Rows(20)
                      .SearchNPAsync();
            }
            catch (Exception ex)
            {
                LogErrorAsync($"获取年级异常信息{ex.Message}");
            }
            return classCategories;
        }

        public async Task<IList<ClassCategoryDTO>> SearchClassCategoryFromRedisAsync()
        {
            IList<ClassCategoryDTO> list = new List<ClassCategoryDTO>();
            string redisKey = "ClassCategory";
            try
            {
                list = await this.ExecRedisAsync("DomainCacheDBPool", async rc =>
                     await rc.GetAsync<IList<ClassCategoryDTO>>(redisKey)
                );
            }
            catch (Exception ex)
            {
                LogErrorAsync($"从redis获取年级异常信息{ex.Message}");
            }
            return list;
        }

        public async Task<bool> UpdateClassCategotyNameAsync(long categoryId, string categoryName)
        {
            bool res = false;
            try
            {
                ClassCategory classCategory = await GetSnapByKeyAsync(categoryId);
                classCategory.Name = categoryName;
                res = await this.SaveAsync(classCategory);
            }
            catch (Exception ex)
            {
                LogErrorAsync($"修改电子书分类名称异常信息{ex.Message}");
            }
            return res;
        }
    }
}
