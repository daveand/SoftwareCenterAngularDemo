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
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public String GetCustomers()
        {
            var customers = _context.Customers.ToList();


            return JsonConvert.SerializeObject(customers);
        }

        [HttpPost("[action]")]
        public async Task<String> CreateCustomer([FromBody] CustomerModel customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return null;

        }

        [HttpDelete("[action]/{id:int}")]
        public async Task<String> Delete(int id)
        {

            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return null;

        }

    }
}