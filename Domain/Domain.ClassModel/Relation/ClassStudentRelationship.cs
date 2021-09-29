using System;
using System.Collections.Generic;
using System.Text;
using Domain.ClassModel.Core;
using Domain.StudentModel.Core;
using EntAppFrameWork.DomainModel.Attribute;
using EntAppFrameWork.DomainModel.Core.Entity;
namespace Domain.ClassModel.Relation
{
    /// <summary>
    /// 班级学生关系
    /// </summary>
    [Serializable]
    [Table(IsAutoCreateTable = true, Name = "GB_ClassStudentRelationship", Key = "ClassStudentRelationshipID", KeyType = typeof(Int64), KeyDbType = "SqlDbType.BigInt", KeySize = 8)]
    public class ClassStudentRelationship : EntityForLongKey
    {
        public ClassStudentRelationship() { }

        public ClassStudentRelationship(Int64 key) : base(key) { }

        [Column(Name = "ClassID", CanBeNull = false, DbType = "SqlDbType.BigInt", Direction = "In", Size = 8)]
        public GClass GClass
        {
            get { return LazyLoad("ClassStudentRelationship_GClass") != null ? LazyLoad("ClassStudentRelationship_GClass") as GClass : null; }
            set { SetLazyLoadValue("ClassStudentRelationship_GClass", value); }
        }

        [Column(Name = "StudentID", CanBeNull = false, DbType = "SqlDbType.BigInt", Direction = "In", Size = 8)]
        public Student Student
        {
            get { return LazyLoad("ClassStudentRelationship_Student") != null ? LazyLoad("ClassStudentRelationship_Student") as Student : null; }
            set { SetLazyLoadValue("ClassStudentRelationship_Student", value); }
        }


    }
}
