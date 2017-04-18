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
    public class ResimYolusController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: ResimYolus
        public ActionResult Index()
        {
            return View(db.ResimYolus.ToList());
        }

        // GET: ResimYolus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResimYolu resimYolu = db.ResimYolus.Find(id);
            if (resimYolu == null)
            {
                return HttpNotFound();
            }
            return View(resimYolu);
        }

        // GET: ResimYolus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResimYolus/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,adi")] ResimYolu resimYolu)
        {
            if (ModelState.IsValid)
            {
                db.ResimYolus.Add(resimYolu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resimYolu);
        }

        // GET: ResimYolus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResimYolu resimYolu = db.ResimYolus.Find(id);
            if (resimYolu == null)
            {
                return HttpNotFound();
            }
            return View(resimYolu);
        }

        // POST: ResimYolus/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,adi")] ResimYolu resimYolu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resimYolu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resimYolu);
        }

        // GET: ResimYolus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResimYolu resimYolu = db.ResimYolus.Find(id);
            if (resimYolu == null)
            {
                return HttpNotFound();
            }
            return View(resimYolu);
        }

        // POST: ResimYolus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResimYolu resimYolu = db.ResimYolus.Find(id);
            db.ResimYolus.Remove(resimYolu);
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
