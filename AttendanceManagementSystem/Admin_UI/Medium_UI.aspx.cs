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
    public partial class Medium_UI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindMediumList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(btnSave.Text == "Save")
            {
                try
                {
                    MediumController mediumController = new MediumController();

                    string mediumName = txtMedium.Text;
                    DateTime enteredDate = System.DateTime.Now;

                    mediumController.SaveMedium(mediumName, enteredDate);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                BindMediumList();
                Clear();
            }
            else if(btnSave.Text == "Update")
            {
                try
                {
                    MediumController mediumController = new MediumController();

                    int mediumID = Convert.ToInt32(hdnMediumUpdate.Value);
                    string mediumName = txtMedium.Text;
                    DateTime enteredDate = System.DateTime.Now;

                    mediumController.UpdateMedium(mediumID, mediumName, enteredDate);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                BindMediumList();
                Clear();
                btnSave.Text = "Save";
            }
        }

        void Clear()
        {
            txtMedium.Text = "";
        }

        protected void BindMediumList()
        {
            try
            {
                List<Medium> mediumList = new List<Medium>();
                MediumController mediumController = new MediumController();

                using (var context = new AttendanceContext())
                {
                    mediumList = mediumController.FindByAll();
                }

                gvMedium.DataSource = mediumList;
                gvMedium.DataBind();
                ViewState["MiscMediumView"] = mediumList;
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

        protected void gvMedium_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                MediumController mediumController = new MediumController();
                int index = e.RowIndex;
                string mediumID = ((HiddenField)gvMedium.Rows[index].Cells[0].FindControl("hdnMediumID")).Value;
                mediumController.DeleteMediumItem(Convert.ToInt32(mediumID));
                BindMediumList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvMedium_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                MediumController mediumController = new MediumController();
                string mediumID = ((HiddenField)gvMedium.Rows[e.NewSelectedIndex].Cells[0].FindControl("hdnMediumID")).Value;
                hdnMediumUpdate.Value = mediumID.ToString();
                Medium medium = new Medium();
                medium = mediumController.FindByID(Convert.ToInt32(mediumID));
                txtMedium.Text = medium.MediumName.ToString();
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}