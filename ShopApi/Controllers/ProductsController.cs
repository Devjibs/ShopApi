using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi_Core.Models;
using ShopApi_Core.Utilities;
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
        //public async Task<IEnumerable><Product> GetProducts()
        //{
        //    return await _context.Products.ToArrayAsync();
        //}



        //Get all Products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _context.Products.ToArrayAsync());
        }



        //Get Products by page and size filtering
        [HttpGet("filterByPage")]
        public async Task<IActionResult> GetProductsByPageFilter([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<Product> products = _context.Products;

            products = products
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);
            return Ok(await products.ToArrayAsync());
        }





        //Get Products by page and size filtering
        [HttpGet("filterByPrice")]
        public async Task<IActionResult> GetProductsByPriceFilter([FromQuery] ProductsQueryParameters queryParameters)
        {
            IQueryable<Product> products = _context.Products;

            if (queryParameters.MinPrice != null && queryParameters.MaxPrice != null)
            {
                products = products.Where(p => p.Price >= queryParameters.MinPrice.Value &&
                                               p.Price <= queryParameters.MaxPrice.Value);
            }
            if (!string.IsNullOrEmpty(queryParameters.Sku))
            {
                products = products.Where(p => p.Sku == queryParameters.Sku);
            }

            products = products
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);
            return Ok(await products.ToArrayAsync());
        }






        //Get Products by Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductsById(int id)
        {
            var product = await _context.Products.FindAsync(id);
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
