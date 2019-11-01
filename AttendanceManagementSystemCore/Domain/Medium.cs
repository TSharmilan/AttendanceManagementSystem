using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystemCore.Domain
{
    [Serializable]
    public class Medium
    {
        [Key]
        public int MediumID { get; set; }

        public string MediumName { get; set; }

        public DateTime EnteredDate { get; set; }
    }
}
