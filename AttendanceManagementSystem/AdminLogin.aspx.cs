using AttendanceManagementSystemCore.Controller;
using AttendanceManagementSystemCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceManagementSystem
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["USER_ID"] = null;
            }
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Admin admin = new Admin();
                AdminController adminController = new AdminController();
                Admin Admin = adminController.FindByUsername(txtUserName.Text.Trim());
                //EncryptionDetails encryptionDetails = new EncryptionDetails();


                if (Admin != null && txtPassword.Text == Admin.Password)
                {
                    Session["USER_ID"] = Admin.Password;
                    admin = adminController.FindByUsername(Admin.UserName);
                    Response.Redirect("Admin_UI/AdminDashboard_UI.aspx");

                }
                else
                {
                    pnlError.Visible = true;
                }
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }
        }
    }
}