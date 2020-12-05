using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_MI1_IvanKozul_2RP1.DAL
{
    public static class Repo
    {
        public static Person GetPersonByID(int id)
        {
            string repoChoice = GetRepoChoice();
            if (repoChoice == "DataBase")
                return DAL.RepositoryDB.GetPersonByID(id);
            else
                return DAL.RepositoryTextFile.GetPersonByID(id);
        }

        public static List<Person> GetAllPersons()
        {
            string repoChoice = GetRepoChoice();
            if (repoChoice == "DataBase")
                return DAL.RepositoryDB.GetAllPersons();
            else
                return DAL.RepositoryTextFile.GetAllPersons();
        }

        public static int CheckLogin(string email, string password)
        {
            string repoChoice = GetRepoChoice();
            if (repoChoice == "DataBase")
                return DAL.RepositoryDB.CheckLogin(email,password);
            else
                return DAL.RepositoryTextFile.CheckLogin(email,password);
        }

        public static void DeletePerson(int id)
        {
            string repoChoice = GetRepoChoice();
            if (repoChoice == "DataBase")
                DAL.RepositoryDB.DeletePerson(id);
            else
                DAL.RepositoryTextFile.DeletePerson(id);
        }

        public static string GetUserRole(int id)
        {
            string repoChoice = GetRepoChoice();
            if (repoChoice == "DataBase")
                return DAL.RepositoryDB.GetUserRole(id);
            else
                return DAL.RepositoryTextFile.GetUserRole(id);
        }

        public static void InsertPerson(Person p)
        {
            string repoChoice = GetRepoChoice();
            if (repoChoice == "DataBase")
                DAL.RepositoryDB.InsertPerson(p);
            else
                DAL.RepositoryTextFile.InsertPerson(p);
        }

        public static void UpdatePerson(Person p)
        {
            string repoChoice = GetRepoChoice();
            if (repoChoice == "DataBase")
                DAL.RepositoryDB.UpdatePerson(p);
            else
                DAL.RepositoryTextFile.UpdatePerson(p);
        }


        public static string GetRepoChoice()
        {
            //if (HttpContext.Current.Request.Cookies["RepoChoice"] == null || HttpContext.Current.Request.Cookies["RepoChoice"].Value.ToString() == "")
            //    return "DataBase";
            //else
            //    return HttpContext.Current.Request.Cookies["RepoChoice"].Value.ToString();

            if (System.Web.HttpContext.Current.Session["RepoChoice"] == null || System.Web.HttpContext.Current.Session["RepoChoice"].ToString() == "")
                return "DataBase";
            else
                return System.Web.HttpContext.Current.Session["RepoChoice"].ToString();
        }
    }
}