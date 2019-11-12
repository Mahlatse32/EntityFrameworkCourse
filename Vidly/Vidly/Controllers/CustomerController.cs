using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DataAccessLayer;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private VidlyContext _context;

        public CustomerController()
        {
            _context = new VidlyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        private IEnumerable<Customer> GetCustomer()
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();

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