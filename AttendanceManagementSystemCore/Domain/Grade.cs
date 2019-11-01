using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystemCore.Domain
{
    [Serializable]
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }

        public string GradeName { get; set; }

        public DateTime EnteredDate { get; set; }
    }
}
