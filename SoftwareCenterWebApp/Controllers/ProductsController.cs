using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoftwareCenterWebApp.Data;
using SoftwareCenterWebApp.Models;

namespace SoftwareCenterWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public String GetProducts()
        {
            var products = _context.Products.ToList();


            return JsonConvert.SerializeObject(products);
        }

        [HttpPost("[action]")]
        public async Task<String> CreateProduct([FromBody] ProductModel product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return null;

        }


    }
}