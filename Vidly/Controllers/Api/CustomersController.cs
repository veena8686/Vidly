﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>));
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                //  throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
        //[HttpPost]
        //public CustomerDto CreateCustomer(CustomerDto customerDto) // PostCustomer then no attribute
        //{
        //    if(!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();

        //    customerDto.Id = customer.Id;

        //    return customerDto;
        //}

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) // PostCustomer then no attribute
        {
            if (!ModelState.IsValid)
                return BadRequest();
              //  throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            // /api/customer/10
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT  /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            //customerInDb.Name = customerDto.Name; // or use automapper
            //customerInDb.DateOfBirth = customerDto.DateOfBirth;
            //customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

            _context.SaveChanges();
            return Ok();
        }
        
        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
