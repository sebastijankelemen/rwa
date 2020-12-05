using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace RWA_MI1_IvanKozul_2RP1.DAL
{
    public static class RepositoryTextFile
    {
        private const char DELIMITER = '|';

        public static Person GetPersonByID(int id)
        {
            string filePath = GetFilePath();
            String[] lines = File.ReadAllLines(filePath);

            List<Person> list = new List<Person>();

            for (int i = 0; i < lines.Length; i++)
            {
                String[] newPerson = lines[i].Split(DELIMITER);

                list.Add(new Person()
                {
                    ID = Int32.Parse(newPerson[0].ToString()),
                    Name = newPerson[1].ToString(),
                    Surname = newPerson[2].ToString(),
                    Password = newPerson[3].ToString(),
                    Phone = newPerson[4].ToString(),
                    Email = newPerson[5].ToString(),
                    Email2 = newPerson[6].ToString(),
                    Email3 = newPerson[7].ToString(),
                    City = newPerson[8].ToString(),
                    Role = newPerson[9].ToString()
                });
            }
            return (list.Where(p => p.ID == id).ToList())[0];

        }

        public static List<Person> GetAllPersons()
        {
            string filePath = GetFilePath();
            String[] lines = File.ReadAllLines(filePath);

            List<Person> list = new List<Person>();

            for (int i = 0; i < lines.Length; i++)
            {
                String[] newPerson = lines[i].Split(DELIMITER);

                list.Add(new Person()
                {
                    ID = Int32.Parse(newPerson[0].ToString()),
                    Name = newPerson[1].ToString(),
                    Surname = newPerson[2].ToString(),
                    Password = newPerson[3].ToString(),
                    Phone = newPerson[4].ToString(),
                    Email = newPerson[5].ToString(),
                    Email2 = newPerson[6].ToString(),
                    Email3 = newPerson[7].ToString(),
                    City = newPerson[8].ToString(),
                    Role = newPerson[9].ToString()
                });
            }
            return list;
        }

        public static int CheckLogin(string email, string password)
        {
            string filePath = GetFilePath();
            String[] lines = File.ReadAllLines(filePath);

            List<Person> list = new List<Person>();

            for (int i = 0; i < lines.Length; i++)
            {
                String[] newPerson = lines[i].Split(DELIMITER);

                list.Add(new Person()
                {
                    ID = Int32.Parse(newPerson[0].ToString()),
                    Name = newPerson[1].ToString(),
                    Surname = newPerson[2].ToString(),
                    Password = newPerson[3].ToString(),
                    Phone = newPerson[4].ToString(),
                    Email = newPerson[5].ToString(),
                    Email2 = newPerson[6].ToString(),
                    Email3 = newPerson[7].ToString(),
                    City = newPerson[8].ToString(),
                    Role = newPerson[9].ToString()
                });
            }
            if ((list.Where(i => i.Email == email).ToList()).Count == 0)
                return -2;

            Person p = (list.Where(i => i.Email == email).ToList())[0];
            if (p.Password == password)
                return p.ID;
            else
                return -1;
        }

        public static void DeletePerson(int id)
        {
            string filePath = GetFilePath();

            List<Person> list = GetAllPersons();
            List<Person> newList = list.Where(person => person.ID != id).ToList();

            File.WriteAllText(filePath, GetPersonListAsTextBlock(newList));
        }

        public static string GetUserRole(int id)
        {
            string filePath = GetFilePath();
            String[] lines = File.ReadAllLines(filePath);

            List<Person> list = new List<Person>();

            for (int i = 0; i < lines.Length; i++)
            {
                String[] newPerson = lines[i].Split(DELIMITER);

                list.Add(new Person()
                {
                    ID = Int32.Parse(newPerson[0].ToString()),
                    Name = newPerson[1].ToString(),
                    Surname = newPerson[2].ToString(),
                    Password = newPerson[3].ToString(),
                    Phone = newPerson[4].ToString(),
                    Email = newPerson[5].ToString(),
                    Email2 = newPerson[6].ToString(),
                    Email3 = newPerson[7].ToString(),
                    City = newPerson[8].ToString(),
                    Role = newPerson[9].ToString()
                });
            }
            return (list.Where(p => p.ID == id).ToList())[0].Role;
        }

        public static void InsertPerson(Person p)
        {
            string filePath = GetFilePath();
            string personString = p.GetPersonAsFileString();

            List<Person> list = GetAllPersons();
            list.Add(p);

            File.WriteAllText(filePath, GetPersonListAsTextBlock(list));
        }

        public static void UpdatePerson(Person p)
        {
            string filePath = GetFilePath();

            List<Person> list = GetAllPersons();
            List<Person> newList = list.Where(person => person.ID != p.ID).ToList();
            newList.Add(p);

            File.WriteAllText(filePath, GetPersonListAsTextBlock(newList));
        }


        public static string GetPersonListAsTextBlock(List<Person> list)
        {
            StringBuilder sb= new StringBuilder();
            foreach (Person p in list)
            {
                sb.Append(p.GetPersonAsFileString());
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public static string GetPersonListAsTextBlockWithHtmlSpacing(List<Person> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Person p in list)
            {
                sb.Append(p.GetPersonAsFileString());
                sb.Append("<br/>");
            }
            return sb.ToString();
        }


        private static string GetFilePath()
        {
            return ConfigurationManager.AppSettings.Get("fileRepoPath").ToString();
        }
    }
}