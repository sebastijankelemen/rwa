using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWA_MI1_IvanKozul_2RP1
{
    public partial class DAL_Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Person p = DAL.RepositoryDB.GetPersonByID(0);
            //List<Person> l = DAL.RepositoryDB.GetAllPersons();
            //Label1.Text = l.Count.ToString();

            //Label1.Text = DAL.RepositoryDB.CheckLogin("admin@admin.hr", "2").ToString();

            HttpCookie cookie = new HttpCookie("RepoChoice", "DataBase");
            cookie.Expires = DateTime.Now.AddDays(3);
            HttpContext.Current.Response.Cookies.Add(cookie);

            DAL.Repo.UpdatePerson(new Person()
            {
                ID = 2,
                Name = "Marko",
                Surname = "Updajtani",
                Password = "p",
                Phone = "022 145 225",
                Email = "asdf@asdf.hr",
                Email2 = "",
                Email3 = "",
                City = "Zagreb",
                Role = "Korisnik"
            });

            Label1.Text = DAL.RepositoryTextFile.GetPersonListAsTextBlockWithHtmlSpacing(DAL.Repo.GetAllPersons());

            


        }
    }
}