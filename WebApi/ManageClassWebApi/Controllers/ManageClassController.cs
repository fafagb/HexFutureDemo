using WebApiCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

using System.Collections.Generic;
using Domain.ClassModel.DTO;
using Domain.ClassModel.Service.Interface;
using ManageClassWebApi.Model;
using Domain.ClassModel.Core;
using Domain.ClassModel.Service;
using Domain.ClassModel.Relation;

namespace ManageClassWebApi.Controllers
{
    [AllowAnonymous]
    public class ManageClassController : ApiBaseController
    {
        #region 管理班级
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public async Task<bool> CreateClassAsync([FromBody]ClassDTO classDTO)
        {
            return await this.InvokeService<IClass>().CreateClassAsync(classDTO);
        }

        /// <summary>
        /// 获取班级列表
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<RepClass>> SearchClasssAsync(long id,string ClassName)
        {
            IList<RepClass> repClasss = new List<RepClass>();
            IList<GClass> list = await this.InvokeService<IClass>().SearchClassesAsync(id, ClassName);
            foreach (var item in list)
            {
                repClasss.Add(new RepClass
                {
                    ClassName = item.Name,
                    categoryName = item.ClassCategory.Name
                });
            }
            return repClasss;
        }
        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="classDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> DeleteClassAsync([FromBody] ClassDTO classDTO)
        {
            if (classDTO.ClassId == 0)
                return false;
            return await this.InvokeService<IClass>().DeleteClassAsync(classDTO.ClassId);
        }
        /// <summary>
        /// 修改班级名称
        /// </summary>
        /// <param name="ClassId"></param>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> UpdateClassNameAsync([FromBody]ClassDTO ClassDTO)
        {
            if (string.IsNullOrWhiteSpace(ClassDTO.ClassName) || ClassDTO.ClassId == 0)
                return false;
            return await this.InvokeService<IClass>().UpdateClassNameAsync(ClassDTO.ClassId, ClassDTO.ClassName);
        }
        #endregion

        #region 年级
        /// <summary>
        /// 新建年级
        /// </summary>
        /// <param name="categoryNameStr"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<long> CreateClassCategoryAsync(string categoryName)
        {
            return await this.InvokeService<IClassCategory>().CreateClassCategoryAsync(categoryName);
        }
        /// <summary>
        /// 获取年级列表
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<ClassCategoryDTO>> SearchClassCategoryAsync(string categoryName)
        {
            IList<ClassCategoryDTO> repClassCategories = new List<ClassCategoryDTO>();
            IList<ClassCategory> list = await this.InvokeService<IClassCategory>().SearchClassCategoriesAsync(categoryName);
            foreach (var item in list)
            {
                repClassCategories.Add(new ClassCategoryDTO()
                {
                    ClassCategoryId = item.Key,
                    ClassCategoryName = item.Name
                });
            }
            return repClassCategories;
        }
        /// <summary>
        /// 修改年级分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> UpdateClassCategotyNameAsync([FromBody] ClassCategoryDTO classCategoryDTO)
        {
            if (classCategoryDTO.ClassCategoryId == 0 || string.IsNullOrWhiteSpace(classCategoryDTO.ClassCategoryName))
                return false;
            return await this.InvokeService<IClassCategory>().UpdateClassCategotyNameAsync(classCategoryDTO.ClassCategoryId, classCategoryDTO.ClassCategoryName);
        }

        /// <summary>
        /// 保存年级到redis
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<bool> SaveClassCategoriesToRedisAsync()
        {
            IList<ClassCategoryDTO> repClassCategories = await SearchClassCategoryAsync("");
            bool res = await this.InvokeService<IClassCategory>().SaveClassCategoryToRedisAsync(repClassCategories);
            return res;
        }

        /// <summary>
        /// 从redis查询年级
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<ClassCategoryDTO>> SearchClassCategoryFromRedisAsync()
        {
            IList<ClassCategoryDTO> list = await this.InvokeService<IClassCategory>().SearchClassCategoryFromRedisAsync();
            return list;
        }

        #endregion

        #region 班级学生关系

        /// <summary>
        /// 阅读记录
        /// </summary>
        /// <param name="readRecordDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<long> CreateUserReadRecordAsync([FromBody] ClassStudentRelationshipDTO classStudentRelationshipDTO)
        {
            return await this.InvokeService<IClassStudentRelationship>().CreateClassStudentRelationshipAsync(classStudentRelationshipDTO.classId, classStudentRelationshipDTO.studentId);
        }
        /// <summary>
        /// 获取班级学生关系
        /// </summary>
        /// <param name="readRecordDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<RepClassStudentRelationship>> SearchUserReadRecordAsync()
        {
            IList<RepClassStudentRelationship> repRelationship = new List<RepClassStudentRelationship>();
            IList<ClassStudentRelationship> list = await this.InvokeService<IClassStudentRelationship>().SearchClassStudentRelationshipAsync();
            foreach (var item in list)
            {
                repRelationship.Add(new RepClassStudentRelationship
                {
                    StudentName = item.Student.Name,
                  
                    ClassName = item.GClass.Name
                });
            }
            return repRelationship;
        }
        #endregion
    }
}
