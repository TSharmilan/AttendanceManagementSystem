using AttendanceManagementSystemCore.Domain;
using AttendanceManagementSystemCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystemCore.DAL
{
    public class AttendanceTableDAL
    {
        public void SaveAttendance(AttendanceTable attendanceTable, AttendanceContext attendanceContext)
        {
            try
            {
                attendanceContext.AttendanceTables.Add(attendanceTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AttendanceTable> Studentfromdivisionandgrade(int division, int grade, AttendanceContext attendanceContext)
        {
            try
            {
                return attendanceContext.AttendanceTables.Where(a => a.Division == division && a.Grade == grade).ToList();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
