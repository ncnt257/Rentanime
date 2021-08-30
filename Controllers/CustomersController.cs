using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentanime.Models;
using Rentanime.ViewModels;

namespace Rentanime.Controllers
{
    public class CustomersController : Controller
    {
       

        // GET: Customers
        public ActionResult Index()
        {

            var list = new CustomersViewModel();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var customer = new CustomersViewModel().Customers.Find(c=>c.Id==id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}