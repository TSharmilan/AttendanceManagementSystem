using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystemCore.Domain
{
    [Serializable]
    public class Student 
    {
        [Key]
        public int StudentID { get; set; }

        public string School { get; set; }

        public string IndexNo { get; set; }

        public string Gender { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public int  GradeID { get; set; }
        [ForeignKey("GradeID")]
        public Grade Grade { get; set; }

        public int DivisionID { get; set; }
        [ForeignKey("DivisionID")]
        public Division Division { get; set; }

        public int Medium { get; set; }

        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public string Address1 { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public DateTime EnteredDate { get; set; }
    }
}