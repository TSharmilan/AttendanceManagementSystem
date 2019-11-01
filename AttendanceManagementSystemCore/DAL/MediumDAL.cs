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
    public class MediumDAL
    {
        public void SaveMedium(Medium medium, AttendanceContext attendanceContext)
        {
            try
            {
                attendanceContext.Mediums.Add(medium);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteMedium(Medium medium, AttendanceContext context)
        {
            try
            {
                context.Mediums.Add(medium);
                context.Entry(medium).State = EntityState.Deleted;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void UpdateMedium(Medium medium, AttendanceContext context)
        {
            try
            {
                context.Mediums.Add(medium);
                context.Entry(medium).State = EntityState.Modified;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public Medium FindByID(int mediumID, AttendanceContext context)
        {
            try
            {
                return context.Mediums.Where(a => a.MediumID == mediumID).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Medium> FindByAll(AttendanceContext attendanceContext)
        {
            try
            {
                return attendanceContext.Mediums.OrderBy(a => a.MediumName).ToList();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
