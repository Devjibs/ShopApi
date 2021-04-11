using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi_Core.Models;
using ShopApi_DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        //[HttpGet]
        //public IEnumerable<Product> GetProducts()
        //{
        //    return _context.Products.ToArray();
        //}


        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToArray());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductsById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("The Id does not exist");
            }
            return Ok(product);
        }

        //[HttpGet("{categories}")]
        //public IActionResult GetProductsByCategory(string categories)
        //{
        //    var cat = _context.Products.Find(categories);
        //    return Ok(cat);
        //}
    }
}
