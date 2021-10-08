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
    public class GradeService : DomainServiceExtBase<Grade, long>, IGrade
    {
        public async Task<long> CreateGradeAsync(string gradeName)
        {
            long gradeId = 0;
            try
            {
                //查询年级是否存在
                var entity = await this.Where(entity => entity.Name == gradeName).Top(10).FindTopAsync();
                //存在返回年级Id
                if (entity.Count > 0)
                    gradeId = entity[0].Key;
                //不存在新建年级
                else
                {
                    Grade grade = new Grade();
                    grade.Name = gradeName;
                    bool result = await this.SaveAsync(grade);
                    if (result)
                        gradeId = grade.Key;
                }
            }
            catch (Exception ex)
            {
                LogErrorAsync($"创建年级异常信息{ex.Message}");
            }
            return gradeId;
        }

        public async Task<bool> SaveGradeToRedisAsync(IList<GradeDTO> grades)
        {
            bool res = false;
            string redisKey = "Grade";
            try
            {
                res = await this.ExecRedisAsync("DomainCacheDBPool", async rc =>
                     await rc.SetAsync(redisKey, JsonConvert.SerializeObject(grades))
                );
            }
            catch (Exception ex)
            {
                LogErrorAsync($"保存年级到redis异常信息{ex.Message}");
            }
            return res;
        }

        public async Task<IList<Grade>> SearchGradesAsync(string gradeName)
        {
            IList<Grade> grades = new List<Grade>();
            try
            {
                grades = await Where(
                       GreaterEqualThan("Name", gradeName))
                      .Start(1)
                      .Rows(20)
                      .SearchNPAsync();
            }
            catch (Exception ex)
            {
                LogErrorAsync($"获取年级异常信息{ex.Message}");
            }
            return grades;
        }

        public async Task<IList<GradeDTO>> SearchGradeFromRedisAsync()
        {
            IList<GradeDTO> list = new List<GradeDTO>();
            string redisKey = "Grade";
            try
            {
                string str = await this.ExecRedisAsync("DomainCacheDBPool", async rc =>
                     await rc.GetAsync<string>(redisKey)
                );

                list = JsonConvert.DeserializeObject<IList<GradeDTO>>(str);
            }
            catch (Exception ex)
            {
                LogErrorAsync($"从redis获取年级异常信息{ex.Message}");
            }
            return list;
        }
        public async Task<bool> DeleteGradeFromRedisAsync()
        {
            bool res=false;
            string redisKey = "Grade";
            try
            {
                res = await this.ExecRedisAsync("DomainCacheDBPool", async rc =>
                     await rc.RemoveAsync(redisKey)
                );
            }
            catch (Exception ex)
            {
                LogErrorAsync($"从redis删除年级异常信息{ex.Message}");
            }
            return res;
        }

      


        





        public async Task<bool> UpdateGradeNameAsync(long gradeId, string gradeName)
        {
            bool res = false;
            try
            {
                Grade Grade = await GetSnapByKeyAsync(gradeId);
                Grade.Name = gradeName;
                res = await this.SaveAsync(Grade);
            }
            catch (Exception ex)
            {
                LogErrorAsync($"修改年级异常信息{ex.Message}");
            }
            return res;
        }
    }
}
