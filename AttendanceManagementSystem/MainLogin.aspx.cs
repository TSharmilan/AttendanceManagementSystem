using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceManagementSystem
{
    public partial class MainLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AdminLogin.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnTeacherLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnStudentLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("StudentLogin.aspx");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}