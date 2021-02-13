using CovidDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidDetails.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GettHospitalCities()
        {
            List<City> cities = new List<City>();
            using (CovidDbEntities dc = new CovidDbEntities())
            {
                 cities = dc.Cities.OrderBy(a => a.CityName).ToList();

            }
            return new JsonResult { Data = cities, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetHospitalnames(int cityIds)
        {
            List<Hospital> hospitals = new List<Hospital>();
            using (CovidDbEntities dc = new CovidDbEntities())
            {
                 hospitals = dc.Hospitals.Where(a => a.CityId.Equals(cityIds)).OrderBy(a => a.HospitalName).ToList();

            }
            return new JsonResult { Data = hospitals, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult GetTestDetailsreport()
        {
            using(CovidDbEntities dc = new CovidDbEntities()) 
            {
                List<TestDetail> lists = dc.TestDetails.OrderBy(a => a.TestName).ToList();
                var  testdetails = lists;
                return Json(new { data = testdetails }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            using (CovidDbEntities dc = new CovidDbEntities())
            {
                var v = dc.TestDetails.Where(a => a.TestDetailsId == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(TestDetail test)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (CovidDbEntities dc = new CovidDbEntities())
                {
                    if (test.TestDetailsId > 0)
                    {
                        //Edit 
                        var v = dc.TestDetails.Where(a => a.TestDetailsId == test.TestDetailsId).FirstOrDefault();
                        if (v != null)
                        {
                            v.TestName = test.TestName;
                            v.TestDate = test.TestDate;
                            v.TestResult = test.TestResult;
                            v.TotalPrice = test.TotalPrice;
                            v.DoctorRemark = test.DoctorRemark;
                        }
                    }
                    else
                    {

                        //Save
                        dc.TestDetails.Add(test);

                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { Status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (CovidDbEntities dc = new CovidDbEntities())
            {
                var v = dc.TestDetails.Where(a => a.TestDetailsId == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
   
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;
            using (CovidDbEntities dc = new CovidDbEntities())
            {
                var v = dc.TestDetails.Where(a => a.TestDetailsId == id).FirstOrDefault();
                if (v != null)
                {
                    dc.TestDetails.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { Status = status } };
        }

    }
     
    }
     
    
