using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using SoftwareCenterWebApp.Models;
using MongoDB.Entities;
using SoftwareCenterWebApp.Data;

namespace SoftwareCenterWebApp.Controllers
{

    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IssuesController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet("[action]")]
        public String Issues()
        {
            var issues = _context.Issues.ToList();
            

            return JsonConvert.SerializeObject(issues);
        }

    }

}