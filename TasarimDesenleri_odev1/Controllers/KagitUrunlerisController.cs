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
    public class KagitUrunlerisController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: KagitUrunleris
        public ActionResult Index()
        {
            var kagitUrunleris = db.KagitUrunleris.Include(k => k.ResimYolu);
            return View(kagitUrunleris.ToList());
        }

        // GET: KagitUrunleris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KagitUrunleri kagitUrunleri = db.KagitUrunleris.Find(id);
            if (kagitUrunleri == null)
            {
                return HttpNotFound();
            }
            return View(kagitUrunleri);
        }

        // GET: KagitUrunleris/Create
        public ActionResult Create()
        {
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi");
            return View();
        }

        // POST: KagitUrunleris/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] KagitUrunleri kagitUrunleri)
        {
            if (ModelState.IsValid)
            {
                db.KagitUrunleris.Add(kagitUrunleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", kagitUrunleri.ResimYolu_id);
            return View(kagitUrunleri);
        }

        // GET: KagitUrunleris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KagitUrunleri kagitUrunleri = db.KagitUrunleris.Find(id);
            if (kagitUrunleri == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", kagitUrunleri.ResimYolu_id);
            return View(kagitUrunleri);
        }

        // POST: KagitUrunleris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] KagitUrunleri kagitUrunleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kagitUrunleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", kagitUrunleri.ResimYolu_id);
            return View(kagitUrunleri);
        }

        // GET: KagitUrunleris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KagitUrunleri kagitUrunleri = db.KagitUrunleris.Find(id);
            if (kagitUrunleri == null)
            {
                return HttpNotFound();
            }
            return View(kagitUrunleri);
        }

        // POST: KagitUrunleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KagitUrunleri kagitUrunleri = db.KagitUrunleris.Find(id);
            db.KagitUrunleris.Remove(kagitUrunleri);
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
