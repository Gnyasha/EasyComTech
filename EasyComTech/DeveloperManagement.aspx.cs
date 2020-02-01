using EasyComTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyComTech
{
    public partial class DeveloperManagement : System.Web.UI.Page
    {
        EasyDbContext easyContext = new EasyDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDevs();
            }
        }

        private void loadDevs()
        {
            
            grdDevs.DataSource = easyContext.DevDetails.ToList();
            grdDevs.DataBind();
        }

        protected void grdDevs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectDev")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/EditDeveloper.aspx?Id=" +id);
            }
            else if (e.CommandName== "RemoveDev")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DeleteDev(id);
            }
            
        }

        private void DeleteDev(int id)
        {
            //Remove Skills
            var devSkill = easyContext.DevSkills.Where(a => a.DevId == id);
            easyContext.DevSkills.RemoveRange(devSkill);
            easyContext.SaveChanges();

            //Remove Hours
            var devHour = easyContext.DevHours.Where(a => a.DevId == id);
            easyContext.DevHours.RemoveRange(devHour);
            easyContext.SaveChanges();

            //Remove DayTimes
            var devDayTimes = easyContext.DevDayTimes.Where(a => a.DevId == id);
            easyContext.DevDayTimes.RemoveRange(devDayTimes);
            easyContext.SaveChanges();

            //Remove Developer Details
            var devDetails = easyContext.DevDetails.Where(a => a.Id == id).FirstOrDefault();
            easyContext.DevDetails.Remove(devDetails);
            easyContext.SaveChanges();

            ShowMessage( devDetails.FullName +" is successfully removed", WarningType.Success);

            grdDevs.DataSource = easyContext.DevDetails.ToList();
            grdDevs.DataBind();
        }


        #region Notify

        public enum WarningType
        {
            Success,
            Info,
            Warning,
            Danger
        }

        public void ShowMessage(string Message, WarningType type)
        {
            //gets the controls from the page
            Panel PanelMessage = Master.FindControl("Message") as Panel;
            Label labelMessage = PanelMessage.FindControl("labelMessage") as Label;

            //sets the message and the type of alert, than displays the message
            labelMessage.Text = Message;
            PanelMessage.CssClass = string.Format("alert alert-{0} alert-dismissable", type.ToString().ToLower());
            PanelMessage.Attributes.Add("role", "alert");
            PanelMessage.Visible = true;
        }
        #endregion

        protected void grdDevs_SelectedIndexChanged(object sender, EventArgs e)
        {


            
        }

        protected void grdDevs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}