using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using Vidley.ViewModels;
using System.Data.Entity;
namespace Vidley.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(s=>s.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(s => s.MembershipType).FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewViewModel
                {
                    customer = customer,
                    membershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var cust = _context.Customers.Single(m => m.Id == customer.Id);
                cust.Name = customer.Name;
                cust.BirthDate = customer.BirthDate;
                cust.IsSubscribed = customer.IsSubscribed;
                cust.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
       
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new NewViewModel
            {
                customer= new Customer(),
                membershipTypes = membershipType
            };
            return View(viewModel);
        } 
        [HttpGet]
        public ActionResult Edit (int id)
        {
            var cust = _context.Customers.SingleOrDefault(c => c.Id==id);
            if (cust == null)
                return HttpNotFound();
            var viewModel = new NewViewModel
            {
                customer = cust,
                membershipTypes=_context.MembershipTypes.ToList()
            };
            return View("New",viewModel);
        }
         public ActionResult Delete(int id)
        {
            var cust = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cust == null)
                return HttpNotFound();
            var viewModel = new NewViewModel
            {
                customer = cust,
                membershipTypes = _context.MembershipTypes.ToList()
            };
            return View(viewModel);
        }
        public ActionResult remove(int id)
        {
            var cust = _context.Customers.Single(c => c.Id == id);
            if (cust == null)
                return HttpNotFound();
            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}