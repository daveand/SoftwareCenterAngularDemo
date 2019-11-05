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
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public String GetUsers()
        {
            var users = _context.Users.ToList();


            return JsonConvert.SerializeObject(users);
        }

        [HttpPost("[action]")]
        public String CreateUser([FromBody] UserModel user)
        {
            _context.Add(user);
            _context.SaveChangesAsync();
            return null;

        }
    }
}