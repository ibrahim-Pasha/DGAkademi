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
    public class CategoryController : ControllerBase
    {
        DgContext _Context;
        public CategoryController(DgContext context)
        {
            _Context = context;
        }
        [Authorize(Roles = "Manager,Purchasing_Department")]
        [HttpPost("Add")]
        public void Add(Category category)
        {
            var addedEntity = _Context.Entry(category);
            addedEntity.State = EntityState.Added;
            _Context.SaveChanges();
        }
        [Authorize(Roles = "Manager,Purchasing_Department")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Category categoryName,[FromHeader] int id)
        {
            var _category = _Context.Categories.FirstOrDefault(s => s.CategoryId == id);
            if (_category != null)
            {
                _category.CategoryName = categoryName.CategoryName;
                _Context.SaveChanges();
                return Ok("Category Updated");
            }
            return BadRequest("Category Can't Update");
        }
        [Authorize(Roles = "Manager,Purchasing_Department")]
        [HttpDelete("Delete{id}")]
        public void Delete(int id)
        {
            Category category = _Context.Set<Category>().Where(s => s.CategoryId == id).SingleOrDefault();
            var DelEntity = _Context.Entry(category);
            DelEntity.State = EntityState.Deleted;
            _Context.SaveChanges();
        }
        [AllowAnonymous]
        [HttpGet("getAll")]
        public List<Category> GetAllCategories()
        {
            return _Context.Set<Category>().ToList();
        }
        [AllowAnonymous]
        [HttpGet("GetBy{id}")]
        public Category Get(int id)
        {
            return _Context.Set<Category>().Where(s => s.CategoryId == id).SingleOrDefault();
        }
    }
}
