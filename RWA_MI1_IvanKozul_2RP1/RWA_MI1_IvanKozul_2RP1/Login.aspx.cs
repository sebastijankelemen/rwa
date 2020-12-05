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
    public partial class Login : System.Web.UI.Page
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

            Master.HideLogoutBtnGroup();
            Master.SetTitles(GetLocalResourceObject("PageResource1.Title").ToString());
            if (IsPostBack == false)
            {
                Session["UserId"] = "";
                Session["UserRole"] = "";

                if (Session["RepoChoice"] is null)
                    Session["RepoChoice"] = "DataBase";

                //if (HttpContext.Current.Response.Cookies["RepoChoice"] is null)
                //{
                //    HttpCookie cookie = new HttpCookie("RepoChoice", "DataBase");
                //    cookie.Expires = DateTime.Now.AddDays(3);
                //    Response.Cookies.Add(cookie);
                //    Response.Cookies["RepoChoice"].Values.Add("RepoChoice", "DataBase");
                //}
            }
        }

        protected void AttemptLogin(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtLozinka.Text;

            int returned = DAL.Repo.CheckLogin(email, password);

            if(returned == -2)
            {
                lieralLoginError.Text = "No Such User!";
            }
            else if(returned == -1)
            {
                lieralLoginError.Text = "Wrong Password!";
            }
            else
            {
                Person user = DAL.Repo.GetPersonByID(returned);
                //lieralLoginError.Text = "Welcome " + user.Name + "!";
                bool rememberMe = cbRememberMe.Checked;
                //CreateUserIdCookie(user.ID, rememberMe);
                //CreateUserRoleCookie(user.Role, rememberMe);
                Session["UserId"] = user.ID;
                Session["UserRole"] = user.Role;
                Response.Redirect("ShowPersons.aspx");
            }
        }
        //private void CreateUserRoleCookie(string role, bool rememberMe)
        //{
        //    HttpContext.Current.Response.Cookies["UserRole"].Value = role;
        //    //HttpCookie cookie = new HttpCookie("UserRole", role);
        //    //if (rememberMe)
        //    //    cookie.Expires = DateTime.Now.AddDays(100);
        //    //else
        //    //    cookie.Expires = DateTime.Now.AddMinutes(1);

        //    //HttpContext.Current.Response.Cookies.Add(cookie);
        //}

        //private void CreateUserIdCookie(int userId, bool rememberMe)
        //{
        //    HttpContext.Current.Response.Cookies["UserID"].Value = userId.ToString();
        //    //HttpCookie cookie = new HttpCookie("UserID", userId.ToString());
        //    //if(rememberMe)
        //    //    cookie.Expires = DateTime.Now.AddDays(100);
        //    //else
        //    //    cookie.Expires = DateTime.Now.AddMinutes(1);

        //    //HttpContext.Current.Response.Cookies.Add(cookie);
        //}
    }
}