using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using P6_2_0320190016.Models;

namespace P6_2_0320190016.Controllers
{
    public class Mahasiswas16Controller : Controller
    {
        private P6_0320190016Entities db = new P6_0320190016Entities();

        // GET: Mahasiswas16
        public ActionResult Index()
        {
            return View(db.Mahasiswas.ToList());
        }

        // GET: Mahasiswas16/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // GET: Mahasiswas16/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mahasiswas16/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nim,nama,alamat,email,tgl_lahir")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                db.Mahasiswas.Add(mahasiswa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mahasiswa);
        }

        // GET: Mahasiswas16/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // POST: Mahasiswas16/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nim,nama,alamat,email,tgl_lahir")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mahasiswa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mahasiswa);
        }

        // GET: Mahasiswas16/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // POST: Mahasiswas16/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            db.Mahasiswas.Remove(mahasiswa);
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
