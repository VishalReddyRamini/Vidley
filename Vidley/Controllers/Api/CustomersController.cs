using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidley.DTOs;
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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _dbcontext.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        //Get: /api/Customers/id to get customer with particular ID
        public CustomerDTO GetCustomers(int id)
        {
            var customer = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDTO>(customer);
        }
        //Post: /api/Customers/ to save the details of a customer
        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var custDto = Mapper.Map<CustomerDTO, Customer>(customerdto);

            _dbcontext.Customers.Add(custDto);
            _dbcontext.SaveChanges();
            customerdto.Id = custDto.Id;
            return customerdto;
        }
        [HttpPut]
        public void SaveCustomer(CustomerDTO customer, int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customer, customerInDb);
            
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
