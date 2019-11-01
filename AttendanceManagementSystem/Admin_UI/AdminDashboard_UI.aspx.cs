using AttendanceManagementSystemCore.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceManagementSystem.Admin_UI
{
    public partial class AdminDashboard_UI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTotalStudents();
            GetTotalTeachers();
        }

        protected void GetTotalStudents()
        {
            try
            {
                StudentController studentController = new StudentController();

                lblStudents.Text = string.Format("{0:#,0}", studentController.GetAllStudents());
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GetTotalTeachers()
        {
            try
            {
                TeacherController teacherController = new TeacherController();

                lblTeachers.Text = string.Format("{0:#,0}", teacherController.GetAllTeachers());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}