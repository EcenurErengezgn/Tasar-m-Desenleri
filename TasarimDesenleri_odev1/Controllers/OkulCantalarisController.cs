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
    public class OkulCantalarisController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: OkulCantalaris
        public ActionResult Index()
        {
            var okulCantalaris = db.OkulCantalaris.Include(o => o.ResimYolu);
            return View(okulCantalaris.ToList());
        }

        // GET: OkulCantalaris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkulCantalari okulCantalari = db.OkulCantalaris.Find(id);
            if (okulCantalari == null)
            {
                return HttpNotFound();
            }
            return View(okulCantalari);
        }

        // GET: OkulCantalaris/Create
        public ActionResult Create()
        {
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi");
            return View();
        }

        // POST: OkulCantalaris/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] OkulCantalari okulCantalari)
        {
            if (ModelState.IsValid)
            {
                db.OkulCantalaris.Add(okulCantalari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", okulCantalari.ResimYolu_id);
            return View(okulCantalari);
        }

        // GET: OkulCantalaris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkulCantalari okulCantalari = db.OkulCantalaris.Find(id);
            if (okulCantalari == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", okulCantalari.ResimYolu_id);
            return View(okulCantalari);
        }

        // POST: OkulCantalaris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] OkulCantalari okulCantalari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(okulCantalari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", okulCantalari.ResimYolu_id);
            return View(okulCantalari);
        }

        // GET: OkulCantalaris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkulCantalari okulCantalari = db.OkulCantalaris.Find(id);
            if (okulCantalari == null)
            {
                return HttpNotFound();
            }
            return View(okulCantalari);
        }

        // POST: OkulCantalaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OkulCantalari okulCantalari = db.OkulCantalaris.Find(id);
            db.OkulCantalaris.Remove(okulCantalari);
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
