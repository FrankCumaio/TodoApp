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
    public class projectoesController : Controller
    {
        private Model1 db = new Model1();

        // GET: projectoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projecto projecto = db.projectos.Find(id);
            if (projecto == null)
            {
                return HttpNotFound();
            }
            return View(projecto);
        }

        // GET: projectoes/Create
        public ActionResult Create()
        {
            ViewBag.responsavel = new SelectList(db.membros, "id", "nome");
            return View();
        }

        // POST: projectoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProjecto,nome,dInicio,dFim,responsavel")] projecto projecto)
        {
            if (ModelState.IsValid)
            {
                db.projectos.Add(projecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.responsavel = new SelectList(db.membros, "id", "nome", projecto.responsavel);
            return View(projecto);
        }

        // GET: projectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projecto projecto = db.projectos.Find(id);
            if (projecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.responsavel = new SelectList(db.membros, "id", "nome", projecto.responsavel);
            return View(projecto);
        }

        // POST: projectoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProjecto,nome,dInicio,dFim,responsavel")] projecto projecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.responsavel = new SelectList(db.membros, "id", "nome", projecto.responsavel);
            return View(projecto);
        }

        // GET: projectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projecto projecto = db.projectos.Find(id);
            if (projecto == null)
            {
                return HttpNotFound();
            }
            return View(projecto);
        }

        // POST: projectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            projecto projecto = db.projectos.Find(id);
            db.projectos.Remove(projecto);
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
       public ActionResult Index()
       {
            //    var proj = db.projectos.Where(p => p.nome.Contains(searchString));

            //    if (!String.IsNullOrEmpty(searchString))
            //    {
            //        return View(proj);
            //    }
            //    else
            //    {
            //         proj = db.projectos.Include(p => p.membro);

            return View();
           }

            
        //}

        public ActionResult loaddata()
        {


            var proj = db.projectos.Select(p=> new
            {
                nomeProj = p.nome,
                nomeResp = p.membro.nome,
                dataI = p.dInicio.ToString(),
                dataF = p.dFim.ToString()

            }
                );
            return Json(new { data = proj }, JsonRequestBehavior.AllowGet);
        }
    }
}
