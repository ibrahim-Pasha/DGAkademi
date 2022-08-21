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

        [HttpPost("Add")]
        public void Add(Order order)
        {
            var addedEntity = _Context.Entry(order);
            addedEntity.State = EntityState.Added;
            _Context.SaveChanges();
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Order order,[FromHeader] int id)
        {
            var _order = _Context.Orders.FirstOrDefault(s => s.OrderId == id);
            if (_order != null)
            {
                _order.CustomerId = order.CustomerId;
                _order.ShipName = order.ShipName;
                _order.ShipAddress = order.ShipAddress;
                _order.OrderDate = order.OrderDate;
                _Context.SaveChanges();
                return Ok("OrderUpdated");
            }
            return BadRequest("order Can't Update");
        }

        [HttpDelete("Delete{id}")]
        public void Delete(int id)
        {
            Order order = _Context.Set<Order>().Where(s => s.OrderId == id).SingleOrDefault();
            var DelEntity = _Context.Entry(order);
            DelEntity.State = EntityState.Deleted;
            _Context.SaveChanges();
        }

        [HttpGet("getAll")]
        public List<Order> GetAllEmployees()
        {

            return _Context.Set<Order>().ToList();
        }

        [HttpGet("GetBy{id}")]
        public Order Get(int id)
        {
            return _Context.Set<Order>().Where(s => s.OrderId == id).SingleOrDefault();
        }
    }
}
