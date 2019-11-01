using AttendanceManagementSystemCore.Domain;
using AttendanceManagementSystemCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystemCore.DAL
{
    public class StudentDAL
    {
        public void SaveStudent(Student student, AttendanceContext attendanceContext)
        {
            try
            {
                attendanceContext.Students.Add(student);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Student> Studentfromdivisionandgrade(int divisionid, int gradeid, AttendanceContext attendanceContext)
        {
            try
            {
                return attendanceContext.Students.Where(a => a.DivisionID == divisionid && a.GradeID == gradeid).ToList();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public int GetAllStudents(AttendanceContext attendanceContext)
        {
            try
            {
                var q = from member in attendanceContext.Students.Where(a => a.School.Equals("Kn/Murugananda College")) select member;

                int count = q.Select(b => b.StudentID).Distinct().Count();

                return count;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Student FindByID(string indexNo, AttendanceContext attendanceContext)
        {
            try
            {
                return attendanceContext.Students.Where(a => a.IndexNo == indexNo).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Student> FethchByIndexNo(string indexNo, AttendanceContext attendanceContext)
        {

            try
            {

                var indNo = attendanceContext.Students.Where(DBobject => DBobject.IndexNo == indexNo)
                                       .ToList();
                return indNo.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteStudent(Student student, AttendanceContext attendanceContext)
        {
            try
            {
                attendanceContext.Students.Add(student);
                attendanceContext.Entry(student).State = EntityState.Deleted;
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public List<Student> FindByAll(AttendanceContext attendanceContext)
        {
            try
            {
                return attendanceContext.Students.OrderBy(a => a.IndexNo).ToList();
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }
    }
}
