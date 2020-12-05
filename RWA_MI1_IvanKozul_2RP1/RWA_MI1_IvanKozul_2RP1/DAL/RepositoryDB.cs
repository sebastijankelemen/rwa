using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace RWA_MI1_IvanKozul_2RP1.DAL
{
    public static class RepositoryDB
    {
        public static Person GetPersonByID(int id)
        {
            string conString = GetConnectionString();
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(conString, "dbo.GetCompleteUserByID", id);

            Array personArray = ds.Tables[0].Rows[0].ItemArray;
            return new Person() {
                ID = Int32.Parse(personArray.GetValue(0).ToString()),
                Name = personArray.GetValue(1).ToString(),
                Surname = personArray.GetValue(2).ToString(),
                Password = personArray.GetValue(3).ToString(),
                Phone = personArray.GetValue(4).ToString(),
                Email = personArray.GetValue(5).ToString(),
                Email2 = personArray.GetValue(6).ToString(),
                Email3 = personArray.GetValue(7).ToString(),
                City = personArray.GetValue(8).ToString(),
                Role = personArray.GetValue(9).ToString()
            };
            
        }

        public static List<Person> GetAllPersons()
        {
            string conString = GetConnectionString();
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(conString, "dbo.GetAllPersons");

            List<Person> list = new List<Person>();

            DataTable personsTable = ds.Tables[0];
            for (int i = 0; i < personsTable.Rows.Count; i++)
            {
                Array personArray = personsTable.Rows[i].ItemArray;

                list.Add(new Person()
                {
                    ID = Int32.Parse(personArray.GetValue(0).ToString()),
                    Name = personArray.GetValue(1).ToString(),
                    Surname = personArray.GetValue(2).ToString(),
                    Password = personArray.GetValue(3).ToString(),
                    Phone = personArray.GetValue(4).ToString(),
                    Email = personArray.GetValue(5).ToString(),
                    Email2 = personArray.GetValue(6).ToString(),
                    Email3 = personArray.GetValue(7).ToString(),
                    City = personArray.GetValue(8).ToString(),
                    Role = personArray.GetValue(9).ToString()
                });
            }
            return list;
        }

        public static int CheckLogin(string email, string password)
        {
            string conString = GetConnectionString();
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(conString, "dbo.CheckLogin", email, password);

            Array array = ds.Tables[0].Rows[0].ItemArray;
            int returnValue = Int32.Parse(ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());

            return returnValue;
        }

        public static void DeletePerson(int id)
        {
            string conString = GetConnectionString();
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(conString, "dbo.DeletePerson", id);
        }

        public static string GetUserRole(int id)
        {
            string conString = GetConnectionString();
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(conString, "dbo.GetUserRole", id);

            Array array = ds.Tables[0].Rows[0].ItemArray;
            string returnValue = ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();

            return returnValue;
        }

        public static void InsertPerson(Person p)
        {
            string conString = GetConnectionString();
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(conString, "dbo.InsertPerson",
                p.Name, p.Surname, p.Password, p.Phone, p.Email, p.Email2, p.Email3, p.City, p.Role);
        }

        public static void UpdatePerson(Person p)
        {
            string conString = GetConnectionString();
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(conString, "dbo.UpdatePerson",
                p.ID, p.Name, p.Surname, p.Password, p.Phone, p.Email, p.Email2, p.Email3, p.City, p.Role);
        }


        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["localDesktopDB"].ToString();
        }
    }
}