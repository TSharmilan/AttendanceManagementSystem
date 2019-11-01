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
    public class DivisionDAL
    {
        public void SaveDivision(Division division, AttendanceContext attendanceContext)
        {
            try
            {
                attendanceContext.Divisions.Add(division);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDivision(Division division, AttendanceContext context)
        {
            try
            {
                context.Divisions.Add(division);
                context.Entry(division).State = EntityState.Deleted;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void UpdateDivision(Division division, AttendanceContext context)
        {
            try
            {
                context.Divisions.Add(division);
                context.Entry(division).State = EntityState.Modified;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public Division FindByID(int divisionID, AttendanceContext context)
        {
            try
            {
                return context.Divisions.Where(a => a.DivisionID == divisionID).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Division> FindByAll(AttendanceContext attendanceContext)
        {
            try
            {
                return attendanceContext.Divisions.OrderBy(a => a.DivisionName).ToList();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
