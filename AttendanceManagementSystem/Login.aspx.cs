using AttendanceManagementSystemCore;
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["USER_ID"] = null;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
         {
            try
            {
                Teacher teacher = new Teacher();
                TeacherController teacherController = new TeacherController();
                Teacher Teacher = teacherController.FindByUsername(txtUserName.Text.Trim());
                //EncryptionDetails encryptionDetails = new EncryptionDetails();


                if (Teacher != null && txtPassword.Text == Teacher.Password)
                {
                    Session["USER_ID"] = Teacher.Password;
                    teacher = teacherController.FindByUsername(Teacher.UserName);
                    Response.Redirect("User_Interface/Home_UI.aspx");

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