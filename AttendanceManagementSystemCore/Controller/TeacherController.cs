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
    public class TeacherController
    {
        public void SaveTeacher(string teacherName, string empNo, string userName, string password, string school, DateTime enteredDate)
        {
            Teacher teacher = new Teacher();
            TeacherDAL teacherDAL = new TeacherDAL();
            {
                try
                {
                    using (var attendanceContext = new AttendanceContext())
                    {
                        teacher.TeacherName = teacherName;
                        teacher.EmpNo = empNo;
                        teacher.UserName = userName;
                        teacher.Password = password;
                        teacher.School = school;
                        teacher.EnteredDate = enteredDate;

                        teacherDAL.SaveTeacher(teacher, attendanceContext);
                        attendanceContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int GetAllTeachers()
        {

            TeacherDAL teacherDAL = new TeacherDAL();
            try
            {
                using (var attendanceContext = new AttendanceContext())
                {
                    return teacherDAL.GetAllTeachers(attendanceContext);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Teacher FindByUsername(string username)
        {
            AttendanceContext attendanceContext = new AttendanceContext();

            try
            {
                TeacherDAL teacherDAL = new TeacherDAL();

                return teacherDAL.FindByUsername(username, attendanceContext);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void DeleteTeacher(int teacherID)
        {
            TeacherDAL teacherDAL = new TeacherDAL();
            try
            {
                using (var context = new AttendanceContext())
                {
                    teacherDAL.DeleteTeacher(new Teacher
                    {
                        TeacherID = teacherID,
                    }, context);
                    context.SaveChanges();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void UpdateTeacher(int teacherID, string teacherName, string empNo, string userName, string password, DateTime enteredDate)
        {
            TeacherDAL teacherDAL = new TeacherDAL();

            using (AttendanceContext attendanceContext = new AttendanceContext())
            {
                Teacher teacher = attendanceContext.Teachers.Where(s => s.TeacherID == teacherID).Single();
                teacher.TeacherName = teacherName;
                teacher.EmpNo = empNo;
                teacher.UserName = userName;
                teacher.EnteredDate = enteredDate;

                attendanceContext.SaveChanges();
            }
        }

        public Teacher FindByID(int teacherID)
        {
            TeacherDAL teacherDAL = new TeacherDAL();

            using (var context = new AttendanceContext())
            {
                return teacherDAL.FindByID(teacherID, context);
            }
        }

        public List<Teacher> FindByAll()
        {
            try
            {
                using (var attendancecontext = new AttendanceContext())
                {
                    TeacherDAL teacherDAL = new TeacherDAL();
                    return teacherDAL.FindByAll(attendancecontext);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
