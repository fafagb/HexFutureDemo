using System;
using System.Collections.Generic;
using System.Text;
using EntAppFrameWork.DomainModel.Attribute;
using EntAppFrameWork.DomainModel.Core.Entity;
namespace Domain.StudentModel.Core
{






    [Serializable]
    [Table(IsAutoCreateTable = true, Name = "GB_Student", Key = "StudentID", KeyType = typeof(Int64), KeyDbType = "SqlDbType.BigInt", KeySize = 8)]
    public class Student : EntityForLongKey
    {
        public Student() { }

        public Student(Int64 key) : base(key) { }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [Column(Name = "Name", CanBeNull = false, DbType = "SqlDbType.NVarChar", Direction = "In", Size = 50)]
        public String Name { get; set; }

        /// <summary>
        /// 学生性别
        /// </summary>
        [Column(Name = "Sex", CanBeNull = false, DbType = "SqlDbType.VarChar", Direction = "In", Size = 11)]
        public String Sex { get; set; }

        /// <summary>
        /// 学生学籍号
        /// </summary>
        [Column(Name = "StudentCode", CanBeNull = false, DbType = "SqlDbType.NVarChar", Direction = "In", Size = 256)]
        public String StudentCode { get; set; }

   

    }
}
