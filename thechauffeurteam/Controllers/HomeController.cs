using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using thechauffeurteam.DAL;
using thechauffeurteam.Models;

namespace thechauffeurteam.Controllers
{

    public class HomeController : Controller
    {
        private MyContext db = new MyContext();
        public JsonResult CheckValidUser(string email, string password)
        {
            string result = "Fail";

            var DataItem = db.Passengers.Where(x => x.UserEmail == email && x.Password == password).SingleOrDefault();
            if (DataItem != null)
            {
                Session["user"] = DataItem.Id;
                Session["userName"] = DataItem.UserFirstName;
                //  Session["UserName"] = DataItem.UserFirstName.ToString() +"\t"+ DataItem.UserLastName.ToString();
                //  Session["phone"] = DataItem.UserPhNo.ToString();

                result = "Success";
            }
            //return Json(result, JsonRequestBehavior.AllowGet);


            return new JsonResult { Data = new { result = result, sessionId = Session["user"] } };
        }
        public ActionResult Index()
        {

            List<PostCode> p = new List<PostCode>();
            p.Add(new PostCode { Id=1,PostCodeValue="n4"});
            p.Add(new PostCode { Id = 2, PostCodeValue = "n5" });


            ViewBag.pickUpPostcode = new SelectList(p.ToList(), "Id", "PostCodeValue");
            ViewBag.dropOffPostcode = new SelectList(p.ToList(), "Id", "PostCodeValue");




            return View();
        }

        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {


            return View();
        }

        public ActionResult Booking()
        {
           
           
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }


        public ActionResult Prices()
        {
            return View();
        }

        public ActionResult Fleet()
        {
            return View();
        }

        public ActionResult NewBooking()
        {

            ViewBag.pickUpPostcode = new SelectList(db.PostCodes.ToList(), "Id", "PostCodeValue");
            ViewBag.dropOffPostcode = new SelectList(db.PostCodes.ToList(), "Id", "PostCodeValue");
            //if (Session["user"] == null && Session["Dirveruser"]==null)
            //{

            //    return RedirectToAction("Login", "Drivers");
            //}
            return View();
        }


        [HttpPost]
        public ActionResult Booking(string name, string Phone, string email, string cabType, string date, string Time, string PickUp, string DropOff, string passengers, string direction)
        {



            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("malikaamir966@gmail.com");
            msg.To.Add("Contact@justairportcar.com");
            msg.Subject = "Hi new job ! by " + "\t" + name;
            msg.Body = "Passerger Name  \t     " + "\t" + name + "\n" +
                      "Phone Number  \t       " + "\t" + Phone + "\n" +
                       "Email  \t \t  \t       " + "\t" + email + "\n" +
                       "Cab Type   \t \t    " + "\t \t" + cabType + "\n" +
                       "Date   \t\t  \t       " + "\t" + date + "\n" +
                       "Time      \t\t \t      " + "\t" + Time + "\n" +
                       "Pickup Location \t  " + "\t" + PickUp + "\n" +
                       "Drop off location \t    " + "\t" + DropOff + "\n" +
                       "Number of passengers" + "\t \t \t" + passengers + "\n" +
                       "Direction      \t\t     " + "\t" + " \t" + direction;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
            smtp.Credentials = new NetworkCredential("Contact@justairportcar.com", "Asdfjkl12345");
            smtp.EnableSsl = false;

            smtp.Send(msg);
            smtp.Dispose();


            return View();
        }

        public ActionResult test()
        {
            return View();
        }


        public JsonResult getPrice(int value, string cartype)
        {
            if (!Request.IsAjaxRequest())
            {
                return null;

            }
            else
            {
                int pricerange = db.DistancePrices.Where(p => p.MileTo >= value)
                                      .Select(p => p.MileTo).Min();

                int getRangeId = db.DistancePrices.Where(p => p.MileTo == pricerange)
                    .Select(p => p.Id).SingleOrDefault();

                string caroptions = cartype;
                int FirsMile = 0;
                int PerMile = 0;

                int totalAmount = 0;

                if (caroptions == "Saloon")
                {

                    FirsMile = Convert.ToInt32(db.DistancePrices.Where(p => p.Id == getRangeId).Select(p => p.EclassFirstMile).SingleOrDefault());
                    PerMile = Convert.ToInt32(db.DistancePrices.Where(p => p.Id == getRangeId).Select(p => p.EclassPerMile).SingleOrDefault());
                    value = value - 1;
                    totalAmount = (PerMile * value) + FirsMile;

                }
                else if (caroptions == "Estate")
                {

                    FirsMile = Convert.ToInt32(db.DistancePrices.Where(p => p.Id == getRangeId).Select(p => p.SclassFirstMile).SingleOrDefault());
                    PerMile = Convert.ToInt32(db.DistancePrices.Where(p => p.Id == getRangeId).Select(p => p.SclassPerMile).SingleOrDefault());
                    value = value - 1;
                    totalAmount = (PerMile * value) + FirsMile;

                }
                else if (caroptions == "MPV")
                {

                    FirsMile = Convert.ToInt32(db.DistancePrices.Where(p => p.Id == getRangeId).Select(p => p.VclassFirstMile).SingleOrDefault());
                    PerMile = Convert.ToInt32(db.DistancePrices.Where(p => p.Id == getRangeId).Select(p => p.VclassPerMile).SingleOrDefault());
                    value = value - 1;
                    totalAmount = (PerMile * value) + FirsMile;

                }




                return new JsonResult { Data = new { totalAmount = totalAmount } };
            }
        }


        public JsonResult getPriceByhHours(int value, string cartype)
        {
            if (!Request.IsAjaxRequest())
            {
                return null;

            }
            else
            {
                int pricerange = db.HourlyPrices.Where(p => p.HourTo >= value)
                                     .Select(p => p.HourTo).Min();

                int getRangeId = db.HourlyPrices.Where(p => p.HourTo == pricerange)
                    .Select(p => p.Id).SingleOrDefault();
                string caroptions = cartype;
                int Hours = 0;


                int totalAmount = 0;

                if (caroptions == "E_Class")
                {

                    Hours = Convert.ToInt32(db.HourlyPrices.Where(p => p.Id == getRangeId).Select(p => p.EclassPerHour).SingleOrDefault());
                    totalAmount = Hours * value;

                }
                else if (caroptions == "S_Class")
                {

                    Hours = Convert.ToInt32(db.HourlyPrices.Where(p => p.Id == getRangeId).Select(p => p.SclassPerHour).SingleOrDefault());
                    totalAmount = Hours * value;

                }
                else if (caroptions == "V_Class")
                {

                    Hours = Convert.ToInt32(db.HourlyPrices.Where(p => p.Id == getRangeId).Select(p => p.VclassPerHour).SingleOrDefault());
                    totalAmount = Hours * value;


                }




                return new JsonResult { Data = new { totalAmount = totalAmount } };
            }


        }


        public JsonResult getPriceByFlateRate(int postcode1,int postcode2, string cartype)
        {
            if (!Request.IsAjaxRequest())
            {
                return null;

            }
            else
            {
              
                int picUpPostcodeId = db.FixPrices.Where(p => p.PickUp == postcode1).Select(z => z.Id).SingleOrDefault();
                int dropOffPostcodeId=db.FixPrices.Where(p => p.DropOff == postcode2).Select(z => z.Id).SingleOrDefault();

                int findPostcodes = db.FixPrices.Where(p => p.Id == picUpPostcodeId && p.Id == dropOffPostcodeId).Select(z => z.Id).SingleOrDefault();

                int totlaAmount=0;
                string caroptions = cartype;
                
                if (findPostcodes >0)
                {
                    if (caroptions == "E_Class")
                    {
                        totlaAmount = Convert.ToInt32(db.FixPrices.Where(p => p.Id == findPostcodes).Select(s => s.Eclass).SingleOrDefault());
                    }
                    else if (caroptions == "S_Class")
                    {
                        totlaAmount = Convert.ToInt32(db.FixPrices.Where(p => p.Id == findPostcodes).Select(s => s.Sclass).SingleOrDefault());

                    }
                    else if(caroptions== "V_Class")
                    {
                        totlaAmount = Convert.ToInt32(db.FixPrices.Where(p => p.Id == findPostcodes).Select(s => s.Vclass).SingleOrDefault());



                    }
                }
               
                
                   
                
                return new JsonResult { Data=new { totalAmount = totlaAmount } };
            }
        }
    }
}