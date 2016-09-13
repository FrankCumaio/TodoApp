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
    public class tarefasController : Controller
    {
        private Model1 db = new Model1();

        // GET: tarefas
        public ActionResult Index()
        {
            var tarefas = db.tarefas.Include(t => t.membro);
            return View(tarefas.ToList());
        }

        // GET: tarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarefa tarefa = db.tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // GET: tarefas/Create
        public ActionResult Create()
        {
            ViewBag.responsavel = new SelectList(db.membros, "id", "nome");
            return View();
        }

        // POST: tarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTarefa,nome,dCriacao,dEntrega,dEntregaReal,responsavel,descricao")] tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.tarefas.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.responsavel = new SelectList(db.membros, "id", "nome", tarefa.responsavel);
            return View(tarefa);
        }

        // GET: tarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarefa tarefa = db.tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.responsavel = new SelectList(db.membros, "id", "nome", tarefa.responsavel);
            return View(tarefa);
        }

        // POST: tarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTarefa,nome,dCriacao,dEntrega,dEntregaReal,responsavel,descricao")] tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.responsavel = new SelectList(db.membros, "id", "nome", tarefa.responsavel);
            return View(tarefa);
        }

        // GET: tarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarefa tarefa = db.tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tarefa tarefa = db.tarefas.Find(id);
            db.tarefas.Remove(tarefa);
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
