using Microsoft.ApplicationBlocks.Data;
using RWA_MI2_IvanKozul_2RP1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_MI2_IvanKozul_2RP1.DAL
{
    public class Repo
    {
        public string CS { get; set; }


        public Repo()
        {
            CS = ConfigurationManager.ConnectionStrings["AdventureWorksRWA"].ConnectionString.ToString();
        }

        //Unošenje login informacija
        public int CheckLogin(string email, string password)
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(CS, "dbo.CheckLogin", email, password);

            Array array = ds.Tables[0].Rows[0].ItemArray;
            int returnValue = Int32.Parse(ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());

            return returnValue;
        }

        //Dohvaćanje kupaca iz baze
        public List<Kupac> GetKupci()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(CS, "dbo.usp_KupacSelectAll",1);

            List<Kupac> list = new List<Kupac>();

            DataTable table = ds.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Array array = table.Rows[i].ItemArray;

                list.Add(new Kupac()
                {
                    IDKupac = Int32.Parse(array.GetValue(0).ToString()),
                    Ime = array.GetValue(1).ToString(),
                    Prezime = array.GetValue(2).ToString(),
                    Email = array.GetValue(3).ToString(),
                    Telefon = array.GetValue(4).ToString(),
                    GradID = Int32.Parse(array.GetValue(5).ToString())
                });
            }
            return list;
        }

        //Update kupaca po ID-u
        public void UpdateKupac(string id, string ime, string prezime, string email, string telefon, int gradID)
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(CS, "dbo.usp_KupacUpdate",id,ime,prezime,email,telefon,gradID);
        }

        //Svi gradovi
        public List<Grad> GetCityById(int drzavaID)
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(CS, "dbo.usp_GradSelectAll");

            List<Grad> list = new List<Grad>();

            DataTable table = ds.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Array array = table.Rows[i].ItemArray;

                list.Add(new Grad()
                {
                    IDGrad = Int32.Parse(array.GetValue(0).ToString()),
                    Naziv = array.GetValue(1).ToString(),
                    DrzavaID = Int32.Parse(array.GetValue(2).ToString())
                });
            }

            return list.Where(i=> i.DrzavaID == drzavaID).ToList();
        }

        public List<Grad> GetCitiesAll()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(CS, "dbo.usp_GradSelectAll");

            List<Grad> list = new List<Grad>();

            DataTable table = ds.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Array array = table.Rows[i].ItemArray;

                list.Add(new Grad()
                {
                    IDGrad = Int32.Parse(array.GetValue(0).ToString()),
                    Naziv = array.GetValue(1).ToString(),
                    DrzavaID = Int32.Parse(array.GetValue(2).ToString())
                });
            }

            return list;
        }

        public List<Racun> GetRacuniByKupacID(int id)
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(CS, "dbo.GetFullRacun", id);

            List<Racun> list = new List<Racun>();

            DataTable table = ds.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Array array = table.Rows[i].ItemArray;
                /*BrojRacuna, DatumIzdavanja,Ime,Prezime,StalniZaposlenik,Tip,Broj,IstekMjesec,IstekGodina*/
                list.Add(new Racun()
                {
                    BrojRacuna = array.GetValue(0).ToString(),
                    DatumIzdavanja = array.GetValue(1).ToString(),
                    Ime = array.GetValue(2).ToString(),
                    Prezime = array.GetValue(3).ToString(),
                    StalniZaposlenik = array.GetValue(4).ToString(),
                    Tip = array.GetValue(5).ToString(),
                    Broj = array.GetValue(6).ToString(),
                    IstekMjesec = array.GetValue(7).ToString(),
                    IstekGodina = array.GetValue(8).ToString()
                });
            }
            return list;
        }

        public List<Stavke> GetStavkeByRacunBroj(string broj)
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(CS, "dbo.GetStavke", broj);

            List<Stavke> list = new List<Stavke>();

            DataTable table = ds.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Array array = table.Rows[i].ItemArray;
                /*BrojRacuna, DatumIzdavanja,Ime,Prezime,StalniZaposlenik,Tip,Broj,IstekMjesec,IstekGodina*/
                list.Add(new Stavke()
                {
                    Kolicina = array.GetValue(0).ToString(),
                    CijenaPoKomadu = array.GetValue(1).ToString(),
                    PopustUPostocima = array.GetValue(2).ToString(),
                    UkupnaCijena = array.GetValue(3).ToString(),
                    PNaziv = array.GetValue(4).ToString(),
                    BrojProizvoda = array.GetValue(5).ToString(),
                    Boja = array.GetValue(6).ToString(),
                    MinimalnaKolicinaNaSkladistu = array.GetValue(7).ToString(),
                    CijenaBezPDV = array.GetValue(8).ToString(),
                    PKNaziv = array.GetValue(9).ToString(),
                    KNaziv = array.GetValue(10).ToString()
                });
            }
            return list;
        }

        //Kolicina,CijenaPoKomadu, PopustUPostocima, UkupnaCijena, p.Naziv,
        //BrojProizvoda, Boja, MinimalnaKolicinaNaSkladistu, CijenaBezPDV, pk.Naziv, k.Naziv

        //Gradovi
        
    }
}