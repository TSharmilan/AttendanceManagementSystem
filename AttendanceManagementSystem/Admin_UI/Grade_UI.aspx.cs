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
    public partial class Grade_UI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGradeList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(btnSave.Text == "Save")
            {
                try
                {
                    GradeController gradeController = new GradeController();

                    string gradeName = txtGrade.Text;
                    DateTime enteredDate = System.DateTime.Now;

                    gradeController.SaveGrade(gradeName, enteredDate);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                BindGradeList();
                Clear();
            }
            else if (btnSave.Text == "Update")
            {
                try
                {
                    GradeController gradeController = new GradeController();

                    int gradeID = Convert.ToInt32(hdnGradeUpdate.Value);
                    string gradeName = txtGrade.Text;
                    DateTime enteredDate = System.DateTime.Now;

                    gradeController.UpdateGrade(gradeID, gradeName, enteredDate);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                BindGradeList();
                Clear();
                btnSave.Text = "Save";
            }
        }

        void Clear()
        {
            txtGrade.Text = "";
        }

        protected void BindGradeList()
        {
            try
            {
                List<Grade> gradeList = new List<Grade>();
                GradeController gradeController = new GradeController();

                using (var context = new AttendanceContext())
                {
                    gradeList = gradeController.FindByAll();
                }

                gv.DataSource = gradeList;
                gv.DataBind();
                ViewState["MiscGradeView"] = gradeList;
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
                GradeController gradeController = new GradeController();
                int index = e.RowIndex;
                string gradeID = ((HiddenField)gv.Rows[index].Cells[0].FindControl("hdnGradeID")).Value;
                gradeController.DeleteGradeItem(Convert.ToInt32(gradeID));
                BindGradeList();
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
                GradeController gradeController = new GradeController();
                string gradeID = ((HiddenField)gv.Rows[e.NewSelectedIndex].Cells[0].FindControl("hdnGradeID")).Value;
                hdnGradeUpdate.Value = gradeID.ToString();
                Grade grade = new Grade();
                grade = gradeController.FindByID(Convert.ToInt32(gradeID));
                txtGrade.Text = grade.GradeName.ToString();
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}