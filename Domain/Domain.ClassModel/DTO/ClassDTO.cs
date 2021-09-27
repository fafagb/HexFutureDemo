using System;
using System.Collections.Generic;
using System.Text;
using EntAppFrameWork.Common.Serialization;
namespace Domain.ClassModel.DTO
{
   


    [Serializable]
    [ProtobufSerializable]
    public class ClassDTO
    {
        public long ClassId { get; set; }
        public String ClassName { get; set; }

        /// <summary>
        /// 年级名称
        /// </summary>
        public string ClassCategoryName { get; set; }

    }
    [Serializable]
    [ProtobufSerializable]
    public class ClassCategoryDTO
    {
        /// <summary>
        /// 年级Id
        /// </summary>
        public long ClassCategoryId { get; set; }

        /// <summary>
        /// 年级名称
        /// </summary>
        public string ClassCategoryName { get; set; }
    }


}
