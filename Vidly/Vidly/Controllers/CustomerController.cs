using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private IEnumerable<Customer> GetCustomer()
        {
            var customer = new List<Customer>
            {
                new Customer{ Id = 1, Name = "John Smith"},
                new Customer{ Id = 2, Name = "Danny Wild"}
            };

            return customer;
        }

        public ActionResult CustomerIndex()
        {
            return View(GetCustomer());
        }

        public ActionResult CustomerInfo(int id)
        {
            var customer = GetCustomer().SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}