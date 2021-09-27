using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ClassModel.DTO
{




    [Serializable]
    public class ClassStudentRelationshipDTO
    {
        public long classId { get; set; }
        public long studentId { get; set; }
    }

}
