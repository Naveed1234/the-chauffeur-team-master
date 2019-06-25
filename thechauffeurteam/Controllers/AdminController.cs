using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using thechauffeurteam.DAL;
using thechauffeurteam.Models;
using thechauffeurteam.Models.ViewModel;

namespace thechauffeurteam.Controllers
{
    public class AdminController : Controller
    {
        private MyContext db = new MyContext();
        
        // GET: Admin
        public ActionResult Index()
        {

            if (Session["adminLog"] != null)
            {
                ViewData["txt"] = "Dashboard";
                ViewBag.txt = "Dashboard";
                ViewBag.path = "/admin/index";
                var job = db.jobs.ToList();
                var jb = job.Where(m => m.status == 0).OrderByDescending(m => m.id).ToList();
                ViewBag.allJobSum = job.Count();
                ViewBag.NewJobSum = job.Where(M => M.status == 0).Count();
                ViewBag.ActiveJobSum = job.Where(M => M.status == 1).Count();
                ViewBag.FinishJobSum = job.Where(M => M.status == 2).Count();
                ViewBag.CancelJobSum = job.Where(M => M.status == 3).Count();

                return View(jb);


            }
            return RedirectToAction("login");

        }






        // Test Ajx
        
        public JsonResult SaveJobAjx(string name1, string PhoneNo1, string PName1, string date1, string times1,
            string postcodeselect1, string postcodeselect11, string From_Places1, int Doornumber1, string To_Places1, int Doorno12,
            string CarType1, string Account1, string Attribute1, string Message12)
        {
            job jb = new job();

            jb.PassengerName = name1;
            jb.PassengerPhone = PhoneNo1;
            jb.dateAndTime = date1 + " " + times1;
            jb.pickUp = From_Places1;
            jb.PdoorNumber = Doornumber1;
            jb.DropUP = To_Places1;
            jb.DdoorNumber = Doorno12;
            jb.CarType = CarType1;
            jb.Price = Account1;
            jb.Attribute = Attribute1;
            jb.Message = Message12;
            db.jobs.Add(jb);
            db.SaveChanges();
            var datalist = db.jobs.ToList();

            return Json(datalist, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ActiveJobs()
        {
            if (Session["adminLog"] != null)
            {
                ViewData["txt"] = "Jobs";
                ViewBag.txt = "Jobs";
                //ViewBag.path = "/admin/ActiveJobs";
                var job = db.jobs.ToList();
                var jb = job.Where(m => m.status == 1).OrderByDescending(m => m.id).ToList();
                ViewBag.allJobSum = job.Count();
                ViewBag.NewJobSum = job.Where(M => M.status == 0).Count();
                ViewBag.ActiveJobSum = job.Where(M => M.status == 1).Count();
                ViewBag.FinishJobSum = job.Where(M => M.status == 2).Count();
                ViewBag.CancelJobSum = job.Where(M => M.status == 3).Count();

                return View(jb);
            }
            return RedirectToAction("login");
        }
        public ActionResult CompletedJobs()
        {
            if (Session["adminLog"] != null)
            {
                ViewData["txt"] = "Jobs";
                ViewBag.txt = "Jobs";
                ViewBag.path = "/admin/CompletedJobs";
                var job = db.jobs.ToList();
                var jb = job.Where(m => m.status == 2).OrderByDescending(m => m.id).ToList();

                ViewBag.allJobSum = job.Count();
                ViewBag.NewJobSum = job.Where(M => M.status == 0).Count();
                ViewBag.ActiveJobSum = job.Where(M => M.status == 1).Count();
                ViewBag.FinishJobSum = job.Where(M => M.status == 2).Count();
                ViewBag.CancelJobSum = job.Where(M => M.status == 3).Count();

                return View(jb);
            }
            return RedirectToAction("login");
        }
        public ActionResult CanceledJobs()
        {
            if (Session["adminLog"] != null)
            {
                ViewData["txt"] = "Jobs";
                ViewBag.txt = "Jobs";
                ViewBag.path = "/admin/CanceledJobs";
                var job = db.jobs.ToList();
                var jb = job.Where(m => m.status == 3).OrderByDescending(m => m.id).ToList();

                ViewBag.allJobSum = job.Count();
                ViewBag.NewJobSum = job.Where(M => M.status == 0).Count();
                ViewBag.ActiveJobSum = job.Where(M => M.status == 1).Count();
                ViewBag.FinishJobSum = job.Where(M => M.status == 2).Count();
                ViewBag.CancelJobSum = job.Where(M => M.status == 3).Count();

                return View(jb);
            }
            return RedirectToAction("login");
        }
        public ActionResult AllJobs()
        {
            if (Session["adminLog"] != null)
            {
                ViewData["txt"] = "Jobs";
                ViewBag.txt = "Jobs";
                ViewBag.path = "/admin/AllJobs";
                var job = db.jobs.OrderByDescending(m => m.id).ToList();

                ViewBag.allJobSum = job.Count();
                ViewBag.NewJobSum = job.Where(M => M.status == 0).Count();
                ViewBag.ActiveJobSum = job.Where(M => M.status == 1).Count();
                ViewBag.FinishJobSum = job.Where(M => M.status == 2).Count();
                ViewBag.CancelJobSum = job.Where(M => M.status == 3).Count();

                return View(job);
            }
            return RedirectToAction("login");
        }

        public ActionResult Invoice()
        {
            if (Session["adminLog"] != null)
            {
                return View(db.jobs.Where(m => m.status == 2).ToList());
            }
            return RedirectToAction("login");
        }

        [HttpPost]
        public JsonResult JobInfo(int id)
        {
            //if (Session["adminLog"] != null)
            //{
            var job = db.jobs.Where(m => m.id == id).SingleOrDefault();
            var passenger = db.Passengers.Where(m => m.Id == job.PassengerId).SingleOrDefault();
            var drv = db.Drivers.Where(m => m.Status == "Approved").ToList();
            //if (job.dateAndTime.Length == 20)
            //{
            //    var dt = job.dateAndTime.Substring(11);
            //    var tm = job.dateAndTime.Substring(0, 1);
            //}
            //else
            //{

            //}
            var date = job.dateAndTime.Substring(11);
            var time = job.dateAndTime.Substring(0, 10);

            return Json(new { jb = job, pass = passenger, drivers = drv, dt = "" + date, tm = "" + time });

            //}
            //return Json("NotLoged");



        }

        





        [HttpPost]
        public JsonResult SaveJob(int Id, string PhoneNo, string PName,
                                    string Time, string DriverMessage, int Distance, string price)
        {
            var jb = db.jobs.Where(m => m.id == Id).SingleOrDefault();
            
            jb.Mile = Distance;
            jb.Price = price;
            jb.dateAndTime = Time;
            jb.DriverMessage = DriverMessage;
            jb.PassengerName = PhoneNo;
            jb.PassengerName = PName;

            db.Entry(jb).State = EntityState.Modified;

            return Json(db.SaveChanges());
        }


        [HttpPost]
        public JsonResult AllocateJob(int Id, int DriverId, string PhoneNo, string PName,
                                    string Time, string DriverMessage, int Distance, string price)
        {
            //var id = jobDtl[1];
            //jobDtl.GetLength;
            var jb = db.jobs.Where(m => m.id == Id).SingleOrDefault();
            //jb.pickUp = pickUp;
            //jb.DropUP = dropOff;
            jb.Mile = Distance;
            jb.Price = price;
            jb.dateAndTime = Time;
            jb.DriverMessage = DriverMessage;
            jb.PassengerName = PName;

            var passengerEmail = db.Passengers.Where(a => a.Id == jb.PassengerId).Select(a=>a.UserEmail).SingleOrDefault();

            var drv = db.Drivers.Where(m => m.Id == DriverId).SingleOrDefault();

            var drvdetails = db.Vehicles.Where(m => m.Id == DriverId).SingleOrDefault();

            //if (drv.DriverId == null)
            //{
                //jb.DriverName = drv.DriverName;
            //}
            //else
            //{
                jb.DriverId = drv.DriverId;
            //}
            jb.status = 1;
            //drv.Status = "Approved";

            db.Entry(jb).State = EntityState.Modified;
            db.Entry(drv).State = EntityState.Modified;

            int result=db.SaveChanges();

            // send email to driver


            string Emailbodyd = string.Empty;
            using (StreamReader readerd = new StreamReader(Server.MapPath("~/DriverEmail.html")))
            {
                Emailbodyd = readerd.ReadToEnd();
            }

            string contentIDd = "Driver123";
            string attachmentPathd = Server.MapPath("~/logo.png");
            Attachment inlined = new Attachment(attachmentPathd);
            inlined.ContentDisposition.Inline = true;
            inlined.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
            inlined.ContentId = contentIDd;
            inlined.ContentType.MediaType = "image/png";
            inlined.ContentType.Name = Path.GetFileName(attachmentPathd);

            Emailbodyd = Emailbodyd.Replace("{TimeAndDate}", jb.dateAndTime );
            Emailbodyd = Emailbodyd.Replace("{from}", jb.pickUp);
            Emailbodyd = Emailbodyd.Replace("{to}", jb.DropUP);
            Emailbodyd = Emailbodyd.Replace("{Miles}", jb.Mile.ToString());
            Emailbodyd = Emailbodyd.Replace("{price}", jb.Price.ToString());
            Emailbodyd = Emailbodyd.Replace("{phone}", jb.PassengerPhone);
            Emailbodyd = Emailbodyd.Replace("{name}", jb.PassengerName);
            Emailbodyd = Emailbodyd.Replace("{Drivername}", drv.DriverName);
            Emailbodyd = Emailbodyd.Replace("{mycontentidd}", contentIDd);

            //Emailbody = Emailbody.Replace("{img}", Convert.ToBase64String(logoImg));


            //MailMessage msgd = new MailMessage();
            //msgd.From = new MailAddress("info@thechauffeurteam.co");
            //msgd.To.Add(drv.DriverEmail);
            //msgd.Subject = "The New job allocated by The Chauffeur Team"; 
            //msgd.Body = Emailbodyd;
            //msgd.IsBodyHtml = true;
            //msgd.Attachments.Add(inlined );
            //SmtpClient smtpd = new SmtpClient("smtpout.europe.secureserver.net", 80);
            //smtpd.Credentials = new NetworkCredential("info@thechauffeurteam.co", "Asdfjkl12345");
            //smtpd.EnableSsl = false;
            //smtpd.Send(msgd);
            //smtpd.Dispose();


            // send email to passenger
            string Emailbodyp = string.Empty;
            using (StreamReader readerp = new StreamReader(Server.MapPath("~/PassengerAllocatedJob.html")))
            {
                Emailbodyp = readerp.ReadToEnd();
            }

            string contentID = "allocated123";
            string attachmentPath = Server.MapPath("~/logo.png");
            Attachment inline = new Attachment(attachmentPath);
            inline.ContentDisposition.Inline = true;
            inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
            inline.ContentId = contentID;
            inline.ContentType.MediaType = "image/png";
            inline.ContentType.Name = Path.GetFileName(attachmentPath);
            //for Driver Image

            Byte[] bitmapData = drv.DriverImage;
            System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
            string driverid = "driver11";
            var imageToInline = new LinkedResource(streamBitmap, "image/png");
            imageToInline.ContentId =driverid ;

           


            //Emailbodyp = Emailbodyp.Replace("{cartype}", jb.CarType);
            //Emailbodyp = Emailbodyp.Replace("{make}",drvdetails.Make);
            //Emailbodyp = Emailbodyp.Replace("{color}",drvdetails.Color);
            //Emailbodyp = Emailbodyp.Replace("{Registration}", drvdetails.Registration);
            //Emailbodyp = Emailbodyp.Replace("{Driverphone}", drv.phNo);
            //Emailbodyp = Emailbodyp.Replace("{Drivername}", drv.DriverName);
           
            //Emailbodyp = Emailbodyp.Replace("{PassengerName}", jb.PassengerName);
            //Emailbodyp = Emailbodyp.Replace("{mycontentid}", contentID);
            //Emailbodyp = Emailbodyp.Replace("{DriverPicture}", driverid);

            ////Emailbody = Emailbody.Replace("{img}", Convert.ToBase64String(drv.DriverImage));
            //AlternateView alternate = AlternateView.CreateAlternateViewFromString(Emailbodyp, new System.Net.Mime.ContentType("text/html"));
            //alternate.LinkedResources.Add(imageToInline);
            ////mail.AlternateViews.Add(body);

            //MailMessage msgp = new MailMessage();
            //msgp.From = new MailAddress("info@thechauffeurteam.co");
            //msgp.To.Add(passengerEmail);
            //msgp.Subject = "Your job allocated to driver of the chauffeur team "; 
            //msgp.Body = Emailbodyp;
            //msgp.IsBodyHtml = true;
            //msgp.Attachments.Add(inline);
            //msgp.AlternateViews.Add(alternate);
            //SmtpClient smtpp = new SmtpClient("smtpout.europe.secureserver.net", 80);
            //smtpp.Credentials = new NetworkCredential("info@thechauffeurteam.co", "Asdfjkl12345");
            //smtpp.EnableSsl = false;
            //smtpp.Send(msgp);
            //smtpp.Dispose();

            return Json(result);
        }

        [HttpPost]
        public JsonResult CancelJob(int JobId)
        {
            var job = db.jobs.Where(m => m.id == JobId).SingleOrDefault();
            job.status = 3;
            db.Entry(job).State = EntityState.Modified;

            return Json(db.SaveChanges());
        }
        [HttpPost]
        public JsonResult FinishJob(int JobId)
        {
            var job = db.jobs.Where(m => m.id == JobId).SingleOrDefault();
            job.status = 2;


            //if (job.DriverId != null)
            //{
            //    var drv = db.Drivers.Where(m => m.DriverId == job.DriverId).SingleOrDefault();
            //    drv.Status = "Approved";
            //    db.Entry(drv).State = EntityState.Modified;

            //}

            db.Entry(job).State = EntityState.Modified;

            return Json(db.SaveChanges());
        }



        public ActionResult login()
        {
            if (Session["adminLog"] != null)
            {
                return RedirectToAction("Index");
            }
            return View();


        }
        [HttpPost]
        public ActionResult login(string pEmail, string pPassword)
        {

            if (ModelState.IsValid)
            {
                if (pEmail.ToLower() == "admin" && pPassword == "admin1122")
                {
                    Session["adminLog"] = "logedIn";
                    return RedirectToAction("Index");
                }

            }
            return View();


        }
        public ActionResult Logout()
        {
            if (Session["adminLog"] != null)
            {
                Session["adminLog"] = null;
                Session.Remove("adminLog");
            }
            return RedirectToAction("login");
        }
        public ActionResult Driver()
        {
            if (Session["adminLog"] != null)
            {
                ViewBag.txt = "All Driver";
                ViewBag.path = "/admin/driver";

                var drv = db.Drivers.OrderByDescending(a => a.Id).ToList();

                ViewBag.allSum = drv.Count();
                ViewBag.NewSum = drv.Where(M => M.Status == "Waiting").Count();
                ViewBag.ApprovedSum = drv.Where(M => M.Status == "Approved").Count();
                ViewBag.RejectedSum = drv.Where(M => M.Status == "Rejected").Count();
                ViewBag.BusySum = drv.Where(M => M.Status == "Busy").Count();


                return View(drv);
            }
            return RedirectToAction("login");

        }
        public ActionResult NewDriver()
        {
            if (Session["adminLog"] != null)
            {
                ViewBag.txt = "New Driver";
                ViewBag.path = "/admin/driver";

                var drv = db.Drivers.OrderByDescending(a => a.Id).ToList();

                ViewBag.allSum = drv.Count();
                ViewBag.NewSum = drv.Where(M => M.Status == "Waiting").Count();
                ViewBag.ApprovedSum = drv.Where(M => M.Status == "Approved").Count();
                ViewBag.RejectedSum = drv.Where(M => M.Status == "Rejected").Count();

                return View(db.Drivers.Where(m => m.Status == "Waiting").OrderByDescending(a => a.Id).ToList());
            }
            return RedirectToAction("login");
        }
        public ActionResult ApprovedDriver()
        {
            if (Session["adminLog"] != null)
            {
                ViewBag.txt = "Approved Driver";
                ViewBag.path = "/admin/driver";

                var drv = db.Drivers.OrderByDescending(a => a.Id).ToList();

                ViewBag.allSum = drv.Count();
                ViewBag.NewSum = drv.Where(M => M.Status == "Waiting").Count();
                ViewBag.ApprovedSum = drv.Where(M => M.Status == "Approved").Count();
                ViewBag.RejectedSum = drv.Where(M => M.Status == "Rejected").Count();
                return View(db.Drivers.Where(m => m.Status == "Approved").OrderByDescending(a => a.Id).ToList());
            }
            return RedirectToAction("login");
        }
        public ActionResult RejectedDriver()
        {
            if (Session["adminLog"] != null)
            {
                ViewBag.txt = "Rejected Driver";
                ViewBag.path = "/admin/driver";

                var drv = db.Drivers.OrderByDescending(a => a.Id).ToList();

                ViewBag.allSum = drv.Count();
                ViewBag.NewSum = drv.Where(M => M.Status == "Waiting").Count();
                ViewBag.ApprovedSum = drv.Where(M => M.Status == "Approved").Count();
                ViewBag.RejectedSum = drv.Where(M => M.Status == "Rejected").Count();

                return View(db.Drivers.Where(m => m.Status == "Rejected").OrderByDescending(a => a.Id).ToList());
            }
            return RedirectToAction("login");
        }

        public ActionResult Passengers()
        {
            if (Session["adminLog"] != null)
            {
                ViewBag.txt = "Passenger";
                ViewBag.path = "/admin/passengers";
                return View(db.Passengers.OrderByDescending(a => a.Id).ToList());
            }
            return RedirectToAction("login");

        }
        public ActionResult Message()
        {
            return View();
        }



        public ActionResult DriverDetail(int id)
        {
            if (Session["adminLog"] != null)
            {
                Driver driver = db.Drivers.SingleOrDefault(m => m.Id == id);
                Vehicle vehicle = db.Vehicles.SingleOrDefault(m => m.DriverID == id);
                PCOLicense pco = db.PCOLicenses.SingleOrDefault(m => m.DriverID == id);
                UserLogin userLogin = db.UserLogins.SingleOrDefault(m => m.DriverID == id);


                DriverRegistrationViewModel model = new DriverRegistrationViewModel();

                model.DriverId = driver.DriverId;

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
                model.LeftDate = driver.LeftDate;
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
            return RedirectToAction("login");

        }

        [HttpPost]
        public ActionResult DriverDetail(DriverRegistrationViewModel model, string gender, string driverStatus)
        {
            if (Session["adminLog"] != null)
            {
                Driver driver = db.Drivers.SingleOrDefault(m => m.Id == model.Id);
                Vehicle vehicle = db.Vehicles.SingleOrDefault(m => m.DriverID == model.Id);
                PCOLicense pco = db.PCOLicenses.SingleOrDefault(m => m.DriverID == model.Id);
                UserLogin userLogin = db.UserLogins.SingleOrDefault(m => m.DriverID == model.Id);

                model.Status = driverStatus;

                if (ModelState.IsValid)
                {
                    if (Convert.ToInt32(gender) == 1)
                    {
                        driver.Gender = "Male";  //model.Gender;
                    }
                    else
                    {
                        driver.Gender = "Female";
                    }
                    {
                        driver.Status = model.Status;


                        driver.DriverId = model.DriverId;
                        driver.DriverName = model.DriverName;
                        driver.Address = model.Address;
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
                        vehicle.DriverID = model.Id;
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
                        userLogin.DriverID = model.Id;
                        userLogin.UserFirstName = model.UserFirstName;
                        userLogin.UserLastName = model.UserLastName;
                        userLogin.UserEmail = model.UserEmail;
                        userLogin.UserPhNo = model.UserPhNo;
                        userLogin.Password = model.Password;
                    }


                    db.Entry(driver).State = EntityState.Modified;
                    db.Entry(vehicle).State = EntityState.Modified;
                    db.Entry(userLogin).State = EntityState.Modified;
                    db.Entry(pco).State = EntityState.Modified;

                    db.SaveChanges();

                    return RedirectToAction("driver", "admin");
                }
                return View(model);
            }
            return RedirectToAction("login");

        }

        [HttpPost]
        public JsonResult setDriver(string sts,string id)
        {
            Driver driver = db.Drivers.SingleOrDefault(m => m.Id == Convert.ToInt32(id));
            driver.Status = sts;
            
            
            //Driver PersonalDetail
            if ( sts == "1")
            {
                TempData["msg"] = "waiting is selected";
                driver.Status = "Waiting";  //model.Gender;
            }
            if ( sts == "2")
            {
                TempData["msg"] = "waiting is Approved";
                driver.Status = "Approved";
            }
            if (sts == "3")
            {

                driver.Status = "Rejected";
            }
            if (sts =="4")
            {
                TempData["msg"] = "waiting is Busy";
                driver.Status = "Busy";
            }
            else
            {
                driver.Status = "check";
            }

            db.Entry(driver).State = EntityState.Modified;
            return Json(db.SaveChanges());
        }

        //=========================================================
        public ActionResult FileDetial()
        {
            if (Session["adminLog"] != null)
            {
                return View();
            }
            return RedirectToAction("login");
        }

        //Get data using Ajx in ront end
        [HttpGet]
        public ActionResult LoadData()
        {
            var db = new MyContext();
            var list = db.jobs.Include(j => j.passenger);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BookJob()
        {
            ViewBag.pickUpPostcode = new SelectList(db.PostCodes.ToList(), "Id", "PostCodeValue");
            ViewBag.dropOffPostcode = new SelectList(db.PostCodes.ToList(), "Id", "PostCodeValue");
            var data = db.jobs.Include(j => j.passenger).OrderByDescending(s=>s.id).ToList();

            return View(data);
        }
        public ActionResult AddDriver()
        {
            return View();
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