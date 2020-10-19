using Assignment.Models;
using Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            movie mv = new movie()
            {
                Name="Injustice"
            };

            var customers = new List<Customer>()
            {
                new Customer{name="Adib Arman"},
                new Customer{name="Silicon Valle"},
                new Customer{name="Fabliha Rahman"}

            };

            var viewmodel = new RandomMovieViewModel()
            {
                Movie = mv,
                Customers = customers
            };
            return View(viewmodel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id" + id);
        }

        public ActionResult Index(int? pageIndex,string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrEmpty(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        }
    }
}