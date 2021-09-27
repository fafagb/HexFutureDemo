using System;
using System.Collections.Generic;
using System.Text;

namespace ManageClassWebApi.Model
{
    /// <summary>
    /// 年级模型
    /// </summary>
    public class RepClassCategory
    {
        /// <summary>
        /// 年级ID
        /// </summary>
        public long categoryId { get; set; }
        /// <summary>
        /// 年级名称
        /// </summary>
        public String categoryName { get; set; }
    }
    /// <summary>
    /// 班级模型
    /// </summary>
    public class RepClass
    {
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 年级名称
        /// </summary>
        public String categoryName { get; set; }
    }
    /// <summary>
    /// 班级学生关系
    /// </summary>
    public class RepClassStudentRelationship
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 电子书名称
        /// </summary>
        public string ClassName { get; set; }
 
    }
}
