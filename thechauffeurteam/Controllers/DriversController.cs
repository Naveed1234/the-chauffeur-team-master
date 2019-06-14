using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using thechauffeurteam.DAL;
using thechauffeurteam.Models;
using thechauffeurteam.Models.ViewModel;

namespace thechauffeurteam.Controllers
{
    public class DriversController : Controller
    {
        private static int ID;
        private MyContext db = new MyContext();
        
        public ActionResult Register()
        {
            //if (Session["DriverLog"] != null)
            {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult Register(DriverRegistrationViewModel model, string gender)
        {
            //if (Session["DriverLog"] != null)
            {
                HttpPostedFileBase DriverImg = Request.Files["DrImage"];
                HttpPostedFileBase LicenseImg = Request.Files["LcImage"];
                HttpPostedFileBase CarImg = Request.Files["CrImg"];



                Driver driver = new Driver();
                PCOLicense pco = new PCOLicense();
                Vehicle vehicle = new Vehicle();
                UserLogin userLogin = new UserLogin();

                

                if (ModelState.IsValid)
                {
                    //Driver PersonalDetail
                    driver.DriverName = model.DriverName;
                    driver.Address = model.Address;
                    if (Convert.ToInt32(gender) == 1)
                    {
                        driver.Gender = "Male";  //model.Gender;
                    }
                    else
                    {
                        driver.Gender = "Female";
                    }
                    driver.Status = "Waiting";

                    driver.DateOfBirth = model.DateOfBirth;
                    driver.Nationality = model.Nationality;
                    driver.City = model.City;
                    driver.PostCode = model.PostCode;
                    driver.DriverEmail = model.DriverEmail;
                    driver.phNo = model.phNo;
                    driver.Fax = model.Fax;
                    driver.JoinDate = model.JoinDate;
                    driver.LeftDate = model.LeftDate;
                    driver.DirectCash = model.DirectCash;
                    driver.LikeAccount = model.LikeAccount;

                    //PCO Details
                    pco.NiNumber = model.NiNumber;
                    pco.DriverLicenseNo = model.DriverLicenseNo;
                    pco.IssueDate = model.IssueDate;
                    pco.ExpiryDate = model.ExpiryDate;

                    pco.PcoDriverLicenseNo = model.PcoDriverLicenseNo;
                    pco.PcoDriverLicenseIssueDate = model.PcoDriverLicenseIssueDate;
                    pco.PcoDriverLicenseExpiryDate = model.PcoDriverLicenseExpiryDate;
                    
                    pco.selfEmployed = model.selfEmployed;

                    //Vehicle Details
                    vehicle.CarType = model.CarType;
                    vehicle.CarModel = model.CarModel;
                    vehicle.Make = model.Make;
                    vehicle.Year = model.Year;

                    vehicle.Description = model.Description;
                    vehicle.Registration = model.Registration;
                    vehicle.Color = model.Color;

                    vehicle.MaxPassenger = model.MaxPassenger;
                    vehicle.MaxLuggage = model.MaxLuggage;

                    vehicle.CarLicenseNo = model.CarLicenseNo;
                    vehicle.VehicleLicenseExp = model.VehicleLicenseExp;

                    vehicle.VehicleInsurance = model.VehicleInsurance;
                    vehicle.InsuranceExpiry = model.InsuranceExpiry;

                    vehicle.MotExpire = model.MotExpire;
                    vehicle.RoadTaxExpiry = model.RoadTaxExpiry;

                    //Login account Details
                    userLogin.UserFirstName = model.UserFirstName;
                    userLogin.UserLastName = model.UserLastName;
                    userLogin.UserEmail = model.UserEmail;
                    userLogin.UserPhNo = model.UserPhNo;
                    userLogin.Password = model.Password;

                    //================Images====================================
                    driver.DriverImage = this.ConvertToBytes(DriverImg);
                    pco.LicenseImage = this.ConvertToBytes(LicenseImg);
                    vehicle.CarImage = this.ConvertToBytes(CarImg);
                    //====================================================


                    db.Drivers.Add(driver);
                    db.SaveChanges();
                    //-------setting new one driver Id---------------
                    int driverId = db.Drivers.OrderByDescending(m => m.Id).FirstOrDefault().Id;

                    vehicle.DriverID = driverId;
                    pco.DriverID = driverId;
                    userLogin.DriverID = driverId;
                    //------ adding new Records-----------------

                    db.Vehicles.Add(vehicle);
                    db.UserLogins.Add(userLogin);
                    db.PCOLicenses.Add(pco);
                    db.SaveChanges();
                    Session["Dirveruser"] = driver.DriverName;

                    Session["driverId"] = driver.Id;
                    if(Session["adminLog"] !=null)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("submit", "Drivers");
                }

                if (Session["adminLog"] != null)
                {
                   
                    return View("~/Views/Admin/AddDriver.cshtml" );


                }
                return View(model);
            }
        }

        public ActionResult submit()
        {
            return View();
        }
        public ActionResult Rejected()
        {
            
                return View();
            
        }
        //===========================================================
        public ActionResult DriverProfile(int id)
        {
            if (Session["DriverLog"] != null)
            {
                Driver driver = db.Drivers.SingleOrDefault(m => m.Id == id);
                Vehicle vehicle = db.Vehicles.SingleOrDefault(m => m.DriverID == id);
                PCOLicense pco = db.PCOLicenses.SingleOrDefault(m => m.DriverID == id);
                UserLogin userLogin = db.UserLogins.SingleOrDefault(m => m.DriverID == id);


                DriverRegistrationViewModel model = new DriverRegistrationViewModel();

                model.Id = driver.Id;
                model.DriverName = driver.DriverName;
                model.Address = driver.Address;
                model.DriverId = driver.DriverId;
                model.Status = driver.Status;
                model.Gender = driver.Gender;
                model.DateOfBirth = driver.DateOfBirth;
                model.Nationality = driver.Nationality;
                model.City = driver.City;
                model.PostCode = driver.PostCode;
                model.DriverEmail = driver.DriverEmail;
                model.phNo = driver.phNo;
                model.Fax = driver.Fax;
                model.JoinDate = driver.JoinDate;
                
                model.LeftDate = "dd/mm/yyyy";
                model.DirectCash = driver.DirectCash;
                model.LikeAccount = driver.LikeAccount;


                //PCO Details
                model.NiNumber = pco.NiNumber;
                model.DriverLicenseNo = pco.DriverLicenseNo;
                model.IssueDate = pco.IssueDate;
                model.ExpiryDate = pco.ExpiryDate;

                model.PcoDriverLicenseNo = pco.PcoDriverLicenseNo;
                model.PcoDriverLicenseIssueDate = pco.PcoDriverLicenseIssueDate;
                model.PcoDriverLicenseExpiryDate = pco.PcoDriverLicenseExpiryDate;

                model.selfEmployed = pco.selfEmployed;


                //Vehicle Details
                model.CarType = vehicle.CarType;
                model.CarModel = vehicle.CarModel;
                model.Make = vehicle.Make;
                model.Year = vehicle.Year;

                model.Description = vehicle.Description;
                model.Registration = vehicle.Registration;
                model.Color = vehicle.Color;

                model.MaxPassenger = vehicle.MaxPassenger;
                model.MaxLuggage = vehicle.MaxLuggage;

                model.CarLicenseNo = vehicle.CarLicenseNo;
                model.VehicleLicenseExp = vehicle.VehicleLicenseExp;

                model.VehicleInsurance = vehicle.VehicleInsurance;
                model.InsuranceExpiry = vehicle.InsuranceExpiry;

                model.MotExpire = vehicle.MotExpire;
                model.RoadTaxExpiry = vehicle.RoadTaxExpiry;


                //Login account Details
                model.UserFirstName = userLogin.UserFirstName;
                model.UserLastName = userLogin.UserLastName;
                model.UserEmail = userLogin.UserEmail;
                model.UserPhNo = userLogin.UserPhNo;
                model.Password = userLogin.Password;
                model.ConformPassword = userLogin.Password;


                //==========Images==========

                model.DriverImage = driver.DriverImage;
                model.LicenseImage = pco.LicenseImage;
                model.CarImage = vehicle.CarImage;
                return View(model);
            }
            return RedirectToAction("Login", "Drivers");
        }
        //===========================================================
        public JsonResult EditProfile(string Id,string fName,string lName,string phNo,string password,string confPassword)
        {
            
                int ID = Convert.ToInt32(Id);
                UserLogin prof = db.UserLogins.Where(m => m.DriverID == ID).SingleOrDefault();

                prof.UserFirstName = fName;
                prof.UserLastName = lName;
                prof.UserPhNo = phNo;
                prof.Password = password;
                db.Entry(prof).State = EntityState.Modified;
                int sts = db.SaveChanges();
                return Json(sts);
            
            
        }
        //===========================================================
        public ActionResult Login()
        {
            if (Session["DriverLog"] == null)
            {
                return View();
            }
            return RedirectToAction("Login", "Drivers", new { id = ID });
        }
        public ActionResult Loged(string demail, string dPassword)
        {
            if (Session["DriverLog"] == null)
            {
                if (!ModelState.IsValid)
                {
                    return HttpNotFound();
                }
                else
                {
                    UserLogin p = db.UserLogins.Where(a => a.UserEmail == demail && a.Password == dPassword).SingleOrDefault();


                    if (p != null)
                    {
                        Driver dr = db.Drivers.Where(m => m.Id == p.DriverID).SingleOrDefault();

                        if (dr.Status == "Approved")
                        {
                            Session["Dirveruser"] = p.UserFirstName;
                            Session["DirveruserLastName"] = p.UserLastName;

                            Session["DriverLog"] = "logedin";
                            Session["driverId"] = dr.Id;
                            ID = dr.Id;
                            return RedirectToAction("DriverProfile", "Drivers", new { id = ID });
                        }
                        if (dr.Status == "Rejected")
                        {
                            return RedirectToAction("Rejected", "Drivers");
                        }
                        else
                        {
                            return RedirectToAction("submit", "Drivers");
                        }
                    }
                    else
                    {
                        TempData["DErrormsg"] = "invalid your Email or Password";
                        return RedirectToAction("Login", "Drivers");
                    }


                }
            }
            return RedirectToAction("Login", "Drivers");
        }
        public ActionResult LogOut()
        {
            
                Session["Dirveruser"] = null;
                Session.Abandon();
                return RedirectToAction("Login", "Drivers");
           
        }
        public JsonResult CheckEmailAvailability(string duseremail)
        {
            System.Threading.Thread.Sleep(200);
            var SearchData = db.Drivers.Where(x => x.DriverEmail == duseremail).SingleOrDefault();
            if (SearchData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }
        public JsonResult CheckEmailAvailabilityDriverUser(string useremail)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = db.UserLogins.Where(x => x.UserEmail == useremail).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }

        public ActionResult Dashboard(int id)
        {
            if (Session["DriverLog"] != null)
            {
                string drivId=db.Drivers.Where(m => m.Id == id).FirstOrDefault().DriverId;
                List<job> jb = db.jobs.Where(m => m.status == 2).ToList();
                if (jb != null)
                {
                    jb = jb.Where(m => m.DriverId == drivId).ToList();
                }
                
                return View(jb);
            }
            return RedirectToAction("login");
            
        }

        public ActionResult Jobs(int id)
        {
            if (Session["DriverLog"] != null)
            {
                string drivId = db.Drivers.Where(m => m.Id == id).FirstOrDefault().DriverId;
                List<job> jb = db.jobs.Where(m => m.status == 2).ToList();
                if (jb != null)
                {
                    jb = jb.Where(m => m.DriverId == drivId).ToList();
                }

                return View(jb);
            }
            return RedirectToAction("login");

        }



        //=========================================================
        public byte[] ConvertToBytes(HttpPostedFileBase file)
        {
            byte[] fileBytes = null;
            if (file != null)
            {
                BinaryReader reader = new BinaryReader(file.InputStream);

                fileBytes = reader.ReadBytes((int)file.ContentLength);
            }
            return fileBytes;

        }

    }
}