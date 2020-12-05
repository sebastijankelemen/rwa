using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA_MI1_IvanKozul_2RP1
{
    public partial class PersonControl : System.Web.UI.UserControl
    {
        private string currentEmailBeingEdited;
        public Person person { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            tbName.Text = person.Name;
            tbSurname.Text = person.Surname;

            ddlEmail.Items.Clear();
            if(person.Email!="")
                ddlEmail.Items.Add(new ListItem(person.Email));
            if (person.Email2 != "")
                ddlEmail.Items.Add(new ListItem(person.Email2));
            if (person.Email3 != "")
                ddlEmail.Items.Add(new ListItem(person.Email3));

            tbPhone.Text = person.Phone;
            tbPassword.Text = person.Password;

            ddlCity.SelectedValue = person.City;
            ddlRole.SelectedValue = person.Role;

            tbEmail.Text = ddlEmail.SelectedValue;
            currentEmailBeingEdited = ddlEmail.SelectedValue;
        }

        protected void ddlEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbEmail.Text = ddlEmail.SelectedValue;
            currentEmailBeingEdited= ddlEmail.SelectedValue;
        }

        protected void lbEmail_Click(object sender, EventArgs e)
        {
            UpdateEmails();
            UpdatePerson();
        }

        private void UpdateEmails()
        {
            if (currentEmailBeingEdited == person.Email)
                person.Email = tbEmail.Text;
            if (currentEmailBeingEdited == person.Email2)
                person.Email2 = tbEmail.Text;
            if (currentEmailBeingEdited == person.Email3)
                person.Email3 = tbEmail.Text;
        }

        private void UpdatePerson()
        {
            DAL.Repo.UpdatePerson(new Person(){
                ID=person.ID,
                Name = tbName.Text,
                Surname = tbSurname.Text,
                Phone = tbPhone.Text,
                Password = tbPassword.Text,
                Email=person.Email,
                Email2= person.Email2,
                Email3 = person.Email3,
                Role = ddlRole.SelectedValue,
                City = ddlCity.SelectedValue
            });
            ShowToasterMessageCtrl("Person Updated!");
        }

        protected void lbEdit_Click(object sender, EventArgs e)
        {
            UpdateEmails();
            UpdatePerson();
            ShowToasterMessageCtrl("Person Updated!");
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            DAL.Repo.DeletePerson(person.ID);
            ShowToasterMessageCtrlDelete("Person Deleted!");
        }

        public void ShowToasterMessageCtrl(string m)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "show_Toast('" + m + "');", true);
        }
        public void ShowToasterMessageCtrlDelete(string m)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "show_ToastDelete('" + m + "');", true);
        }
    }
}