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
    public partial class Division_UI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindDivisionList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(btnSave.Text == "Save")
            {
                try
                {
                    DivisionController divisionController = new DivisionController();

                    string divisionName = txtDivision.Text;
                    DateTime enteredDate = System.DateTime.Now;

                    divisionController.SaveDivision(divisionName, enteredDate);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                BindDivisionList();
                Clear();
            }
            else if (btnSave.Text == "Update")
            {
                try
                {
                    DivisionController divisionController = new DivisionController();

                    int divisionID = Convert.ToInt32(hdnDivisionUpdate.Value);
                    string divisionName = txtDivision.Text;
                    DateTime enteredDate = System.DateTime.Now;

                    divisionController.UpdateDivision(divisionID, divisionName, enteredDate);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                BindDivisionList();
                Clear();
                btnSave.Text = "Save";
            }
        }

        void Clear()
        {
            txtDivision.Text = "";
        }

        protected void BindDivisionList()
        {
            try
            {
                List<Division> divisionList = new List<Division>();
                DivisionController divisionController = new DivisionController();

                using (var context = new AttendanceContext())
                {
                    divisionList = divisionController.FindByAll();
                }

                gv.DataSource = divisionList;
                gv.DataBind();
                ViewState["MiscDivisionView"] = divisionList;
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
                DivisionController divisionController = new DivisionController();
                int index = e.RowIndex;
                string divisionID = ((HiddenField)gv.Rows[index].Cells[0].FindControl("hdnDivisionID")).Value;
                divisionController.DeleteDivisionItem(Convert.ToInt32(divisionID));
                BindDivisionList();
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
                DivisionController divisionController = new DivisionController();
                string divisionID = ((HiddenField)gv.Rows[e.NewSelectedIndex].Cells[0].FindControl("hdnDivisionID")).Value;
                hdnDivisionUpdate.Value = divisionID.ToString();
                Division division = new Division();
                division = divisionController.FindByID(Convert.ToInt32(divisionID));
                txtDivision.Text = division.DivisionName.ToString();
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}