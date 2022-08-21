using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager,Purchasing_Department,Ik")]
    public class EmployeeController : ControllerBase
    {
        DgContext _Context;
        public EmployeeController(DgContext context)
        {
            _Context = context;
        }

        [HttpPost("Add-Employee")]
        public void Add(Employee employee)
        {
            var addedEntity = _Context.Entry(employee);
            addedEntity.State = EntityState.Added;
            _Context.SaveChanges();
        }

        [HttpPut("Update-Employee-{id}")]
        public IActionResult Update([FromBody] Employee employee, int id)
        {
            var _employee = _Context.Employees.FirstOrDefault(s => s.EmployeeId == id);
            if (_employee != null)
            {
                _employee = employee;
                _Context.SaveChanges();
                return Ok("Employee Updated");
            }
            return BadRequest("Employee Can't Update");
        }

        [HttpDelete("Delete-Employee{id}")]
        public void Delete(int id)
        {
            Employee employee = _Context.Set<Employee>().Where(s => s.EmployeeId == id).SingleOrDefault();
            var DelEntity = _Context.Entry(employee);
            DelEntity.State = EntityState.Deleted;
            _Context.SaveChanges();
        }
        [HttpGet("getAll-Employee")]
        public List<Employee> GetAllEmployees()
        {

            return _Context.Set<Employee>().ToList();
        }
        [HttpGet("Get-Employee-By-{id}")]
        public Employee Get(int id)
        {
            return _Context.Set<Employee>().Where(s => s.EmployeeId == id).SingleOrDefault();
        }
    }
}
