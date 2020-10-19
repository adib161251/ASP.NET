using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class mployeeController : Controller
    {
        // GET: mployee
        public ActionResult CRUD()
        {
            return View();
        }
        public ActionResult GetInfo()
        {
            using(Database1Entities3 db = new Database1Entities3())
            {
                var employees = db.Emps.OrderBy(a=>a.Gender).ToList();
                return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (Database1Entities3 dc = new Database1Entities3())
            {
                var v = dc.Emps.Where(a => a.Id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Emp employee)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (Database1Entities3 dc = new Database1Entities3())
                {
                    if (employee.Id > 0)
                    {
                        //Edit 
                        var v = dc.Emps.Where(a => a.Id == employee.Id).FirstOrDefault();
                        if (v != null)
                        {
                            v.Id = employee.Id;
                            v.Gender = employee.Gender;
                            v.Department = employee.Department;
                            v.City = employee.City;
                         
                        }
                    }
                    else
                    {
                        //Save
                        dc.Emps.Add(employee);
                    }
                    dc.SaveChanges();
                    status = true;
                    return View();
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
        //for confirmation
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using(Database1Entities3 db = new Database1Entities3())
            {
                var v = db.Emps.Where(a => a.Id == id).FirstOrDefault();
                if(v != null)
                {
                   return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        //for delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;
            using (Database1Entities3 db = new Database1Entities3())
            {
                var v = db.Emps.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    db.Emps.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


    }
}