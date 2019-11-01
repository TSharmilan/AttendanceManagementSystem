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
    public partial class AddTeachers_UI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindTeacherList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                try
                {
                    TeacherController teacherController = new TeacherController();

                    string teacherName = txtName.Text;
                    string empNo = txtEmpNo.Text;
                    string userName = txtUserName.Text;
                    string password = txtPassword.Text;
                    string school = "Kn/Murugananda College";
                    DateTime enteredDate = System.DateTime.Now;

                    teacherController.SaveTeacher(teacherName, empNo, userName, password, school, enteredDate);
                    pnlSuccess.Visible = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                BindTeacherList();
                Clear();
            }
            else if(btnSave.Text == "Update")
            {
                try
                {
                    TeacherController teacherController = new TeacherController();

                    int teacherID = Convert.ToInt32(hdnTeacherUpdate.Value);
                    string teacherName = txtName.Text;
                    string empNo = txtEmpNo.Text;
                    string userName = txtUserName.Text;
                    string password = txtPassword.Text;
                    DateTime enteredDate = System.DateTime.Now;

                    teacherController.UpdateTeacher(teacherID, teacherName, empNo, userName, password, enteredDate);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                BindTeacherList();
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

        protected void BindTeacherList()
        {
            try
            {
                List<Teacher> teacherList = new List<Teacher>();
                TeacherController teacherController = new TeacherController();

                using (var context = new AttendanceContext())
                {
                    teacherList = teacherController.FindByAll();
                }

                gv.DataSource = teacherList;
                gv.DataBind();
                ViewState["MiscTeacherView"] = teacherList;
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
                TeacherController teacherController = new TeacherController();
                int index = e.RowIndex;
                string teacherID = ((HiddenField)gv.Rows[index].Cells[0].FindControl("hdnTeacherID")).Value;
                teacherController.DeleteTeacher(Convert.ToInt32(teacherID));
                BindTeacherList();
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
                TeacherController teacherController = new TeacherController();
                string teacherID = ((HiddenField)gv.Rows[e.NewSelectedIndex].Cells[0].FindControl("hdnTeacherID")).Value;
                hdnTeacherUpdate.Value = teacherID.ToString();
                Teacher teacher = new Teacher();
                teacher = teacherController.FindByID(Convert.ToInt32(teacherID));
                txtName.Text = teacher.TeacherName.ToString();
                txtEmpNo.Text = teacher.EmpNo.ToString();
                txtUserName.Text = teacher.UserName.ToString();
                txtPassword.Text = teacher.Password.ToString();
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