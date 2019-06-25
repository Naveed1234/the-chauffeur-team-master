using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using thechauffeurteam.DAL;
using thechauffeurteam.Hubs;
using thechauffeurteam.Models;

namespace thechauffeurteam.Controllers
{
    public class JobBookingController : Controller
    {
        private MyContext db = new MyContext();


        public ActionResult ListJob()
        {

            ViewBag.JobList = db.jobs.ToList();
            return View();
        }


        //Get data using Ajx in ront end
        [HttpGet]
        public JsonResult LoadData()
        {
            var db = new MyContext();
            var list = db.jobs.OrderByDescending(s=>s.id).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        // Test Ajx

        public JsonResult SaveJobAjx(string name1, string PhoneNo1,string date1,string From_Places1,int Doornumber1, string To_Places1,
             int Doorno12, string CarType1, string Account1, string Attribute1,string Message12)
        {
            job jb = new job();

            jb.PassengerName = name1;
            jb.PassengerPhone = PhoneNo1;
            jb.dateAndTime = date1;
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

            //var jb1 = db.jobs.Select(x => new
            //{
            //    cName = x.PassengerName,s
            //    CPNumber = x.PassengerPhone,
            //    Address = x.pickUp,
            //    ad1 = x.DropUP

            //}).ToList();


            //return Json(alljob, JsonRequestBehavior.AllowGet);

            //  var jbs = db.jobs.OrderByDescending(s => s.id).ToList();

            //  return new JsonResult { Data = new { alljob = jbs } };
            return Json("data added");
        }




        [HttpPost]
        public ActionResult booking(string jobType, string origin, string postcode_1, string postcode_2, int? hours, string destination, string slectoption, string date, string time
            , string date2, string time2, string selectedcar, int? inMiles, string price, string driverMessage, int? passengerId, string PassengerName, 
            string PassengerPhone , int? doorno, int? doorno1, string attribute, string message)
        {




            if (ModelState.IsValid)
            {


                string PassemgerN;
                string PassengerPhoneNumber;
                string passengerEmail= "noEmail";

                //byte[] logoImg=db.Drivers.Where(a => a.Id == 2).SingleOrDefault().DriverImage;
                 

             

                job job = new job();
                if (passengerId == null)
                {
                    PassemgerN = PassengerName;
                    PassengerPhoneNumber = PassengerPhone;

                }
                else
                {
                    PassemgerN = db.Passengers.Where(a => a.Id == passengerId).Select(b => b.UserFirstName).SingleOrDefault();
                    PassengerPhoneNumber = db.Passengers.Where(a => a.Id == passengerId).Select(a => a.UserPhNo).SingleOrDefault();
                    passengerEmail = db.Passengers.Where(a => a.Id == passengerId).Select(b => b.UserEmail).SingleOrDefault();
                }


                job.JobType = jobType;
                if (string.IsNullOrEmpty(origin))
                {
                    job.pickUp = postcode_1.ToString();
                    job.DropUP = postcode_2.ToString();


                }

                else
                {
                    job.pickUp = origin;
                    job.DropUP = destination;
                }


                job.Hours = hours;
                job.dateAndTime = time + "\t" + date;
                job.CarType = selectedcar;
                job.Mile = inMiles;
                job.DriverMessage = driverMessage;
                job.Price = price;
                job.PassengerId = passengerId;
                job.PassengerName = PassemgerN;
                job.PassengerPhone = PassengerPhoneNumber;
                job.status = 0;
                job.PdoorNumber = doorno;
                job.DdoorNumber = doorno1;
                job.Attribute = attribute;
                job.Message = message;

                


                //  sending email to admin 

                string Emailbodya = string.Empty;
                using (StreamReader readera = new StreamReader(Server.MapPath("~/adminlayout.html")))
                {
                    Emailbodya = readera.ReadToEnd();
                }
                string contentID = "123";
                string attachmentPath = Server.MapPath("~/logo.png");
                Attachment inline = new Attachment(attachmentPath);
                inline.ContentDisposition.Inline = true;
                inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                inline.ContentId = contentID;
                inline.ContentType.MediaType = "image/png";
                inline.ContentType.Name = Path.GetFileName(attachmentPath);



                //message.Attachments.Add(inline);


                Emailbodya = Emailbodya.Replace("{TimeAndDate}", time + "\t" + date);
                Emailbodya = Emailbodya.Replace("{from}", origin);
                Emailbodya = Emailbodya.Replace("{to}", destination);
                Emailbodya = Emailbodya.Replace("{Miles}", inMiles.ToString());
                Emailbodya = Emailbodya.Replace("{price}", price.ToString());
                Emailbodya = Emailbodya.Replace("{phone}", PassengerPhoneNumber);
                Emailbodya = Emailbodya.Replace("{name}", PassemgerN);
                Emailbodya = Emailbodya.Replace("{mycontentid}", contentID);



                //Emailbody = Emailbody.Replace("{img}", Convert.ToBase64String(logoImg));


                //MailMessage msga = new MailMessage();
                //msga.From = new MailAddress("info@thechauffeurteam.co");
                //msga.To.Add("admin@thechauffeurteam.co");
                //msga.Subject = "New Job Booked "; 
                //msga.Body = Emailbodya;
                //msga.IsBodyHtml = true;
                //msga.Attachments.Add(inline);
                //SmtpClient smtpa = new SmtpClient("smtpout.europe.secureserver.net", 25);
                //smtpa.Credentials = new NetworkCredential("info@thechauffeurteam.co", "Asdfjkl12345");
                //smtpa.EnableSsl = false;
                //smtpa.Send(msga);
                //smtpa.Dispose();


                /// Send email to passenger

               


                
                if(passengerEmail != "noEmail")
                {
                    string Emailbodyp = string.Empty;
                    using (StreamReader readerp = new StreamReader(Server.MapPath("~/PassengCoformationWithEmail.html")))
                    {
                        Emailbodyp = readerp.ReadToEnd();
                    }
                    string contentIDp = "12356";
                    //string attachmentPathp = Environment.CurrentDirectory + @"\logo.png";
                    string attachmentPathp = Server.MapPath("~/images/logo.png");
                    Attachment inlinep = new Attachment(attachmentPathp);
                    inlinep.ContentDisposition.Inline = true;
                    inlinep.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                    inlinep.ContentId = contentIDp;
                    inlinep.ContentType.MediaType = "image/png";
                    inlinep.ContentType.Name = Path.GetFileName(attachmentPathp);


                    //Emailbodyp = Emailbodyp.Replace("{TimeAndDate}", time + "\t" + date);
                    //Emailbodyp = Emailbodyp.Replace("{from}", origin);
                    //Emailbodyp = Emailbodyp.Replace("{to}", destination);
                    //Emailbodyp = Emailbodyp.Replace("{Miles}", inMiles.ToString());
                    //Emailbodyp = Emailbodyp.Replace("{price}", price.ToString());
                    //Emailbodyp = Emailbodyp.Replace("{phone}", PassengerPhoneNumber);
                    //Emailbodyp = Emailbodyp.Replace("{name}", PassemgerN);
                    //Emailbodyp = Emailbodyp.Replace("{contentIDp}", contentIDp);
                    //MailMessage msgp = new MailMessage();
                    //msgp.From = new MailAddress("info@thechauffeurteam.co");
                    //msgp.To.Add(passengerEmail);
                    //msgp.Subject = "Job confirmation  Message of The Chauffeur Team";
                    //msgp.Body = Emailbodyp;
                    //msgp.IsBodyHtml = true;
                    //msgp.Attachments.Add(inlinep);
                    //SmtpClient smtpp = new SmtpClient("smtpout.europe.secureserver.net", 25);
                    //smtpp.Credentials = new NetworkCredential("info@thechauffeurteam.co", "Asdfjkl12345");
                    //smtpp.EnableSsl = false;
                    //smtpp.Send(msgp);
                    //smtpp.Dispose();
                }

                var context = GlobalHost.ConnectionManager.GetHubContext<AlertHub>();

                context.Clients.All.AlertMe();



                db.jobs.Add(job);
                db.SaveChanges();
              


                if (slectoption == "return")
                {

                    if (string.IsNullOrEmpty(origin))
                    {
                        job.pickUp = postcode_1;
                        job.DropUP = postcode_2;


                    }

                    else
                    {
                        job.pickUp = origin;
                        job.DropUP = destination;
                    }

                    if (passengerId == null)
                    {
                        PassemgerN = PassengerName;
                        PassengerPhoneNumber = PassengerPhone;

                    }
                    else
                    {
                        PassemgerN = db.Passengers.Where(a => a.Id == passengerId).Select(b => b.UserFirstName).SingleOrDefault();
                        PassengerPhoneNumber = db.Passengers.Where(a => a.Id == passengerId).Select(a => a.UserPhNo).SingleOrDefault();
                    }


                    job job2 = new job();
                    job2.JobType = jobType;
                    if (string.IsNullOrEmpty(origin))
                    {
                        job2.pickUp = postcode_2;
                        job2.DropUP = postcode_1;


                    }

                    else
                    {
                        job2.pickUp = destination;
                        job2.DropUP = origin;
                    }
                    job2.Hours = hours;
                    job2.dateAndTime = time2 + "\t" + date2;
                    job2.CarType = selectedcar;
                    job2.Mile = inMiles;
                    job2.DriverMessage = driverMessage;
                    job2.Price = price;
                    job2.PassengerId = passengerId;
                    job2.status = 0;
                    job2.PassengerName = PassemgerN;
                    job2.PassengerPhone = PassengerPhoneNumber;
                    db.jobs.Add(job2);
                    db.SaveChanges();

                }
                if (Session["adminLog"] != null)
                {
                    return RedirectToAction("index", "admin");
                }

                else
                {
                    return View();
                }



            }

            else
            {
                return null;


            }

        }

    }
}