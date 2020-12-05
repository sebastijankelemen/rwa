using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RWA_MI1_IvanKozul_2RP1
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private CultureInfo currentCulture;
        private string repo;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            CultureInfo currentCulture;
            if (Session["Culture"] == null || Session["Culture"].ToString() == "")
                currentCulture = new CultureInfo("hr");
            else
                currentCulture = new CultureInfo(Session["Culture"].ToString());

            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetCurrentCultures();

            repo = DAL.Repo.GetRepoChoice();
            SetFooter();
            //ConfigurePermissions();
            //AdaptToHRCulture();
        }

        public void AdaptToHRCulture()
        {
                Label1.Text = "Dodaj Osobu";
                Label2.Text = "Uredi Osobe";
                Label3.Text = "Prikazi Osobe";
                Label4.Text = "Postavke";
                btnLogout.Text = "Odjavi Se";
        }

        protected virtual void InitializeCulture()
        {
            SetCurrentCultures();
        }

        public void SetCurrentCultures()
        {
            if (Session["Culture"]==null || Session["Culture"].ToString()=="")
                currentCulture = new CultureInfo("hr");
            else
                currentCulture = new CultureInfo(Session["Culture"].ToString());

            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;
        }

        private void SetFooter()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToLongDateString());
            sb.Append(" | RWA - <span style='color:red;'>WebForms</span> - Project - Ivan Kožul Web Forms");
            literalFooter.Text = sb.ToString();

            StringBuilder sbRepo = new StringBuilder();
            sbRepo.Append("Repo - "+ repo);
            literalRepoInfo.Text = sbRepo.ToString();
        }

        public void SetTitles(string t)
        {
            lTitle.Text = t;
            lTitleHeader.Text = t;
        }

        public string GetCurrentUserRole()
        {
            try
            {
                return Session["UserRole"].ToString();
            }
            catch (Exception)
            {
                return "Korisnik";
            }
        }

        public int GetCurrentUserID()
        {
            try
            {
                return Int32.Parse(Session["UserId"].ToString());
            }
            catch (Exception)
            {
                return -2;
            }
        }

        public void SetButtonPrimaryColor(string id)
        {
            switch (id)
            {
                case "linkNewPerson":
                    linkNewPerson.CssClass = "btn btn-default navBarBtn btn-primary";
                    break;
                case "linkEditPersons":
                    linkEditPersons.CssClass = "btn btn-default navBarBtn btn-primary";
                    break;
                case "linkShowPersons":
                    linkShowPersons.CssClass = "btn btn-default navBarBtn btn-primary";
                    break;
                default:
                    linkSettings.CssClass = "btn btn-default navBarBtn btn-primary";
                    break;
            }
        }

        public void Logout()
        {
            try
            {
                //HttpContext.Current.Response.Cookies.Remove("UserID");
                //HttpContext.Current.Response.Cookies.Remove("UserRole");
                Session["UserId"] = "";
                Session["UserRole"] = "";
            }
            catch (Exception)
            {
            }
        }

        private void ConfigurePermissions()
        {
            //string userID = "";
            //if (HttpContext.Current.Request.Cookies["UserID"] != null && HttpContext.Current.Request.Cookies["UserID"].Value.ToString() != "")
            //{
            //    userID = HttpContext.Current.Response.Cookies["UserID"].Value.ToString();
            //}

            //if(userID == null || userID == "")
            //{
            //    linkNewPerson.CssClass = "btn btn-default navBarBtn disabled";
            //    linkEditPersons.CssClass = "btn btn-default navBarBtn disabled";
            //    linkShowPersons.CssClass = "btn btn-default navBarBtn disabled";
            //    linkSettings.CssClass = "btn btn-default navBarBtn disabled";
            //}

            //string userRole = "";
            //if (HttpContext.Current.Request.Cookies["UserRole"] != null && HttpContext.Current.Request.Cookies["UserRole"].Value.ToString() != "")
            //{
            //    userRole = HttpContext.Current.Response.Cookies["UserRole"].Value.ToString();
            //}
            //if (userRole == "Korisnik")
            //{
            //    linkNewPerson.CssClass= "btn btn-default navBarBtn disabled";
            //    linkEditPersons.CssClass = "btn btn-default navBarBtn disabled";
            //}
        }

        public int GenerateRandomId()
        {
            Random random = new Random();
            return random.Next();
        }

        public void HideLogoutBtnGroup()
        {
            btnLogout.CssClass = "hide";
            mailAdminBtn.CssClass= "hide";
        }

        protected void linkNewPerson_Click(object sender, EventArgs e)
        {
            if (Session["UserId"]!=null && Session["UserRole"] != null)
            {
                string userID = Session["UserId"].ToString();
                string userRole = Session["UserRole"].ToString();


                if (userID == null || userID == "" || userRole == "Korisnik")
                    Response.Redirect("Login.aspx");
                else
                    Response.Redirect("NewPerson.aspx");
            }

            Response.Redirect("Login.aspx");
        }

        protected void linkEditPersons_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null && Session["UserRole"] != null)
            {
                string userID = Session["UserId"].ToString();
                string userRole = Session["UserRole"].ToString();

                if (userID == null || userID == "" || userRole == "Korisnik")
                    Response.Redirect("Login.aspx");
                else
                {
                    Session["searchingForId"] = "";
                    Response.Redirect("EditData.aspx");
                }
            }

            Response.Redirect("Login.aspx");
        }

        protected void linkShowPersons_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null && Session["UserRole"] != null)
            {
                string userID = Session["UserId"].ToString();
            string userRole = Session["UserRole"].ToString();

            if (userID=="" || userID == null)
                Response.Redirect("Login.aspx");
            else
                Response.Redirect("ShowPersons.aspx");
        }
        Response.Redirect("Login.aspx");
        }

        protected void linkSettings_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null && Session["UserRole"] != null)
            {
                string userID = Session["UserId"].ToString();

                if (userID == null || userID == "")
                    Response.Redirect("Login.aspx");
                else
                    Response.Redirect("Setup.aspx");
            }

            Response.Redirect("Login.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
            Response.Redirect("Login.aspx");
        }

        public void ShowToasterMessage(string m)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "show_Toast('" + m + "');", true);
        }
        public void ShowToasterMessageDelete(string m)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "show_ToastDelete('" + m + "');", true);
        }
    }
}