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
    public class HesapMakinesisController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: HesapMakinesis
        public ActionResult Index()
        {
            var hesapMakinesis = db.HesapMakinesis.Include(h => h.ResimYolu);
            return View(hesapMakinesis.ToList());
        }

        // GET: HesapMakinesis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HesapMakinesi hesapMakinesi = db.HesapMakinesis.Find(id);
            if (hesapMakinesi == null)
            {
                return HttpNotFound();
            }
            return View(hesapMakinesi);
        }

        // GET: HesapMakinesis/Create
        public ActionResult Create()
        {
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi");
            return View();
        }

        // POST: HesapMakinesis/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] HesapMakinesi hesapMakinesi)
        {
            if (ModelState.IsValid)
            {
                db.HesapMakinesis.Add(hesapMakinesi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", hesapMakinesi.ResimYolu_id);
            return View(hesapMakinesi);
        }

        // GET: HesapMakinesis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HesapMakinesi hesapMakinesi = db.HesapMakinesis.Find(id);
            if (hesapMakinesi == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", hesapMakinesi.ResimYolu_id);
            return View(hesapMakinesi);
        }

        // POST: HesapMakinesis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] HesapMakinesi hesapMakinesi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hesapMakinesi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", hesapMakinesi.ResimYolu_id);
            return View(hesapMakinesi);
        }

        // GET: HesapMakinesis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HesapMakinesi hesapMakinesi = db.HesapMakinesis.Find(id);
            if (hesapMakinesi == null)
            {
                return HttpNotFound();
            }
            return View(hesapMakinesi);
        }

        // POST: HesapMakinesis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HesapMakinesi hesapMakinesi = db.HesapMakinesis.Find(id);
            db.HesapMakinesis.Remove(hesapMakinesi);
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
