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
    public class AdminDAL
    {
        public void SaveAdmin(Admin admin, AttendanceContext attendanceContext)
        {
            try
            {
                attendanceContext.Admins.Add(admin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Admin FindByUsername(string username, AttendanceContext attendanceContext)
        {
            try
            {
                var loginVar = attendanceContext.Admins.Where(c => c.UserName.Equals(username));

                Admin admin = new Admin();
                foreach (var item in loginVar)
                {
                    admin = (Admin)item;

                }
                return admin;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void DeleteAdmin(Admin admin, AttendanceContext context)
        {
            try
            {
                context.Admins.Add(admin);
                context.Entry(admin).State = EntityState.Deleted;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void UpdateAdmin(Admin admin, AttendanceContext context)
        {
            try
            {
                context.Admins.Add(admin);
                context.Entry(admin).State = EntityState.Modified;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public Admin FindByID(int adminID, AttendanceContext context)
        {
            try
            {
                return context.Admins.Where(a => a.AdminID == adminID).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Admin> FindByAll(AttendanceContext attendanceContext)
        {
            try
            {
                return attendanceContext.Admins.OrderBy(a => a.AdminName).ToList();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
