using System;
using EntAppFrameWork.DomainModel.Attribute;
using EntAppFrameWork.DomainModel.Core.Entity;
namespace Domain.ClassModel.Core
{

    [Serializable]
    [Table(IsAutoCreateTable = true, Name = "GB_Class", Key = "ClassID", KeyType = typeof(Int64), KeyDbType = "SqlDbType.BigInt", KeySize = 8)]
    public class GClass : EntityForLongKey
    {
        public GClass() { }

        public GClass(Int64 key) : base(key) { }

        /// <summary>
        /// 班级名称
        /// </summary>
        [Column(Name = "Name", CanBeNull = false, DbType = "SqlDbType.NVarChar", Direction = "In", Size = 50)]
        public String Name { get; set; }

        /// <summary>
        /// 所属年级
        /// </summary>
        [Column(Name = "ClassCategoryID", CanBeNull = true, DbType = "SqlDbType.BigInt", Direction = "In", Size = 8)]
        public ClassCategory ClassCategory
        {
            get { return LazyLoad("Class_ClassCategory") != null ? LazyLoad("Class_ClassCategory") as ClassCategory : null; }
            set { SetLazyLoadValue("Class_ClassCategory", value); }
        }
    }
}
