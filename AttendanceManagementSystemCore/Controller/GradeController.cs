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
    public class GradeController
    {
        public void SaveGrade(string gradeName, DateTime enteredDate)
        {
            Grade grade = new Grade();
            GradeDAL gradeDAL = new GradeDAL();
            {
                try
                {
                    using (var attendanceContext = new AttendanceContext())
                    {
                        grade.GradeName = gradeName;
                        grade.EnteredDate = enteredDate;

                        gradeDAL.SaveGrade(grade, attendanceContext);
                        attendanceContext.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DeleteGradeItem(int gradeID)
        {
            GradeDAL gradeDAL = new GradeDAL();
            try
            {
                using (var context = new AttendanceContext())
                {
                    gradeDAL.DeleteGrade(new Grade
                    {
                        GradeID = gradeID,
                    }, context);
                    context.SaveChanges();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void UpdateGrade(int gradeID, string gradeName, DateTime enteredDate)
        {
            GradeDAL gradeDAL = new GradeDAL();

            using (AttendanceContext attendanceContext = new AttendanceContext())
            {
                Grade grade = attendanceContext.Grades.Where(s => s.GradeID == gradeID).Single();
                grade.GradeName = gradeName;
                grade.EnteredDate = enteredDate;

                attendanceContext.SaveChanges();
            }
        }

        public Grade FindByID(int gradeID)
        {
            GradeDAL gradeDAL = new GradeDAL();

            using (var context = new AttendanceContext())
            {
                return gradeDAL.FindByID(gradeID, context);
            }
        }

        public List<Grade> FindByAll()
        {
            try
            {
                using (var attendancecontext = new AttendanceContext())
                {
                    GradeDAL gradeDAL = new GradeDAL();
                    return gradeDAL.FindByAll(attendancecontext);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
