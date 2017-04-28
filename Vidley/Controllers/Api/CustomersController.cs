using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidley.Models;

namespace Vidley.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbcontext;
        public CustomersController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        //Get:/api/Customers to get all the customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _dbcontext.Customers.ToList();
        }

        //Get: /api/Customers/id to get customer with particular ID
        public Customer GetCustomers(int id)
        {
            var customer = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
        //Post: /api/Customers/ to save the details of a customer
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges();
            return customer;
        }
        [HttpPut]
        public void SaveCustomer(Customer customer, int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribed = customer.IsSubscribed;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _dbcontext.SaveChanges();
        }
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var CustomerInDb = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _dbcontext.Customers.Remove(CustomerInDb);
            _dbcontext.SaveChanges();
        } 

    }
}
