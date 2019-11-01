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
    public class AttendanceTable
    {
        [Key, Column(Order = 1)]
        public string StudentNO { get; set; }

        [Key, Column(Order = 2)]
        public int Year { get; set; }

        [Key, Column(Order = 3)]
        public int Month { get; set; }

        [Key, Column(Order = 4)]
        public int Date { get; set; }

        public bool AttendanceMark { get; set; }

        public int Grade { get; set; }

        public int Division { get; set; }
    }
}
