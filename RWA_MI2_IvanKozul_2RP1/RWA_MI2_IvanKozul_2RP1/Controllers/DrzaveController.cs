using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RWA_MI2_IvanKozul_2RP1.Models;
using RWA_MI2_IvanKozul_2RP1.DAL;
using System.Text;

namespace RWA_MI2_IvanKozul_2RP1.Controllers
{
    public class DrzaveController : Controller
    {
        private AdventureWorksRWAEntities1 db = new AdventureWorksRWAEntities1();

        // GET: Drzave
        public ActionResult Index()
        {
            ViewBag.ReUrl = Url.Action("Kupac", "Home");
            return View(db.Drzave.ToList());
        }

        [HttpGet]
        public string CityList(string id)
        {
            Repo repo = new Repo();
            List<Grad> lg = repo.GetCityById(Int32.Parse(id));
            StringBuilder sb = new StringBuilder();
            lg.ForEach(i => sb.Append(i.Naziv + ","));
            return sb.ToString().Remove(sb.ToString().Length-1);

        }


        // GET: Drzave/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = db.Drzave.Find(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // GET: Drzave/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drzave/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDrzava,Naziv")] Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                db.Drzave.Add(drzava);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drzava);
        }

        // GET: Drzave/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = db.Drzave.Find(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // POST: Drzave/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDrzava,Naziv")] Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drzava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drzava);
        }

        // GET: Drzave/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = db.Drzave.Find(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // POST: Drzave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drzava drzava = db.Drzave.Find(id);
            db.Drzave.Remove(drzava);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
