using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using thechauffeurteam.DAL;
using thechauffeurteam.Models;

namespace thechauffeurteam.Controllers
{
    public class TestController : Controller
    {
        MyContext db = new MyContext();
        // GET: Test

            public ActionResult scrolltableEqualAllignment()
        {
            return View();
        }
        public ActionResult ScrollTable()
        {
            return View();
        }


        public ActionResult testScrollTable()
        {
            return View();
        }


        public ActionResult LiveSearch()
        {
            return View();
        }

        public ActionResult TestRightClick()
        {
            return View();
        }

        public ActionResult GetValue()
        {
            return View();
        }

        [HttpPost]

        public ActionResult GetValue(TestClass model)
        {
            if (ModelState.IsValid)
            {
                db.TestClasses.Add(model);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = "Data is Added Succesfully";
            }
            return View();
        }

        public ActionResult indexgetvalue()
        {
            var data = db.TestClasses.ToList();
            return View(data);
        }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email")] TestClass testClass)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(testClass).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View(testClass);
        }

        public ActionResult ShowUserInfo()
        {
            var data = db.jobs.ToList();
            return View(data);
        }

        [HttpPost]
        public JsonResult EmployeeInfo(int id)
        {
            //if (Session["adminLog"] != null)
            //{
            var job = db.jobs.Where(m => m.id == id).SingleOrDefault();
            //var passenger = db.Passengers.Where(m => m.Id == job.PassengerId).SingleOrDefault();
            //var drv = db.Drivers.Where(m => m.Status == "Approved").ToList();
            ////if (job.dateAndTime.Length == 20)
            //{
            //    var dt = job.dateAndTime.Substring(11);
            //    var tm = job.dateAndTime.Substring(0, 1);
            //}
            //else
            //{

            //}
           // var date = job.dateAndTime.Substring(11);
           // var time = job.dateAndTime.Substring(0, 10);

            return Json(new { jb = job, });

            //}
            //return Json("NotLoged");
        }

        //public ActionResult EmployeeInfo(int Id)
        //{
        //    List<job> DInfo = db.jobs.Where(x => x.id == Id).ToList();
        //    return View(DInfo);
        //}


        public ActionResult popupshow()
        {
            return View();
        }


        public ActionResult Save()
        {
            return View();
        }

        // Test Ajx
        [HttpPost]
        public JsonResult SaveJobAjx(string name1, string PhoneNo1, string PName1, string date1, string times1,
            string postcodeselect1, string postcodeselect11, string From_Places1, int Doornumber1, string To_Places1, int Doorno12,
            string CarType1, string Account1, string Attribute1, string Message12)
        {
            

           
            var jb = db.jobs.Select(x => new
            {
                cName=x.PassengerName,
                CPNumber = x.PassengerPhone,
                Address = x.pickUp,
                ad1 = x.DropUP
              
            }).ToList();

            return Json(jb, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetData()
        {
            var jb = db.jobs.ToList();

            return Json(jb);
        }


    }

   


   
}