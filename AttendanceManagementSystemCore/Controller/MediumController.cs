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
    public class MediumController
    {
        public void SaveMedium(string mediumName, DateTime enteredDate)
        {
            Medium medium = new Medium();
            MediumDAL mediumDAL = new MediumDAL();
            {
                try
                {
                    using (var attendanceContext = new AttendanceContext())
                    {
                        medium.MediumName = mediumName;
                        medium.EnteredDate = enteredDate;

                        mediumDAL.SaveMedium(medium, attendanceContext);
                        attendanceContext.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DeleteMediumItem(int mediumId)
        {
            MediumDAL mediumDAL = new MediumDAL();
            try
            {
                using (var context = new AttendanceContext())
                {
                    mediumDAL.DeleteMedium(new Medium
                    {
                        MediumID = mediumId,
                    }, context);
                    context.SaveChanges();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void UpdateMedium(int mediumID, string mediumName, DateTime enteredDate)
        {
            MediumDAL mediumDAL = new MediumDAL();

            using (AttendanceContext attendanceContext = new AttendanceContext())
            {
                Medium medium = attendanceContext.Mediums.Where(s => s.MediumID == mediumID).Single();
                medium.MediumName = mediumName;
                medium.EnteredDate = enteredDate;

                attendanceContext.SaveChanges();
            }
        }

        public Medium FindByID(int mediumID)
        {
            MediumDAL mediumDAL = new MediumDAL();

            using (var context = new AttendanceContext())
            {
                return mediumDAL.FindByID(mediumID, context);
            }
        }

        public List<Medium> FindByAll()
        {
            try
            {
                using (var attendancecontext = new AttendanceContext())
                {
                    MediumDAL mediumDAL = new MediumDAL();
                    return mediumDAL.FindByAll(attendancecontext);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
