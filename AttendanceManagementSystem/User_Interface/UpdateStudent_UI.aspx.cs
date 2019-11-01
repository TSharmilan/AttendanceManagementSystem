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
    public partial class UpdateStudent_UI : System.Web.UI.Page
    {

        List<Student> studentList = new List<Student>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void SearchStudent()
        {
            string IndexNo = txtIndexNo.Text.Trim();
            if (IndexNo != "")
            {

                try
                {
                    string indexNo = txtIndexNo.Text.ToString();
                    StudentController studentController = new StudentController();
                    List<Student> studentList = new List<Student>();


                    studentList = studentController.FethchByIndexNo(indexNo);
                    if (studentList.Count == 0)
                    {
                        gv.Visible = false;
                        pnlExist.Visible = true;
                        lblMsg.Text = "No search record found,Please Check your Index Number";
                        lblMsg.Visible = true;

                    }
                    else
                    {
                        lblMsg.Visible = false;
                        pnlExist.Visible = false;

                        gv.DataSource = studentList;
                        gv.DataBind();
                        gv.Visible = true;
                    }
                }
                catch (Exception)
                {
                    gv.Visible = false;
                    pnlExist.Visible = true;
                    lblMsg.Text = "Invalid Index Number";
                    lblMsg.Visible = true;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchStudent();
        }

        protected void gv_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int IndexNo = Convert.ToInt32(((HiddenField)gv.Rows[e.NewSelectedIndex].Cells[0].FindControl("hdnStudentID")).Value);
            //string OtherName = ((HiddenField)gvOtherInquiry.Rows[e.NewSelectedIndex].FindControl("hdnOtherName")).Value.Trim();
            string url = "StudentRegistration_UI.aspx?IndexNo=" + IndexNo.ToString();
            Response.Redirect(url);

        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SearchStudent();
            if (studentList.Count != 0)
            {
                gv.PageIndex = e.NewPageIndex;
                gv.DataSource = studentList;
                gv.DataBind();
            }
        }

        protected void gv_DataBound(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;

            if (gridView.HeaderRow != null && gridView.HeaderRow.Cells.Count > 0)
            {
                gridView.HeaderRow.Cells[0].Visible = false;
            }

            foreach (GridViewRow row in gv.Rows)
            {
                row.Cells[0].Visible = false;
            }
        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                StudentController studentController = new StudentController();
                int index = e.RowIndex;
                string studentID = ((HiddenField)gv.Rows[index].Cells[0].FindControl("hdnStudentID")).Value;
                studentController.DeleteStudent(Convert.ToInt32(studentID));
                BindStudentList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BindStudentList()
        {
            try
            {
                List<Student> studentList = new List<Student>();
                StudentController studentController = new StudentController();

                using (var context = new AttendanceContext())
                {
                    studentList = studentController.FindByAll();
                }

                gv.DataSource = studentList;
                gv.DataBind();
                ViewState["StudentView"] = studentList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}