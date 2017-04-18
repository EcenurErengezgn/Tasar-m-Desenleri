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
    public class DosyalamaArsivlemesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: DosyalamaArsivlemes
        public ActionResult Index()
        {
            var dosyalamaArsivlemes = db.DosyalamaArsivlemes.Include(d => d.ResimYolu);
            return View(dosyalamaArsivlemes.ToList());
        }

        // GET: DosyalamaArsivlemes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DosyalamaArsivleme dosyalamaArsivleme = db.DosyalamaArsivlemes.Find(id);
            if (dosyalamaArsivleme == null)
            {
                return HttpNotFound();
            }
            return View(dosyalamaArsivleme);
        }

        // GET: DosyalamaArsivlemes/Create
        public ActionResult Create()
        {
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi");
            return View();
        }

        // POST: DosyalamaArsivlemes/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] DosyalamaArsivleme dosyalamaArsivleme)
        {
            if (ModelState.IsValid)
            {
                db.DosyalamaArsivlemes.Add(dosyalamaArsivleme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", dosyalamaArsivleme.ResimYolu_id);
            return View(dosyalamaArsivleme);
        }

        // GET: DosyalamaArsivlemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DosyalamaArsivleme dosyalamaArsivleme = db.DosyalamaArsivlemes.Find(id);
            if (dosyalamaArsivleme == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", dosyalamaArsivleme.ResimYolu_id);
            return View(dosyalamaArsivleme);
        }

        // POST: DosyalamaArsivlemes/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] DosyalamaArsivleme dosyalamaArsivleme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dosyalamaArsivleme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", dosyalamaArsivleme.ResimYolu_id);
            return View(dosyalamaArsivleme);
        }

        // GET: DosyalamaArsivlemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DosyalamaArsivleme dosyalamaArsivleme = db.DosyalamaArsivlemes.Find(id);
            if (dosyalamaArsivleme == null)
            {
                return HttpNotFound();
            }
            return View(dosyalamaArsivleme);
        }

        // POST: DosyalamaArsivlemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DosyalamaArsivleme dosyalamaArsivleme = db.DosyalamaArsivlemes.Find(id);
            db.DosyalamaArsivlemes.Remove(dosyalamaArsivleme);
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
