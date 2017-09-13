using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechWeek2017.Models;

namespace TechWeek2017.Controllers
{
    public class TempoController : Controller
    {
        private Context db = new Context();

        // GET: Tempo
        public ActionResult Index()
        {
            var tempos = db.Tempos.Include(t => t.Aluno).Include(t => t.Evento).OrderBy(t=>t.Time).Take(1);
            return View(tempos.ToList());
        }

        // GET: Tempo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tempo tempo = db.Tempos.Find(id);
            if (tempo == null)
            {
                return HttpNotFound();
            }
            return View(tempo);
        }

        // GET: Tempo/Create
        public ActionResult Create()
        {
            
            ViewBag.AlunoId = new SelectList(db.Alunos, "AlunoId", "Nome");
            ViewBag.EventoId = new SelectList(db.Eventos, "EventoId", "Nome");
            
            return View();
        }

        // POST: Tempo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TempoId,AlunoId,EventoId,Time")] Tempo tempo, string time)
        {
            if (ModelState.IsValid)
            {
                db.Tempos.Add(tempo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoId = new SelectList(db.Alunos, "AlunoId", "Nome", tempo.AlunoId);
            ViewBag.EventoId = new SelectList(db.Eventos, "EventoId", "Nome", tempo.EventoId);
            return View(tempo);
        }

        // GET: Tempo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tempo tempo = db.Tempos.Find(id);
            if (tempo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoId = new SelectList(db.Alunos, "AlunoId", "Nome", tempo.AlunoId);
            ViewBag.EventoId = new SelectList(db.Eventos, "EventoId", "Nome", tempo.EventoId);
            return View(tempo);
        }

        // POST: Tempo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TempoId,AlunoId,EventoId,Time")] Tempo tempo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlunoId = new SelectList(db.Alunos, "AlunoId", "Nome", tempo.AlunoId);
            ViewBag.EventoId = new SelectList(db.Eventos, "EventoId", "Nome", tempo.EventoId);
            return View(tempo);
        }

        // GET: Tempo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tempo tempo = db.Tempos.Find(id);
            if (tempo == null)
            {
                return HttpNotFound();
            }
            return View(tempo);
        }

        // POST: Tempo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tempo tempo = db.Tempos.Find(id);
            db.Tempos.Remove(tempo);
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
