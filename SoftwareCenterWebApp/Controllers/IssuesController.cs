using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using SoftwareCenterWebApp.Data;
using SoftwareCenterWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public String GetIssues()
        {
            var issues = _context.Issues.Include(m => m.Customer).ToList();


            return JsonConvert.SerializeObject(issues);
        }

        [HttpPost("[action]")]
        public String CreateIssue([FromBody] IssueModel issue)
        {
            issue.CreatedDate = DateTime.Now;
            issue.AgreementId = 1;
            issue.ProductId = 1;
            issue.Status = "Open";

            _context.Add(issue);
            _context.SaveChangesAsync();
            return null;

        }

        [HttpDelete("[action]/{id:int}")]
        public String Delete(int id)
        {

            var issue = _context.Issues.Find(id);
            _context.Issues.Remove(issue);
            _context.SaveChangesAsync();
            return null;

        }



    }

}