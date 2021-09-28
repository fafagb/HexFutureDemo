using System;
using EntAppFrameWork.DomainModel.Attribute;
using EntAppFrameWork.DomainModel.Core.Entity;

namespace Domain.ClassModel.Core
{




    [Serializable]
    [Table(IsAutoCreateTable = true, Name = "GB_Grade", Key = "GradeID", KeyType = typeof(Int64), KeyDbType = "SqlDbType.BigInt", KeySize = 8)]
    public class Grade : EntityForLongKey
    {
        public Grade() { }

        public Grade(Int64 key) : base(key) { }

        [Column(Name = "Name", CanBeNull = false, DbType = "SqlDbType.NVarChar", Direction = "In", Size = 50)]
        public String Name { get; set; }
    }
}
