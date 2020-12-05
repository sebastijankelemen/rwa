using RWA_MI2_IvanKozul_2RP1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_MI2_IvanKozul_2RP1.Models
{
    public class Kupac
    {
        //IDKupac, Ime, Prezime, Email, Telefon, GradID
        public int IDKupac { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email is required!")]
        [RegularExpression(
        @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
        ErrorMessage = "Email is not valid!")]
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int GradID { get; set; }

        public string GetGradNaziv()
        {
            Repo repo = new Repo();
            return repo.GetCitiesAll().Where(i => i.IDGrad == GradID).ToList()[0].Naziv;
        }
    }
}