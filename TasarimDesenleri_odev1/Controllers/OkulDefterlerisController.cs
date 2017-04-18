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
    public class OkulDefterlerisController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: OkulDefterleris
        public ActionResult Index()
        {
            var okulDefterleris = db.OkulDefterleris.Include(o => o.ResimYolu);
            return View(okulDefterleris.ToList());
        }

        // GET: OkulDefterleris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkulDefterleri okulDefterleri = db.OkulDefterleris.Find(id);
            if (okulDefterleri == null)
            {
                return HttpNotFound();
            }
            return View(okulDefterleri);
        }

        // GET: OkulDefterleris/Create
        public ActionResult Create()
        {
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi");
            return View();
        }

        // POST: OkulDefterleris/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] OkulDefterleri okulDefterleri)
        {
            if (ModelState.IsValid)
            {
                db.OkulDefterleris.Add(okulDefterleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", okulDefterleri.ResimYolu_id);
            return View(okulDefterleri);
        }

        // GET: OkulDefterleris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkulDefterleri okulDefterleri = db.OkulDefterleris.Find(id);
            if (okulDefterleri == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", okulDefterleri.ResimYolu_id);
            return View(okulDefterleri);
        }

        // POST: OkulDefterleris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,adi,fiyat,urun_bilgisi,ResimYolu_id")] OkulDefterleri okulDefterleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(okulDefterleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResimYolu_id = new SelectList(db.ResimYolus, "id", "adi", okulDefterleri.ResimYolu_id);
            return View(okulDefterleri);
        }

        // GET: OkulDefterleris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OkulDefterleri okulDefterleri = db.OkulDefterleris.Find(id);
            if (okulDefterleri == null)
            {
                return HttpNotFound();
            }
            return View(okulDefterleri);
        }

        // POST: OkulDefterleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OkulDefterleri okulDefterleri = db.OkulDefterleris.Find(id);
            db.OkulDefterleris.Remove(okulDefterleri);
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
