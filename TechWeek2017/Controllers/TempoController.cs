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

namespace TechWeek2017.Controllers {

    public class TempoController : Controller {
        SerialPort ardo = new SerialPort("COM5", 9600);
        private Context db = new Context();

        // GET: Tempo
        public ActionResult Index() {
            var tempos = db.Tempos.Include(t=> t.Aluno).Include(t=> t.Evento).OrderBy(x => x.Time).Take(10);
            //var tempos = db.Tempos.GroupBy(t => t.AlunoId).Select(gb => new { Id = gb.Key, Time = gb.Min(t => t.Time) }).OrderBy(t => t.Time);
            return View(tempos.ToList());
        }

        // GET: Tempo/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tempo tempo = db.Tempos.Find(id);
            if (tempo == null) {
                return HttpNotFound();
            }
            return View(tempo);
        }

        // GET: Tempo/Create
        public ActionResult Create() {

            ViewBag.AlunoId = new SelectList(db.Alunos.OrderBy(a => a.Nome), "AlunoId", "Nome");
            ViewBag.EventoId = new SelectList(db.Eventos, "EventoId", "Nome");

            return View();
        }

        // POST: Tempo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TempoId,AlunoId,EventoId,Time")] Tempo tempo, string tempo1) {
            if (ModelState.IsValid) {
                var time = tempo1.Split(':');
                TimeSpan t = new TimeSpan(0, int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]), int.Parse(time[3]));


                tempo.Time = t.Ticks;
                db.Tempos.Add(tempo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.AlunoId = new SelectList(db.Alunos, "AlunoId", "Nome", tempo.AlunoId);
            ViewBag.EventoId = new SelectList(db.Eventos, "EventoId", "Nome", tempo.EventoId);
            return View(tempo);
        }

        public string LeituraSerial() {

            //ardo.PortName = "COM5";
            //ardo.BaudRate = 9600;
            string x = "E";
            try {
                if (!ardo.IsOpen)
                    ardo.Open();

                x = ardo.ReadLine();
                ardo.Close();
            } catch { }
            return x;
        }

        // GET: Tempo/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tempo tempo = db.Tempos.Find(id);
            if (tempo == null) {
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
        public ActionResult Edit([Bind(Include = "TempoId,AlunoId,EventoId,Time")] Tempo tempo) {
            if (ModelState.IsValid) {
                db.Entry(tempo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlunoId = new SelectList(db.Alunos, "AlunoId", "Nome", tempo.AlunoId);
            ViewBag.EventoId = new SelectList(db.Eventos, "EventoId", "Nome", tempo.EventoId);
            return View(tempo);
        }

        // GET: Tempo/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tempo tempo = db.Tempos.Find(id);
            if (tempo == null) {
                return HttpNotFound();
            }
            return View(tempo);
        }

        // POST: Tempo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Tempo tempo = db.Tempos.Find(id);
            db.Tempos.Remove(tempo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
