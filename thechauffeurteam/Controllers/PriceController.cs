using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using thechauffeurteam.DAL;
using thechauffeurteam.Models;

namespace thechauffeurteam.Controllers
{
    public class PriceController : Controller
    {
        // GET: Price
        MyContext db = new MyContext();

        //=========================== Distance Price =======================================

        public ActionResult DistancePrices()
        {
            if (Session["adminLog"] != null)
            {
                var tbl = db.DistancePrices.ToList();
                if (tbl.Count != 0)
                {
                    ViewBag.isAddDisable = tbl.OrderByDescending(m => m.Id).FirstOrDefault().MileTo;
                }
                else
                {
                    ViewBag.isAddDisable = 2515331;
                }
                return View(tbl);
            }
            return RedirectToAction("login","admin");
        }

        public ActionResult AddDistancePriceValue()
        {
            if (Session["adminLog"] != null)
            {
                int MileFrom;
                int[] MileTo;
                var obj = db.DistancePrices.ToList();


                if (obj.Count == 0)
                {
                    MileFrom = 1;
                    MileTo = new int[15];

                    int val = MileFrom;
                    for (int i = 0; i < 14; i++)
                    {
                        MileTo[i] = ++val;
                    }
                    MileTo[14] = 100000;

                }
                else
                {
                    MileFrom = db.DistancePrices.OrderByDescending(m => m.Id).FirstOrDefault().MileTo + 1;

                    if (MileFrom < 100)
                    {
                        MileTo = new int[15];

                        int val = MileFrom;
                        for (int i = 0; i < 14; i++)
                        {
                            MileTo[i] = ++val;
                        }
                        MileTo[14] = 100000;
                    }
                    else
                    {
                        MileTo = new int[49];

                        int val = MileFrom;
                        for (int i = 0; i < 49; i++)
                        {
                            MileTo[i] = ++val;
                        }
                        MileTo[49] = 100000;
                    }

                }

                ViewBag.MileTo = MileTo;
                ViewBag.MileFrom = MileFrom;


                return View();
            }
            return RedirectToAction("login","admin");
        }
        [HttpPost]
        public ActionResult AddDistancePriceValue(DistancePrice model, String MileFrom, String MileTo)
        {
            if (Session["adminLog"] != null)
            {
                model.MileFrom = Convert.ToInt32(MileFrom);
                model.MileTo = Convert.ToInt32(MileTo);

                if (!ModelState.IsValid)
                {

                    return View(model);
                }

                db.DistancePrices.Add(model);
                db.SaveChanges();
                return RedirectToAction("DistancePrices", "Price");
            }
            return RedirectToAction("login","admin");
        }
        //=========================== Hourly Price ==========================================

        public ActionResult HourlyPrice()
        {
            if (Session["adminLog"] != null)
            {
                var tbl = db.HourlyPrices.ToList();
                if (tbl.Count != 0)
                {
                    ViewBag.isAddDisable = tbl.OrderByDescending(m => m.Id).FirstOrDefault().HourTo;
                }
                else
                {
                    ViewBag.isAddDisable = 2515331;
                }
                return View(tbl);
            }
            return RedirectToAction("login", "admin");
        }

        public ActionResult AddHourlyPriceValue()
        {
            if (Session["adminLog"] != null)
            {
                int HourFrom;
                int[] HourTo;
                var obj = db.HourlyPrices.ToList();


                if (obj.Count == 0)
                {
                    HourFrom = 0;
                    HourTo = new int[15];

                    int val = HourFrom;
                    for (int i = 0; i < 15; i++)
                    {
                        HourTo[i] = ++val;
                    }

                }
                else
                {
                    HourFrom = db.HourlyPrices.OrderByDescending(m => m.Id).FirstOrDefault().HourTo + 1;

                    if (HourFrom < 100)
                    {
                        HourTo = new int[15];

                        int val = HourFrom;
                        for (int i = 0; i < 14; i++)
                        {
                            HourTo[i] = ++val;
                        }
                    }
                    else
                    {
                        HourTo = new int[49];

                        int val = HourFrom;
                        for (int i = 0; i < 49; i++)
                        {
                            HourTo[i] = ++val;
                        }
                    }

                }

                ViewBag.HourTo = HourTo;
                ViewBag.HourFrom = HourFrom;


                return View();
            }
            return RedirectToAction("login", "admin");
        }
        [HttpPost]
        public ActionResult AddHourlyPriceValue(HourlyPrice model, String HourFrom, String HourTo)
        {
            if (Session["adminLog"] != null)
            {
                model.HourFrom = Convert.ToInt32(HourFrom);
                model.HourTo = Convert.ToInt32(HourTo);

                if (!ModelState.IsValid)
                {

                    return View(model);
                }

                db.HourlyPrices.Add(model);
                db.SaveChanges();
                return RedirectToAction("HourlyPrice", "Price");
            }
            return RedirectToAction("login", "admin");
        }
        //=========================== Fix Price ==============================================
        public ActionResult FixPrices()
        {
            if (Session["adminLog"] != null)
            {
                //var tbl = db.DistancePrices.ToList();
                //if (tbl.Count != 0)
                //{
                //    ViewBag.isAddDisable = tbl.OrderByDescending(m => m.Id).FirstOrDefault().MileTo;
                //}
                //else
                //{
                //    ViewBag.isAddDisable = 2515331;
                //}

                //List<PostCode> pc = db.PostCodes.ToList();
                //ViewBag.PC = pc;
                return View(db.FixPrices.Include(a=>a.PostCode).ToList());
            }
            return RedirectToAction("login", "admin");
        }

        public ActionResult AddFixPriceValue()
        {
            if (Session["adminLog"] != null)
            {
                List<PostCode> pc = db.PostCodes.ToList();
                ViewBag.PostCode = pc;
                return View();
            }
            return RedirectToAction("login", "admin");
        }

        [HttpPost]
        public ActionResult AddFixPriceValue(FixPrice model, string PickUp, string DropOff)
        {
            if (Session["adminLog"] != null)
            {
                model.PickUp = Convert.ToInt32(PickUp);
                model.DropOff = Convert.ToInt32(DropOff);

                if (ModelState.IsValid)
                {
                    db.FixPrices.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("FixPrices", "Price");
                }
                List<PostCode> pc = db.PostCodes.ToList();
                ViewBag.PostCode = pc;
                return View(model);
            }
            return RedirectToAction("login", "admin");
        }
        

        //===========================Edit Price Value==========================================
                        
            //=======Distance===============
        public ActionResult EditDistancePrice(int Id)
        {
            if (Session["adminLog"] != null)
            {
                var obj = db.DistancePrices.ToList();

                return View(db.DistancePrices.Find(Id));
            }
            return RedirectToAction("login", "admin");
        }
        [HttpPost]
        public ActionResult EditDistancePrice(DistancePrice model)
        {
            if (Session["adminLog"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("DistancePrices");

                }
                return View(model);
            }
            return RedirectToAction("login", "admin");
        }
        

        //=======Fix Value===============
        public ActionResult EditFixPrice(int Id)
        {
            if (Session["adminLog"] != null)
            {
                var val = db.FixPrices.Find(Id);
                var pCode = db.PostCodes.ToList();
                ViewBag.PicUp = pCode.SingleOrDefault(m => m.Id == val.PickUp).PostCodeValue;
                ViewBag.DropOff = pCode.SingleOrDefault(m => m.Id == val.DropOff).PostCodeValue;


                return View(db.FixPrices.Find(Id));
            }
            return RedirectToAction("login");
        }
        [HttpPost]
        public ActionResult EditFixPrice(FixPrice model)
        {
            if (Session["adminLog"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("FixPrices");

                }
                ViewBag.PicUp = ViewBag.PicUp;
                ViewBag.DropOff = ViewBag.DropOff;

                return View(model);
            }
            return RedirectToAction("login", "admin");
        }
        
        //=======Fix Value===============

        public ActionResult EditHourlyPrice(int Id)
        {
            if (Session["adminLog"] != null)
            {
                return View(db.HourlyPrices.Find(Id));
            }
            return RedirectToAction("login", "admin");
        }
        [HttpPost]
        public ActionResult EditHourlyPrice(HourlyPrice model)
        {
            if (Session["adminLog"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("HourlyPrice");

                }
                return View(model);
            }
            return RedirectToAction("login", "admin");
        }
    }
}