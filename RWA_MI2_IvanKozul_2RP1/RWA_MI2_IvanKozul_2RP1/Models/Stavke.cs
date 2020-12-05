using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_MI2_IvanKozul_2RP1.Models
{
    public class Stavke
    {
        //Kolicina,CijenaPoKomadu, PopustUPostocima, UkupnaCijena, p.Naziv,
        //BrojProizvoda, Boja, MinimalnaKolicinaNaSkladistu, CijenaBezPDV, pk.Naziv, k.Naziv
        public string Kolicina { get; set; }
        public string CijenaPoKomadu { get; set; }
        public string PopustUPostocima { get; set; }
        public string UkupnaCijena { get; set; }
        public string PNaziv { get; set; }
        public string BrojProizvoda { get; set; }
        public string Boja { get; set; }
        public string MinimalnaKolicinaNaSkladistu { get; set; }
        public string CijenaBezPDV { get; set; }
        public string PKNaziv { get; set; }
        public string KNaziv { get; set; }
    }
}