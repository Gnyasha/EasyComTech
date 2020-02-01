using EasyComTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyComTech
{
    public partial class DeveloperRegistration : System.Web.UI.Page
    {
        EasyDbContext easyContext = new EasyDbContext();



       
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
                
                loadHours();
                loadDayTime();
                ViewState["DevSkillsApplied"] = DevSkillsApplied;
                loadSkills();
            }
            else
            {
                TabName.Value = Request.Form[TabName.UniqueID];
            }
          
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //TabName.Value = "Knowledge";

            TabName.Value = "Knowledge";
        }

        private void saveDeveloper()
        {
            //Save developer basic details
            DevDetail dev = new DevDetail();
            dev.FullName = txtName.Value;
            dev.LinkedIn = txtLinkedIn.Value;
            dev.Skype = txtSkype.Value;
            dev.Email = txtEmail.Value;
            dev.Salary = Convert.ToDecimal(txtSalary.Value);
            dev.City = txtCity.Value;
            dev.Portfolio = txtPortfolio.Value;
            dev.Phone = txtPhone.Value;
            dev.State = txtState.Value;

            easyContext.DevDetails.Add(dev);
            easyContext.SaveChanges();

            var savedDev = easyContext.DevDetails.Where(a => a.Email == dev.Email && a.FullName == dev.FullName).OrderByDescending(a => a.Id).FirstOrDefault();

            //Save hour preferences

            var checkedHours = chkHours.Items.Cast<ListItem>().Where(x => x.Selected);

            foreach (var hour in checkedHours)
            {
                DevHour hours = new DevHour();
                hours.DevId = savedDev.Id;
                hours.HourId = Convert.ToInt32(hour.Value);

                easyContext.DevHours.Add(hours);
            }

            easyContext.SaveChanges();

            //Save daytime preferences

            var checkedDayTime = chkDayTime.Items.Cast<ListItem>().Where(x => x.Selected);

            foreach (var item in checkedDayTime)
            {
                DevDayTime devDay = new DevDayTime();
                devDay.DevId = savedDev.Id;
                devDay.DayTimeId = Convert.ToInt32(item.Value);
                easyContext.DevDayTimes.Add(devDay);
            }

            easyContext.SaveChanges();

          
            foreach (var item in DevSkillsApplied)
            {
                DevSkill skill = new DevSkill();
                skill.DevId = savedDev.Id;
                skill.SkillId = item.SkillId;
                skill.Rating = item.Rating;

                easyContext.DevSkills.Add(skill);
            }
            easyContext.SaveChanges();

            ShowMessage("Successfully added Developer - " + savedDev.FullName, WarningType.Success);

        }


        private void addDevSkill()
        {
            if (cmbDevSkillCart.SelectedIndex > -1)
            {
                if (rdbExpertise.SelectedIndex>-1)
                {
                    AppliedSkills skill = new AppliedSkills();
                    var selected = Convert.ToInt32(cmbDevSkillCart.SelectedValue);
                    skill.SkillId = easyContext.SkillsSetups.Where(a => a.Id == selected).Select(a => a.Id).FirstOrDefault();
                    skill.SkillName = easyContext.SkillsSetups.Where(a => a.Id == selected).Select(a => a.Details).FirstOrDefault();
                    skill.Rating = Convert.ToInt32(rdbExpertise.SelectedValue);
                    DevSkillsApplied.Add(skill);
                    ShowMessage("Thank you! We've added " + skill.SkillName +" to your expertise. Continue adding all the skills", WarningType.Success);
                    loadSkills();
                }

                else
                {
                    ShowMessage("Please select skill expertise", WarningType.Danger);
                }
            }
            else
            {
                ShowMessage("Wonderful, You have added all skills to your expertise", WarningType.Info);
            }



            grdDevSkills.DataSource = null;
            grdDevSkills.DataBind();
            grdDevSkills.DataSource = DevSkillsApplied.OrderByDescending(a=>a.SkillName).ToList();
            grdDevSkills.DataBind();

        }

        private void loadSkills()
        {
            cmbDevSkillCart.DataSource = null;
            cmbDevSkillCart.DataBind();
            var taken = DevSkillsApplied.Select(a => a.SkillId).ToList();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDevSkillCart.Items.Count>0)
                {
                    ShowMessage("Please enter all skills", WarningType.Danger);
                }
                else
                {
                    saveDeveloper();
                }
                
            }
            catch (Exception)
            {
                ShowMessage("A critical error occured while saving the changes. Please contact the administrator", WarningType.Danger);
            }
           
        }

        protected void btnAddSkill_Click(object sender, EventArgs e)
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

            AppliedSkills applied = DevSkillsApplied.Where(a => a.SkillId == id).FirstOrDefault();
            DevSkillsApplied.Remove(applied);

            loadSkills();

        }
    }
}