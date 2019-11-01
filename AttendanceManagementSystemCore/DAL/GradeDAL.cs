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
    public class GradeDAL
    {
        public void SaveGrade(Grade grade, AttendanceContext attendanceContext)
        {
            try
            {
                attendanceContext.Grades.Add(grade);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteGrade(Grade grade, AttendanceContext context)
        {
            try
            {
                context.Grades.Add(grade);
                context.Entry(grade).State = EntityState.Deleted;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void UpdateGrade(Grade grade, AttendanceContext context)
        {
            try
            {
                context.Grades.Add(grade);
                context.Entry(grade).State = EntityState.Modified;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public Grade FindByID(int gradeID, AttendanceContext context)
        {
            try
            {
                return context.Grades.Where(a => a.GradeID == gradeID).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grade> FindByAll(AttendanceContext attendanceContext)
        {
            try
            {
                return attendanceContext.Grades.OrderBy(a => a.GradeName).ToList();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
