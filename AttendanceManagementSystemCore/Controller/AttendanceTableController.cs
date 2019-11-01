using AttendanceManagementSystemCore.DAL;
using AttendanceManagementSystemCore.Domain;
using AttendanceManagementSystemCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystemCore.Controller
{
    public class AttendanceTableController
    {
        DateTime today;
        public void SaveAttendance(string stno, bool attendance, int grade, int division, DateTime AttendanceDate)
        {
            try
            {
                today = AttendanceDate;
                AttendanceTableDAL attendanceTableDAL = new AttendanceTableDAL();
                AttendanceTable attendanceTable = new AttendanceTable()
                {
                    Year = today.Year,
                    Month = today.Month,
                    Date = today.Day,
                    StudentNO = stno,
                    AttendanceMark = attendance,
                    Grade = grade,
                    Division = division
                };
                using (var context = new AttendanceContext())
                {
                    attendanceTableDAL.SaveAttendance(attendanceTable, context);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AttendanceTable> Studentfromdivisionandgrade(int division, int grade)
        {
            try
            {
                using (var attendanceContext = new AttendanceContext())
                {
                    AttendanceTableDAL attendanceTableDAL = new AttendanceTableDAL();
                    return attendanceTableDAL.Studentfromdivisionandgrade(division, grade, attendanceContext);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
