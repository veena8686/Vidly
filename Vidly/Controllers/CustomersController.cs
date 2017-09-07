using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Create() //Customer customer)
        {
            //    _context.Customers.Add(customer);
            //   return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer) //Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            //Todo: get id data from DB: entity
            return RedirectToAction("Details", new { Id = customer.Id });
            //   return RedirectToAction("Index");
         //   return View();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();// GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}