using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class membroesController : Controller
    {
        private Model1 db = new Model1();

        // GET: membroes
        public ActionResult Index()
        {
            return View(db.membros.ToList());
        }

        // GET: membroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membro membro = db.membros.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }

        // GET: membroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: membroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,cargo,dRegisto,idade,sexo,endereco,email,gAcademico")] membro membro)
        {
            if (ModelState.IsValid)
            {
                db.membros.Add(membro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membro);
        }

        // GET: membroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membro membro = db.membros.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }

        // POST: membroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,cargo,dRegisto,idade,sexo,endereco,email,gAcademico")] membro membro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membro);
        }

        // GET: membroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membro membro = db.membros.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }

        // POST: membroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            membro membro = db.membros.Find(id);
            db.membros.Remove(membro);
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
