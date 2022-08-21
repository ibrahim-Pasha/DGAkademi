using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DGDbContext;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        DgContext _Context;
        public CustomerController(DgContext context)
        {
            _Context = context;
        }

        [HttpPost("Add")]
        public void Add(Customer customer)
        {
            var addedEntity = _Context.Entry(customer);
            addedEntity.State = EntityState.Added;
            _Context.SaveChanges();
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Customer customer, [FromHeader] int id)
        {
            var _customer = _Context.Customers.FirstOrDefault(s => s.CustomerId == id);
            if (_customer != null)
            {
                _customer.FullName = customer.FullName;
                _customer.UserId = customer.UserId;
                _customer.Address = customer.Address;
                _customer.PhoneNumber = customer.PhoneNumber;
                _Context.SaveChanges();
                return Ok("Customer Updated");
            }
            return BadRequest("Customer Can't Update");
        }

        [HttpDelete("Delete{id}")]
        public void Delete(int id)
        {
            Customer customer = _Context.Set<Customer>().Where(s => s.CustomerId == id).SingleOrDefault();
            var DelEntity = _Context.Entry(customer);
            DelEntity.State = EntityState.Deleted;
            _Context.SaveChanges();
        }
        [HttpGet("getAll")]
        public List<Customer> GetAllCustomers()
        {

            return _Context.Set<Customer>().ToList();
        }
        [HttpGet("GetBy{id}")]
        public Customer Get(int id)
        {
            return _Context.Set<Customer>().Where(s => s.CustomerId == id).SingleOrDefault();
        }
    }
}
