using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RWA_MI1_IvanKozul_2RP1
{
    public partial class EditData : System.Web.UI.Page
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

        PersonControl personControl;
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetTitles(GetLocalResourceObject("PageResource1.Title").ToString());
            Master.SetButtonPrimaryColor("linkEditPersons");
            if (Session["searchingForId"] is null || Session["searchingForId"].ToString() == "")
                ShowPersonControls(DAL.Repo.GetAllPersons());
            else
            {
                ShowPersonControls((DAL.Repo.GetAllPersons()).Where(p => p.ID == Int32.Parse(Session["searchingForId"].ToString())).ToList());
                //Session["searchingForId"] = "";
            }
        }

        private void ShowPersonControls(List<Person> list)
        {
            if (list.Count == 1)
            {
                personControl = (PersonControl)LoadControl("~/PersonControl.ascx");
                personControl.person = list.ElementAt(0);
                phPersons.Controls.Add(personControl);

                var link = new HtmlLink();
                link.Href = "~/Content/Style/EditOnePersonSheet.css";
                link.Attributes.Add("rel", "stylesheet");
                link.Attributes.Add("type", "text/css");
                Page.Header.Controls.Add(link);
            }
            else { 

                foreach (Person person in list)
                {
                    personControl = (PersonControl)LoadControl("~/PersonControl.ascx");
                    personControl.person = person;
                    phPersons.Controls.Add(personControl);
                }
            }
        }
    }
}