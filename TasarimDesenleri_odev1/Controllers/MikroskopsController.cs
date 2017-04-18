using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TasarimDesenleri_odev1.Models;

namespace TasarimDesenleri_odev1.Controllers
{
    public class MikroskopsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Mikroskops
        public ActionResult Index()
        {
            var mikroskops = db.Mikroskops.Include(m => m.ResimYolu);
            return View(mikroskops.ToList());
        }

        // GET: Mikroskops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mikroskop mikroskop = db.Mikroskops.Find(id);
            if (mikroskop == null)
            {
                return HttpNotFound();
            }
            return View(mikroskop);
        }

        // GET: Mikroskops/Create
        public ActionResult Create()
        {
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi");
            return View();
        }

        // POST: Mikroskops/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] Mikroskop mikroskop)
        {
            if (ModelState.IsValid)
            {
                db.Mikroskops.Add(mikroskop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", mikroskop.ResimYolu_id);
            return View(mikroskop);
        }

        // GET: Mikroskops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mikroskop mikroskop = db.Mikroskops.Find(id);
            if (mikroskop == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", mikroskop.ResimYolu_id);
            return View(mikroskop);
        }

        // POST: Mikroskops/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] Mikroskop mikroskop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mikroskop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", mikroskop.ResimYolu_id);
            return View(mikroskop);
        }

        // GET: Mikroskops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mikroskop mikroskop = db.Mikroskops.Find(id);
            if (mikroskop == null)
            {
                return HttpNotFound();
            }
            return View(mikroskop);
        }

        // POST: Mikroskops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mikroskop mikroskop = db.Mikroskops.Find(id);
            db.Mikroskops.Remove(mikroskop);
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
