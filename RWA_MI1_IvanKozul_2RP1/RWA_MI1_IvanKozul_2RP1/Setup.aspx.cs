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
    public partial class Setup : System.Web.UI.Page
    {
        public CultureInfo currentCulture { get; set; }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["Theme"] != null)
                Theme = Session["Theme"].ToString();

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
            Master.SetTitles(GetLocalResourceObject("PageResource1.Title").ToString());
            Master.SetButtonPrimaryColor("linkSettings");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue != "--------------Choose--------------")
            {
                HttpContext.Current.Response.Cookies["RepoChoice"].Value = ((DropDownList)sender).SelectedValue;
                Session["RepoChoice"] = ((DropDownList)sender).SelectedValue;
                Master.Logout();
                Response.Redirect("Login.aspx");
            }
        }

        protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Theme"] = ddlTheme.SelectedValue;
            Response.Redirect("Setup.aspx");
        }

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlLanguage.SelectedValue.ToString()=="Croatian" || ddlLanguage.SelectedValue.ToString() == "Hrvatski")
                Session["Culture"] = "hr-HR";
            if (ddlLanguage.SelectedValue.ToString() == "English" || ddlLanguage.SelectedValue.ToString() == "Engleski")
                Session["Culture"] = "en";
            Response.Redirect("Setup.aspx");
        }
    }
}