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
    public partial class ShowPersons : System.Web.UI.Page
    {
        public List<string> rolesList;
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
            if(Session["hidden"] != null && Session["hidden"].ToString() != "")
            {
                if(Session["hidden"].ToString()== "repeater")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "showhide", "HidePanel('repeater');", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "showhide", "ShowPanel('gridView');", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "showhide", "HidePanel('gridView');", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "showhide", "ShowPanel('repeater');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showhide", "HidePanel('repeater');", true);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showhide", "ShowPanel('gridView');", true);
            }

            Master.SetTitles(GetLocalResourceObject("PageResource1.Title").ToString());
            Master.SetButtonPrimaryColor("linkShowPersons");
            rolesList = new List<string>();
            rolesList.Add("Korisnik");
            rolesList.Add("Administrator");

            repeaterPersons.DataSource = DAL.Repo.GetAllPersons();
            repeaterPersons.DataBind();

            if (!IsPostBack)
            {
                BindPersonsGridView();
            }
        }

        public List<Person> getPersons()
        {
            return DAL.Repo.GetAllPersons();
        }

        protected void lbGridView_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "showhide", "HidePanel('repeater');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "showhide", "ShowPanel('gridView');", true);
            Session["hidden"] = "repeater";
            Response.Redirect("ShowPersons.aspx");
        }

        protected void lbRepeater_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "showhide", "HidePanel('gridView');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "showhide", "ShowPanel('repeater');", true);
            Session["hidden"] = "gridView";
            Response.Redirect("ShowPersons.aspx");
        }

        protected void EditBtnClick(object sender, EventArgs e)
        {
            //Master.ShowToasterMessage(((LinkButton)sender).Attributes["name"]);
            Session["searchingForId"] = ((LinkButton)sender).CommandName;
            Response.Redirect("EditData.aspx");
        }

        protected void gwPersons_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gwPersons.Rows[e.RowIndex];
            int personId = Int32.Parse(gwPersons.DataKeys[e.RowIndex].Value.ToString());
            DAL.Repo.DeletePerson(personId);
        }

        protected void gwPersons_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gwPersons.Rows[e.RowIndex];
            TextBox tbName = (TextBox)row.FindControl("tbName");
            TextBox tbSurname = (TextBox)row.FindControl("tbSurname");
            TextBox tbEmail = (TextBox)row.FindControl("tbEmail");
            TextBox tbPhone = (TextBox)row.FindControl("tbPhone");
            DropDownList ddlRole = (DropDownList)row.FindControl("ddlRole");

            int personId = Int32.Parse(gwPersons.DataKeys[e.RowIndex].Value.ToString());
            Person oldPerson = DAL.Repo.GetPersonByID(personId);

            oldPerson.Name = tbName.Text;
            oldPerson.Surname = tbSurname.Text;
            oldPerson.Email = tbEmail.Text;
            oldPerson.Phone = tbPhone.Text;
            oldPerson.Role = ddlRole.Text;

            DAL.Repo.UpdatePerson(oldPerson);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        private void BindPersonsGridView()
        {
            try
            {
                gwPersons.DataSource = DAL.Repo.GetAllPersons();
                gwPersons.DataBind();
            }
            catch (Exception)
            {
            }
        }

        protected void gwPersons_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int indexRetka = e.NewSelectedIndex;
            int ID = (int)gwPersons.DataKeys[indexRetka].Value;
        }

        protected void gwPersons_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gwPersons.EditIndex = e.NewEditIndex;
            BindPersonsGridView();
        }

        protected void gwPersons_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gwPersons.EditIndex = -1;
            BindPersonsGridView();
        }

        protected void gwPersons_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            BindPersonsGridView();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }

}