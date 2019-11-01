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
    public class AdminController
    {
        public void SaveAdmin(string adminName, string empNo, string userName, string password, DateTime enteredDate)
        {
            Admin admin = new Admin();
            AdminDAL adminDAL = new AdminDAL();
            {
                try
                {
                    using (var attendanceContext = new AttendanceContext())
                    {
                        admin.AdminName = adminName;
                        admin.EmpNo = empNo;
                        admin.UserName = userName;
                        admin.Password = password;
                        admin.EnteredDate = enteredDate;

                        adminDAL.SaveAdmin(admin, attendanceContext);
                        attendanceContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Admin FindByUsername(string username)
        {
            AttendanceContext attendanceContext = new AttendanceContext();

            try
            {
                AdminDAL adminDAL = new AdminDAL();

                return adminDAL.FindByUsername(username, attendanceContext);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void DeleteAdmin(int adminID)
        {
            AdminDAL adminDAL = new AdminDAL();
            try
            {
                using (var context = new AttendanceContext())
                {
                    adminDAL.DeleteAdmin(new Admin
                    {
                        AdminID = adminID,
                    }, context);
                    context.SaveChanges();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void UpdateAdmin(int adminID, string adminName, string empNo, string userName, string password, DateTime enteredDate)
        {
            AdminDAL adminDAL = new AdminDAL();

            using (AttendanceContext attendanceContext = new AttendanceContext())
            {
                Admin admin = attendanceContext.Admins.Where(s => s.AdminID == adminID).Single();
                admin.AdminName = adminName;
                admin.EmpNo = empNo;
                admin.UserName = userName;
                admin.EnteredDate = enteredDate;

                attendanceContext.SaveChanges();
            }
        }

        public Admin FindByID(int adminID)
        {
            AdminDAL adminDAL = new AdminDAL();

            using (var context = new AttendanceContext())
            {
                return adminDAL.FindByID(adminID, context);
            }
        }

        public List<Admin> FindByAll()
        {
            try
            {
                using (var attendancecontext = new AttendanceContext())
                {
                    AdminDAL adminDAL = new AdminDAL();
                    return adminDAL.FindByAll(attendancecontext);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
