using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using thechauffeurteam.DAL;
using thechauffeurteam.Models;

namespace thechauffeurteam.Controllers
{
    public class EclassesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Eclasses
        public ActionResult Index()
        {
            return View(db.eclasses.ToList());
        }

        // GET: Eclasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eclass eclass = db.eclasses.Find(id);
            if (eclass == null)
            {
                return HttpNotFound();
            }
            return View(eclass);
        }

        // GET: Eclasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eclasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstMile,PerMiles")] Eclass eclass)
        {
            if (ModelState.IsValid)
            {
                db.eclasses.Add(eclass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eclass);
        }

        // GET: Eclasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eclass eclass = db.eclasses.Find(id);
            if (eclass == null)
            {
                return HttpNotFound();
            }
            return View(eclass);
        }

        // POST: Eclasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstMile,PerMiles")] Eclass eclass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eclass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eclass);
        }

        // GET: Eclasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eclass eclass = db.eclasses.Find(id);
            if (eclass == null)
            {
                return HttpNotFound();
            }
            return View(eclass);
        }

        // POST: Eclasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eclass eclass = db.eclasses.Find(id);
            db.eclasses.Remove(eclass);
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
