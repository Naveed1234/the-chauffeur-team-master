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
    public class TestClassesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: TestClasses
        public ActionResult Index()
        {
            return View(db.TestClasses.ToList());
        }

        // GET: TestClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestClass testClass = db.TestClasses.Find(id);
            if (testClass == null)
            {
                return HttpNotFound();
            }
            return View(testClass);
        }

        // GET: TestClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email")] TestClass testClass)
        {
            if (ModelState.IsValid)
            {
                db.TestClasses.Add(testClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testClass);
        }

        // GET: TestClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestClass testClass = db.TestClasses.Find(id);
            if (testClass == null)
            {
                return HttpNotFound();
            }
            return View(testClass);
        }

        // POST: TestClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email")] TestClass testClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testClass);
        }

        // GET: TestClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestClass testClass = db.TestClasses.Find(id);
            if (testClass == null)
            {
                return HttpNotFound();
            }
            return View(testClass);
        }

        // POST: TestClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestClass testClass = db.TestClasses.Find(id);
            db.TestClasses.Remove(testClass);
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
