using EntAppFrameWork.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.StudentModel.DTO
{


    [Serializable]
    [ProtobufSerializable]
    public  class StudentDTO
    {

        public long StudentId { get; set; }
        public String StudentName { get; set; }

    }
}
