using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using thechauffeurteam.DAL;
using thechauffeurteam.Models;
using thechauffeurteam.Models.ViewModel;

namespace thechauffeurteam.Controllers
{
    public class PassengersController : Controller
    {
        private MyContext db = new MyContext();
        // GET: Passengers
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(PassengerRegistration model)
        {
            Passenger passenger = new Passenger();
            passenger.UserFirstName = model.UserFirstName;
            passenger.UserLastName = model.UserLastName;
            passenger.UserEmail = model.UserEmail;
            passenger.UserPhNo = model.UserPhNo;
            passenger.Password = model.Password;

            if(!ModelState.IsValid)
            {
                
                return View(model);
            }
            db.Passengers.Add(passenger);
            db.SaveChanges();

            Session["user"] = passenger.Id;
            Session["userName"] = passenger.UserFirstName;
            return RedirectToAction("Index", "Home");


        }
        
        public ActionResult Loged(string pEmail , string pPassword)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();

            }
            else
            {
                var p = db.Passengers.Where(a => a.UserEmail == pEmail && a.Password ==pPassword).SingleOrDefault();
                if (p != null)
                {
                    Session["user"] = p.Id;
                    Session["userName"] = p.UserFirstName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Errormsg"] = "invalid your Email or Password";
                    return RedirectToAction("Login", "Drivers");

                }

            }
        }

        public ActionResult LogOut()
        {
            Session["user"] = null;
            Session.Abandon();
            return RedirectToAction("Login","Drivers");
        }


        public JsonResult CheckEmailAvailability( string useremail)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = db.Passengers.Where(x => x.UserEmail == useremail).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }

    }
}