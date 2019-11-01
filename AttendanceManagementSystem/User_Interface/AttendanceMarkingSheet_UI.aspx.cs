using AttendanceManagementSystemCore.Controller;
using AttendanceManagementSystemCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceManagementSystem.User_Interface
{
    public partial class AttendanceMarkingSheet_UI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadGrade();
                LoadDivision();
            }
        }

        public void LoadGrade()
        {
            ddlGrade.Items.Clear();
            List<Grade> gradeList = new List<Grade>();
            GradeController gradeController = new GradeController();

            Grade grade = new Grade
            {
                GradeName = "--Select Grade --",
                GradeID = -1
            };

            gradeList.Add(grade);
            gradeList.AddRange(gradeController.FindByAll());

            ddlGrade.DataSource = gradeList;
            ddlGrade.DataTextField = "GradeName";
            ddlGrade.DataValueField = "GradeID";
            ddlGrade.DataBind();
        }

        public void LoadDivision()
        {
            ddlDivision.Items.Clear();
            List<Division> divisionList = new List<Division>();
            DivisionController divisionController = new DivisionController();

            Division division = new Division
            {
                DivisionName = "--Select Division --",
                DivisionID = -1
            };

            divisionList.Add(division);
            divisionList.AddRange(divisionController.FindByAll());

            ddlDivision.DataSource = divisionList;
            ddlDivision.DataTextField = "DivisionName";
            ddlDivision.DataValueField = "DivisionID";
            ddlDivision.DataBind();
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {

            StudentController StudentController = new StudentController();
            List<Student> studentlist = StudentController.Studentfromdivisionandgrade(Convert.ToInt32(ddlDivision.SelectedValue), Convert.ToInt32(ddlGrade.SelectedValue));

            gv.DataSource = studentlist;
            gv.DataBind();
        }

        protected void saveattendence()
        {
            string studentno;
            DateTime today = Convert.ToDateTime(txtDate.Text);

            AttendanceTableController attendanceTableController = new AttendanceTableController();

            foreach (GridViewRow row in gv.Rows)
            {

                CheckBox chkItem = (CheckBox)row.FindControl("chkBOx");
                studentno = row.Cells[1].Text;

                attendanceTableController.SaveAttendance(studentno, chkItem.Checked, Convert.ToInt32(ddlGrade.SelectedValue), Convert.ToInt32(ddlDivision.SelectedValue), today);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime today = Convert.ToDateTime(txtDate.Text);

            saveattendence();

            Response.Redirect("AttendanceMarkingSheet_UI.aspx");
        }

        protected void chkBOx_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void gv_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}