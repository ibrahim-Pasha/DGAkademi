using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DGDbContext;


namespace WebApi.Controllers
{
    [Authorize(Roles = "Manager,Purchasing_Department")]
    [Route("[controller]")]
    [ApiController]

    public class OrdersController : ControllerBase
    {
        DgContext _Context;
        public OrdersController(DgContext context)
        {
            _Context = context;
        }

        [HttpPost("Add-Order")]
        public void Add(Order order)
        {
            var addedEntity = _Context.Entry(order);
            addedEntity.State = EntityState.Added;
            _Context.SaveChanges();
        }

        [HttpPut("Update-Order-{id}")]
        public IActionResult Update([FromBody] Order order, int id)
        {
            var _order = _Context.Orders.FirstOrDefault(s => s.OrderId == id);
            if (_order != null)
            {
                _order = order;
                _Context.SaveChanges();
                return Ok("OrderUpdated");
            }
            return BadRequest("order Can't Update");
        }

        [HttpDelete("Delete-Order{id}")]
        public void Delete(int id)
        {
            Order order = _Context.Set<Order>().Where(s => s.OrderId == id).SingleOrDefault();
            var DelEntity = _Context.Entry(order);
            DelEntity.State = EntityState.Deleted;
            _Context.SaveChanges();
        }

        [HttpGet("getAll-Order")]
        public List<Order> GetAllEmployees()
        {

            return _Context.Set<Order>().ToList();
        }

        [HttpGet("Get-Order-By-{id}")]
        public Order Get(int id)
        {
            return _Context.Set<Order>().Where(s => s.OrderId == id).SingleOrDefault();
        }
    }
}
