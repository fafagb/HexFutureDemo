using Domain.StudentModel.DTO;
using EntAppFrameWork.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ClassModel.DTO
{




    [Serializable]
    [ProtobufSerializable]
    public class ClassStudentRelationshipDTO
    {
        public long ClassId { get; set; }
        public long StudentId { get; set; }
    }




    [Serializable]
    [ProtobufSerializable]
    public class CreateStudentAndRelationshipDTO : StudentDTO
    {
        public long ClassId { get; set; }
    }

}
