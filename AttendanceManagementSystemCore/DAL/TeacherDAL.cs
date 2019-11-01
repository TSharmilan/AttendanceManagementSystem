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
    public class TeacherDAL
    {
        public void SaveTeacher(Teacher teacher, AttendanceContext attendanceContext)
        {
            try
            {
                attendanceContext.Teachers.Add(teacher);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetAllTeachers(AttendanceContext attendanceContext)
        {
            try
            {
                var q = from member in attendanceContext.Teachers.Where(a => a.School.Equals("Kn/Murugananda College")) select member;

                int count = q.Select(b => b.TeacherID).Distinct().Count();

                return count;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Teacher FindByUsername(string username, AttendanceContext attendanceContext)
        {
            try
            {
                var loginVar = attendanceContext.Teachers.Where(c => c.UserName.Equals(username));

                Teacher teacher = new Teacher();
                foreach (var item in loginVar)
                {
                    teacher = (Teacher)item;

                }
                return teacher;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void DeleteTeacher(Teacher teacher, AttendanceContext context)
        {
            try
            {
                context.Teachers.Add(teacher);
                context.Entry(teacher).State = EntityState.Deleted;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void UpdateTeacher(Teacher teacher, AttendanceContext context)
        {
            try
            {
                context.Teachers.Add(teacher);
                context.Entry(teacher).State = EntityState.Modified;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public Teacher FindByID(int teacherID, AttendanceContext context)
        {
            try
            {
                return context.Teachers.Where(a => a.TeacherID == teacherID).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Teacher> FindByAll(AttendanceContext attendanceContext)
        {
            try
            {
                return attendanceContext.Teachers.OrderBy(a => a.TeacherName).ToList();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
