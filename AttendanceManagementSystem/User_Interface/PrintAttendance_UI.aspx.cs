using AttendanceManagementSystemCore.Controller;
using AttendanceManagementSystemCore.Domain;
using AttendanceManagementSystemCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceManagementSystem.User_Interface
{
    public partial class PrintAttendance_UI : System.Web.UI.Page
    {
        List<AttendanceTable> attendanceTableList = new List<AttendanceTable>();
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
            AttendanceTableController attendanceTableController = new AttendanceTableController();
            List<AttendanceTable> attendanceTableList = attendanceTableController.Studentfromdivisionandgrade(Convert.ToInt32(ddlDivision.SelectedIndex), Convert.ToInt32(ddlGrade.SelectedIndex));

            gv.DataSource = attendanceTableList;
            gv.DataBind();
        }

        protected void gv_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        //protected void btnPrint_Click(object sender, EventArgs e)
        //{
        //    DateTime today = Convert.ToDateTime(txtDate.Text);

        //    Response.Write("<script type='text/javascript'>window.open('AttendenceReport.aspx?Class=" + ddlDivision.SelectedItem 
        //        + "&Grade=" + ddlGrade.SelectedItem + "&year=" + today.Year + "&month=" + today.Month + "&date=" + today.Day 
        //        + "','_blank');</script>");
        //}
    }
}