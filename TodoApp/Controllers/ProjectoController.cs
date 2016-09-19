using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;
using TodoApp.Models.DAL;

namespace TodoApp.Controllers
{
    public class ProjectoController : Controller
    {
        private todoAppContext db = new todoAppContext();

        // GET: Projecto
        public ActionResult Index()
        {

            return View();
        }
        //GET: lista de projectos
        public JsonResult ListaProjecto()
        {

            return Json(db.Projecto.Select(p => new
            {
                nome = p.nome,
                membro = p.membro.nome,
                dataInicio = p.dataInicio.ToString(),
                dataFim = p.dataFim.ToString(),
                estado = p.estado

            }), JsonRequestBehavior.AllowGet);

        }

        // GET: Projecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projecto projecto = db.Projecto.Find(id);
            if (projecto == null)
            {
                return HttpNotFound();
            }
            return View(projecto);
        }

        // GET: Projecto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projecto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,dataInicio,dataFim,id_membro,estado")] Projecto projecto)
        {
            if (ModelState.IsValid)
            {
                db.Projecto.Add(projecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projecto);
        }

        // GET: Projecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projecto projecto = db.Projecto.Find(id);
            if (projecto == null)
            {
                return HttpNotFound();
            }
            return View(projecto);
        }

        // POST: Projecto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,dataInicio,dataFim,id_membro,estado")] Projecto projecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projecto);
        }

        // GET: Projecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projecto projecto = db.Projecto.Find(id);
            if (projecto == null)
            {
                return HttpNotFound();
            }
            return View(projecto);
        }

        // POST: Projecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projecto projecto = db.Projecto.Find(id);
            db.Projecto.Remove(projecto);
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
