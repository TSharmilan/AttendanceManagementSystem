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
    public partial class StudentRegistration_UI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadGrade();
                LoadDivision();
                LoadMedium();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(btnSave.Text == "Save")
            {
                try
                {
                    StudentController studentController = new StudentController();

                    string school = "Kn/Murugananda College";
                    string indexNo = txtIndexNo.Text;
                    string gender = rbtListGender.SelectedValue.ToString();
                    string fName = txtFName.Text;
                    string lName = txtLName.Text;
                    int grade = Convert.ToInt32(ddlGrade.SelectedValue);
                    int division = Convert.ToInt32(ddlDivision.SelectedValue);
                    int medium = Convert.ToInt32(ddlMedium.SelectedValue);
                    DateTime dob = Convert.ToDateTime(txtDOB.Text);
                    string address = txtAddress.Text;
                    string address1 = txtAddress1.Text;
                    string phoneNo = txtPhoneNo.Text;
                    string email = txtEmail.Text;
                    DateTime enteredDate = System.DateTime.Now;

                    studentController.SaveStudent(school, indexNo, gender, fName, lName, grade, division, medium, dob, address,
                        address1, phoneNo, email, enteredDate);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                pnlSuccess.Visible = true;
                Clear();
            }
        }

        void Clear()
        {
            txtIndexNo.Text = "";
            rbtListGender.ClearSelection();
            txtFName.Text = "";
            txtLName.Text = "";
            ddlGrade.SelectedIndex = -1;
            ddlDivision.SelectedIndex = -1;
            ddlMedium.SelectedIndex = -1;
            txtDOB.Text = "";
            txtAddress.Text = "";
            txtAddress1.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            pnlSuccess.Visible = false;
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

        public void LoadMedium()
        {
            ddlMedium.Items.Clear();
            List<Medium> mediumList = new List<Medium>();
            MediumController mediumController = new MediumController();

            Medium medium = new Medium
            {
                MediumName = "--Select Medium --",
                MediumID = -1
            };

            mediumList.Add(medium);
            mediumList.AddRange(mediumController.FindByAll());

            ddlMedium.DataSource = mediumList;
            ddlMedium.DataTextField = "MediumName";
            ddlMedium.DataValueField = "MediumID";
            ddlMedium.DataBind();
        }
    }
}