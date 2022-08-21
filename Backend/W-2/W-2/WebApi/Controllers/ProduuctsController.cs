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
    public class ProductsController : ControllerBase
    {
        DgContext _Context;
        public ProductsController(DgContext context)
        {
            _Context = context;
        }
        [Authorize(Roles = "Manager,Purchasing_Department")]
        [HttpPost("Add-Produuct")]
        public void Add(Product product)
        {
            var addedEntity = _Context.Entry(product);
            addedEntity.State = EntityState.Added;
            _Context.SaveChanges();
        }
        [Authorize(Roles = "Manager,Purchasing_Department")]
        [HttpPut("Update-Product-{id}")]
        public IActionResult Update([FromBody] Product product, int id)
        {
            var _product = _Context.Products.FirstOrDefault(s => s.ProductId == id);
            if (_product != null)
            {
                _product = product;
                _Context.SaveChanges();
                return Ok("Product Updated");
            }
            return BadRequest("Product Can't Update");
        }
        [Authorize(Roles = "Manager,Purchasing_Department")]
        [HttpDelete("Delete-Product{id}")]
        public void Delete(int id)
        {
            Product product = _Context.Set<Product>().Where(s => s.ProductId == id).SingleOrDefault();
            var DelEntity = _Context.Entry(product);
            DelEntity.State = EntityState.Deleted;
            _Context.SaveChanges();
        }
        [AllowAnonymous]
        [HttpGet("getAll-Product")]
        public List<Product> GetAllEmployees()
        {

            return _Context.Set<Product>().ToList();
        }
        [AllowAnonymous]
        [HttpGet("Get-Product-By-{id}")]
        public Product Get(int id)
        {
            return _Context.Set<Product>().Where(s => s.ProductId == id).SingleOrDefault();
        }
    }
}
