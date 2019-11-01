using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystemCore.Domain
{
    [Serializable]
    public class Division
    {
        [Key]
        public int DivisionID { get; set; }

        public string DivisionName { get; set; }

        public DateTime EnteredDate { get; set; }
    }
}
