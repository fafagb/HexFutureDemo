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

        public String StudentName { get; set; }


        public String Sex { get; set; }

        public String StudentCode { get; set; }


  

    }

  




}
