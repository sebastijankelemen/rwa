using RWA_MI2_IvanKozul_2RP1.DAL;
using RWA_MI2_IvanKozul_2RP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RWA_MI2_IvanKozul_2RP1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Drzave()
        {
            return View();
        }

        public ActionResult Kupac(int? naziv)
        {
            ViewBag.naziv = naziv;
            return View();
        }

        [HttpGet]
        public string Kupci(string naziv)
        {
            Repo repo = new Repo();

            List<Grad> l = repo.GetCitiesAll();
            int gradID = l.Where(g => g.Naziv == naziv).ToList()[0].IDGrad;

            List<Kupac> list = repo.GetKupci().Where(k => k.GradID== gradID).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (Kupac item in list)
            {
                sb.Append(item.IDKupac.ToString() + ',' + item.Ime + ',' + item.Prezime + ','
                    + item.Email + ',' + item.Telefon + ',' + item.GradID + ',' + item.GetGradNaziv() + '*');
            }
            return sb.ToString().Remove(sb.ToString().Length - 1);
        }
        [HttpGet]
        public string KupacUpdate(string id, string ime, string prezime, string email, string telefon, string gradNaziv)
        {
            Repo repo = new Repo();
            List<Grad> l = repo.GetCitiesAll();
            int gradID = l.Where(g => g.Naziv == gradNaziv).ToList()[0].IDGrad;

            repo.UpdateKupac(id, ime, prezime, email, telefon, gradID);

            return "updated";
        }


        public ActionResult Racun(int? KupacID)
        {
            ViewBag.KupacID = KupacID;
            return View();
        }

        [HttpGet]
        public string GetRacuni(string id)
        {
            Repo repo = new Repo();
            List<Racun> list = repo.GetRacuniByKupacID(Int32.Parse(id));

            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            foreach (Racun item in list)
            {
                sb.Append("{ "+
                    "\"BrojRacuna\": "+" \"" + item.BrojRacuna + "\", "+
                    "\"DatumIzdavanja\": " + " \"" + item.DatumIzdavanja + "\", " +
                    "\"Ime\": " + " \"" + item.Ime + "\", " +
                    "\"Prezime\": " + " \"" + item.Prezime + "\", " +
                    "\"StalniZaposlenik\": " + item.StalniZaposlenik.ToString().ToLower() + ", " +
                    "\"Tip\": " + " \"" + item.Tip + "\", " +
                    "\"Broj\": " + " \"" + item.Broj + "\", " +
                    "\"IstekMjesec\": " + " \"" + item.IstekMjesec + "\", " +
                    "\"IstekGodina\": " + " \"" + item.IstekGodina + "\" " +
                    "},");

            }
            string res = sb.ToString().Remove(sb.ToString().Length - 1) + "]";
            return res;
        }
        //var racuni = [
        //    { "Name": "Otto Clay", "Age": 25, "Country": 1, "Address": "Ap #897-1459 Quam Avenue", "Married": false },
        //    { "Name": "Connor Johnston", "Age": 45, "Country": 2, "Address": "Ap #370-4647 Dis Av.", "Married": true },
        //    { "Name": "Lacey Hess", "Age": 29, "Country": 3, "Address": "Ap #365-8835 Integer St.", "Married": false },
        //    { "Name": "Timothy Henson", "Age": 56, "Country": 1, "Address": "911-5143 Luctus Ave", "Married": true },
        //    { "Name": "Ramona Benton", "Age": 32, "Country": 3, "Address": "Ap #614-689 Vehicula Street", "Married": false }
        //];

        public ActionResult Stavka(int? RacunBroj)
        {
            ViewBag.RacunBroj = RacunBroj;
            return View();
        }

        [HttpGet]
        public string GetStavke(string brojRacuna)
        {
            Repo repo = new Repo();
            List<Stavke> list = repo.GetStavkeByRacunBroj(brojRacuna);

            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            foreach (Stavke item in list)
            {
                sb.Append("{ " +
                    "\"Kolicina\": " + " \"" + item.Kolicina + "\", " +
                    "\"CijenaPoKomadu\": " + " \"" + item.CijenaPoKomadu + "\", " +
                    "\"PopustUPostocima\": " + " \"" + item.PopustUPostocima + "\", " +
                    "\"UkupnaCijena\": " + " \"" + item.UkupnaCijena + "\", " +
                    "\"PNaziv\": " + " \"" + item.PNaziv + "\", " +
                    "\"BrojProizvoda\": " + " \"" + item.BrojProizvoda + "\", " +
                    "\"Boja\": " + " \"" + item.Boja + "\", " +
                    "\"MinimalnaKolicinaNaSkladistu\": " + " \"" + item.MinimalnaKolicinaNaSkladistu + "\", " +
                    "\"CijenaBezPDV\": " + " \"" + item.CijenaBezPDV + "\", " +
                    "\"PKNaziv\": " + " \"" + item.PKNaziv + "\", " +
                    "\"KNaziv\": " + " \"" + item.KNaziv + "\" " +
                    "},");

            }
            string res = sb.ToString().Remove(sb.ToString().Length - 1) + "]";
            return res;
        }
    }
}