using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA_MI1_IvanKozul_2RP1
{
    public partial class NewPerson : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["Theme"] != null)
                Theme = Session["Theme"].ToString();

            CultureInfo currentCulture;
            if (Session["Culture"] == null || Session["Culture"].ToString() == "")
                currentCulture = new CultureInfo("hr");
            else
                currentCulture = new CultureInfo(Session["Culture"].ToString());

            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;
            Master.AdaptToHRCulture();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetButtonPrimaryColor("linkNewPerson");
            Master.SetTitles(GetLocalResourceObject("PageResource1.Title").ToString());
            if (IsPostBack)
            {
                if (Session["PersonUploaded"]!=null && (bool)Session["PersonUploaded"])
                {
                    literalSendStatus.Text = "Person Succesfully Added <p>&nbsp;</p>";
                    Session["PersonUploaded"] = false;
                }
            }
        }

        protected void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();

                if (tbName.Text == "" || tbSurname.Text == "" || tbEmail.Text == "" || tbPassword.Text == "" || tbPasswordConfirm.Text == "")
                    return;

                DAL.Repo.InsertPerson(new Person()
                {
                    ID = Master.GenerateRandomId(),
                    Name = tbName.Text,
                    Surname = tbSurname.Text,
                    Email = tbEmail.Text,
                    Email2 = GetAdditionalEmail(1),
                    Email3 = GetAdditionalEmail(2),
                    Phone = tbTelephone.Text,
                    Password = tbPassword.Text,
                    City = ddlCity.SelectedValue,
                    Role = ddlRole.SelectedValue
                });
                ClearControls();
                Session["PersonUploaded"] = true;
                Master.ShowToasterMessage("Person " + tbName.Text + " " + tbSurname.Text + " added");
            }
            catch (Exception)
            {
                Session["PersonUploaded"] = false;
            }
        }

        private void ClearControls()
        {
            tbName.Text = "";
            tbSurname.Text = "";
            tbEmail.Text = "";
            tbEmail2.Text = "";
            tbEmail3.Text = "";
            tbTelephone.Text = "";
            tbPassword.Text = "";
            tbPasswordConfirm.Text = "";
            ddlCity.SelectedValue = "Zagreb";
            ddlRole.SelectedValue = "Korsnik";
        }

        private string GetAdditionalEmail(int v)
        {
            if (v == 1)
            {
                if (tbEmail2.CssClass != "form-control hide")
                    return tbEmail2.Text;
                else
                    return "";
            }
            else
            {
                if (tbEmail3.CssClass != "form-control hide")
                    return tbEmail3.Text;
                else
                    return "";
            }
        }

        protected void lbAddEmail_Click(object sender, EventArgs e)
        {
            if (tbEmail3.CssClass == "form-control hide" && tbEmail2.CssClass != "form-control hide")
                tbEmail3.CssClass = "form-control";

            if (tbEmail2.CssClass == "form-control hide")
                tbEmail2.CssClass = "form-control";

        }
    }
}