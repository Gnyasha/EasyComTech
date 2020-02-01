using EasyComTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyComTech
{
    public partial class EditDeveloper : System.Web.UI.Page
    {
        EasyDbContext easyContext = new EasyDbContext();
        int devId = 0;

        public List<AppliedSkills> DevSkillsApplied
        {
            get
            {
                if ((this.ViewState["DevSkillsApplied"] != null))
                {
                    return (List<AppliedSkills>)this.ViewState["DevSkillsApplied"];
                }
                else
                {
                    return new List<AppliedSkills>();
                }
            }

            set
            {
                this.ViewState["DevSkillsApplied"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //var selected = CBLGold.Items.Cast<ListItem>().Where(x => x.Selected);

            if (!IsPostBack)
            {
                
                try
                {
                     devId = Convert.ToInt32(Request.QueryString["Id"]);
                    ViewState["DevId"] = devId;
                    loadHours();
                    loadDayTime();
                    loadSkills(devId);

                    //Load Saved Developer Details
                    ViewState["DevSkillsApplied"] = loadDevSkillsApplied(devId);
                    loadDevDetails(devId);
                    loadDevHours(devId);
                    loadDevDaytime(devId);
                   
                    grdDevSkills.DataSource = DevSkillsApplied.OrderByDescending(a => a.SkillName).ToList();
                    grdDevSkills.DataBind();

                }
                catch (Exception ex)
                {

                    ShowMessage("A fatal error occured. Contact the administrator "+ ex.Message, WarningType.Danger);
                    //throw;
                }

                
               
            }
            else
            {
                TabName.Value = Request.Form[TabName.UniqueID];
            }
            devId= Convert.ToInt32( ViewState["DevId"]);

        }


        private void loadDevDetails(int Id)
        {
            var dev = easyContext.DevDetails.Where(a => a.Id == Id).FirstOrDefault();
            txtEmail.Value = dev.Email;
            txtCity.Value = dev.City;
            txtLinkedIn.Value = dev.LinkedIn;
            txtName.Value = dev.FullName;
            txtPhone.Value = dev.Phone;
            txtPortfolio.Value = dev.Portfolio;
            txtSalary.Value = dev.Salary.ToString();
            txtSkype.Value = dev.Skype;
            txtState.Value = dev.State;
        }

        private void loadDevHours(int Id)
        {
            var hours = easyContext.DevHours.Where(a => a.DevId == Id);

            foreach (var item in hours)
            {
                var realId = Convert.ToInt32(item.HourId);
                var hour= chkHours.Items[realId-1];
                hour.Selected = true;
            }
        }

        private void loadDevDaytime(int id)
        {
            var devDay = easyContext.DevDayTimes.Where(a => a.DevId == id);

            foreach (var item in devDay)
            {
                var realId = Convert.ToInt32(item.DayTimeId);
                var day = chkDayTime.Items[realId - 1];
                day.Selected = true;
            }
        }

        private List<AppliedSkills> loadDevSkillsApplied(int id)
        {
            List<AppliedSkills> appliedSkills = new List<AppliedSkills>();

            var skills = easyContext.DevSkills.Where(a => a.DevId == id).ToList();
            foreach (var item in skills)
            {
                AppliedSkills skill = new AppliedSkills();
                skill.Rating = Convert.ToInt32(item.Rating);
                skill.SkillId = item.SkillId;
                skill.SkillName = item.SkillsSetup.Details;
                appliedSkills.Add(skill);

            }
            return appliedSkills;

        }
      


        protected void btnNext_Click(object sender, EventArgs e)
        {
            TabName.Value = "Knowledge";
        }

        private void saveDeveloper(int id)
        {
            //Update developer basic details
            DevDetail dev = easyContext.DevDetails.Where(a => a.Id == id).FirstOrDefault();
            dev.FullName = txtName.Value;
            dev.LinkedIn = txtLinkedIn.Value;
            dev.Skype = txtSkype.Value;
            dev.Email = txtEmail.Value;
            dev.Salary = Convert.ToDecimal(txtSalary.Value);
            dev.City = txtCity.Value;
            dev.Portfolio = txtPortfolio.Value;
            dev.Phone = txtPhone.Value;
            dev.State = txtState.Value;

            easyContext.SaveChanges();


            //Remove Saved Settings
            var oldDaytime = easyContext.DevDayTimes.Where(a => a.DevId == id);
            easyContext.DevDayTimes.RemoveRange(oldDaytime);

            var oldHours = easyContext.DevHours.Where(a => a.DevId == id);
            easyContext.DevHours.RemoveRange(oldHours);

            easyContext.SaveChanges();


            //Update hour preferences

            var checkedHours = chkHours.Items.Cast<ListItem>().Where(x => x.Selected);

            foreach (var hour in checkedHours)
            {
                DevHour hours = new DevHour();
                hours.DevId = id;
                hours.HourId = Convert.ToInt32(hour.Value);

                easyContext.DevHours.Add(hours);
            }

            easyContext.SaveChanges();


            //Update daytime preferences

            var checkedDayTime = chkDayTime.Items.Cast<ListItem>().Where(x => x.Selected);

            foreach (var item in checkedDayTime)
            {
                DevDayTime devDay = new DevDayTime();
                devDay.DevId = id;
                devDay.DayTimeId = Convert.ToInt32(item.Value);
                easyContext.DevDayTimes.Add(devDay);
            }

            easyContext.SaveChanges();


            //Update Skills
            foreach (var item in DevSkillsApplied)
            {
                DevSkill skill = easyContext.DevSkills.Where(a => a.DevId == id).FirstOrDefault();
                skill.Rating = item.Rating;
                easyContext.SaveChanges();
            }

            var savedDev = easyContext.DevDetails.Where(a => a.Id == id).FirstOrDefault();

            ShowMessage("Successfully Updated - " + savedDev.FullName + " Details", WarningType.Success);

        }


        private void addDevSkill()
        {
            if (cmbDevSkillCart.SelectedIndex > -1)
            {
                if (rdbExpertise.SelectedIndex > -1)
                {
                    int skillId = Convert.ToInt32(cmbDevSkillCart.SelectedValue);
                    var selected = easyContext.DevSkills.Where(a => a.DevId == devId && a.SkillId == skillId).FirstOrDefault();
                    selected.Rating = Convert.ToInt32(rdbExpertise.SelectedValue);
                    easyContext.SaveChanges();
                    ShowMessage("Skill " + cmbDevSkillCart.SelectedItem.Text +" successfully updated", WarningType.Success);
                    cmbDevSkillCart.DataSource = null;
                    cmbDevSkillCart.DataBind();
                    ViewState["DevSkillsApplied"] = loadDevSkillsApplied(devId);
                }

                else
                {
                    ShowMessage("Nothing to select", WarningType.Warning);
                }
            }
            else
            {
                ShowMessage("Nothing to select", WarningType.Warning);
            }



            grdDevSkills.DataSource = null;
            grdDevSkills.DataBind();
            grdDevSkills.DataSource = DevSkillsApplied.OrderByDescending(a => a.SkillName).ToList();
            grdDevSkills.DataBind();

        }

        private void loadSkills(int id)
        {
            cmbDevSkillCart.DataSource = null;
            cmbDevSkillCart.DataBind();
            var taken = easyContext.DevSkills.Where(a=>a.DevId==id).Select(a => a.SkillId).ToList();
            if (taken.Count > 0)
            {
                var skills = easyContext.SkillsSetups.Where(a => !taken.Contains(a.Id)).ToList();
                cmbDevSkillCart.DataSource = skills;
                cmbDevSkillCart.DataValueField = "Id";
                cmbDevSkillCart.DataTextField = "Details";
                cmbDevSkillCart.DataBind();
            }
            else
            {
                var skills = easyContext.SkillsSetups.ToList();
                cmbDevSkillCart.DataSource = skills;
                cmbDevSkillCart.DataValueField = "Id";
                cmbDevSkillCart.DataTextField = "Details";
                cmbDevSkillCart.DataBind();
            }


            //    drpNominee.DataTextField = "Bankname";
            // drpNominee.DataValueField = "Bankcode";
        }

        private void loadHours()
        {
            chkHours.DataSource = null;
            chkHours.DataBind();
            var hours = easyContext.HoursSetups.ToList();
            chkHours.DataSource = hours;
            chkHours.DataValueField = "Id";
            chkHours.DataTextField = "Details";
            chkHours.DataBind();

        }

        private void loadDayTime()
        {
            chkDayTime.DataSource = null;
            chkDayTime.DataBind();
            var hours = easyContext.DayTimeSetups.ToList();
            chkDayTime.DataSource = hours;
            chkDayTime.DataValueField = "Id";
            chkDayTime.DataTextField = "Details";
            chkDayTime.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDevSkillCart.Items.Count > 0)
                {
                    ShowMessage("Please enter all skills", WarningType.Danger);
                }
                else
                {
                    saveDeveloper(devId);
                }

            }
            catch (Exception)
            {
                ShowMessage("A critical error occured while saving the changes. Please contact the administrator", WarningType.Danger);
            }

        }

        protected void btnUpdateSkill_Click(object sender, EventArgs e)
        {
            addDevSkill();
            TabName.Value = "Knowledge";
        }

        protected void grdDevSkills_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDevSkills.PageIndex = e.NewPageIndex;
            grdDevSkills.DataSource = DevSkillsApplied.ToList();
            grdDevSkills.DataBind();
            TabName.Value = "Knowledge";
        }

        protected void grdDevSkills_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void grdDevSkills_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "SelectSkill") return;
            int id = Convert.ToInt32(e.CommandArgument);

            var applied = easyContext.DevSkills.Where(a => a.SkillId == id && a.DevId==devId).FirstOrDefault(); 

            var skills = easyContext.SkillsSetups.Where(a => a.Id==applied.SkillId).ToList();
            cmbDevSkillCart.DataSource = skills;
            cmbDevSkillCart.DataValueField = "Id";
            cmbDevSkillCart.DataTextField = "Details";
            cmbDevSkillCart.DataBind();

            rdbExpertise.SelectedValue = applied.Rating.ToString();

        }


    }
}