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

        [HttpPost("Add")]
        public void Add(Employee employee)
        {
            var addedEntity = _Context.Entry(employee);
            addedEntity.State = EntityState.Added;
            _Context.SaveChanges();
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Employee employee, [FromHeader] int id)
        {
            var _employee = _Context.Employees.FirstOrDefault(s => s.EmployeeId == id);
            if (_employee != null)
            {
                _employee.Name = employee.Name;
                _employee.SurName = employee.SurName;
                _employee.Salary = employee.Salary;
                _Context.SaveChanges();
                return Ok("Employee Updated");
            }
            return BadRequest("Employee Can't Update");
        }

        [HttpDelete("Delete{id}")]
        public void Delete(int id)
        {
            Employee employee = _Context.Set<Employee>().Where(s => s.EmployeeId == id).SingleOrDefault();
            var DelEntity = _Context.Entry(employee);
            DelEntity.State = EntityState.Deleted;
            _Context.SaveChanges();
        }
        [HttpGet("getAll")]
        public List<Employee> GetAllEmployees()
        {

            return _Context.Set<Employee>().ToList();
        }
        [HttpGet("GetBy{id}")]
        public Employee Get(int id)
        {
            return _Context.Set<Employee>().Where(s => s.EmployeeId == id).SingleOrDefault();
        }
    }
}
