using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Rentanime.Dtos;
using Rentanime.Models;

namespace Rentanime.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>));
        }
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id),customerDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    } 
}
