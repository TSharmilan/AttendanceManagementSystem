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
    public class DivisionController
    {
        public void SaveDivision(string divisionName, DateTime enteredDate)
        {
            Division division = new Division();
            DivisionDAL divisionDAL = new DivisionDAL();
            {
                try
                {
                    using (var attendanceContext = new AttendanceContext())
                    {
                        division.DivisionName = divisionName;
                        division.EnteredDate = enteredDate;

                        divisionDAL.SaveDivision(division, attendanceContext);
                        attendanceContext.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DeleteDivisionItem(int divisionID)
        {
            DivisionDAL divisionDAL = new DivisionDAL();
            try
            {
                using (var context = new AttendanceContext())
                {
                    divisionDAL.DeleteDivision(new Division
                    {
                        DivisionID = divisionID,
                    }, context);
                    context.SaveChanges();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void UpdateDivision(int divisionID, string divisionName, DateTime enteredDate)
        {
            DivisionDAL divisionDAL = new DivisionDAL();

            using (AttendanceContext attendanceContext = new AttendanceContext())
            {
                Division division = attendanceContext.Divisions.Where(s => s.DivisionID == divisionID).Single();
                division.DivisionName = divisionName;
                division.EnteredDate = enteredDate;

                attendanceContext.SaveChanges();
            }
        }

        public Division FindByID(int divisionID)
        {
            DivisionDAL divisionDAL = new DivisionDAL();

            using (var context = new AttendanceContext())
            {
                return divisionDAL.FindByID(divisionID, context);
            }
        }

        public List<Division> FindByAll()
        {
            try
            {
                using (var attendancecontext = new AttendanceContext())
                {
                    DivisionDAL divisionDAL = new DivisionDAL();
                    return divisionDAL.FindByAll(attendancecontext);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
