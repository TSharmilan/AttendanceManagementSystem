using AttendanceManagementSystemCore.Controller;
using AttendanceManagementSystemCore.Domain;
using AttendanceManagementSystemCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceManagementSystem.Admin_UI
{
    public partial class Add_Admins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindAdminList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                try
                {
                    AdminController adminController = new AdminController();

                    string adminName = txtName.Text;
                    string empNo = txtEmpNo.Text;
                    string userName = txtUserName.Text;
                    string password = txtPassword.Text;
                    DateTime enteredDate = System.DateTime.Now;

                    adminController.SaveAdmin(adminName, empNo, userName, password, enteredDate);
                    pnlSuccess.Visible = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                BindAdminList();
                Clear();
            }
            else if (btnSave.Text == "Update")
            {
                try
                {
                    AdminController adminController = new AdminController();

                    int adminID = Convert.ToInt32(hdnAdminUpdate.Value);
                    string adminName = txtName.Text;
                    string empNo = txtEmpNo.Text;
                    string userName = txtUserName.Text;
                    string password = txtPassword.Text;
                    DateTime enteredDate = System.DateTime.Now;

                    adminController.UpdateAdmin(adminID, adminName, empNo, userName, password, enteredDate);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                BindAdminList();
                Clear();
                btnSave.Text = "Save";
            }
        }

        void Clear()
        {
            txtName.Text = "";
            txtEmpNo.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        protected void BindAdminList()
        {
            try
            {
                List<Admin> adminList = new List<Admin>();
                AdminController adminController = new AdminController();

                using (var context = new AttendanceContext())
                {
                    adminList = adminController.FindByAll();
                }

                gv.DataSource = adminList;
                gv.DataBind();
                ViewState["MiscAdminView"] = adminList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                AdminController adminController = new AdminController();
                int index = e.RowIndex;
                string adminID = ((HiddenField)gv.Rows[index].Cells[0].FindControl("hdnAdminID")).Value;
                adminController.DeleteAdmin(Convert.ToInt32(adminID));
                BindAdminList();
                pnlSuccess.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gv_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                AdminController adminController = new AdminController();
                string adminID = ((HiddenField)gv.Rows[e.NewSelectedIndex].Cells[0].FindControl("hdnAdminID")).Value;
                hdnAdminUpdate.Value = adminID.ToString();
                Admin admin = new Admin();
                admin = adminController.FindByID(Convert.ToInt32(adminID));
                txtName.Text = admin.AdminName.ToString();
                txtEmpNo.Text = admin.EmpNo.ToString();
                txtUserName.Text = admin.UserName.ToString();
                txtPassword.Text = admin.Password.ToString();
                btnSave.Text = "Update";
                pnlSuccess.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}