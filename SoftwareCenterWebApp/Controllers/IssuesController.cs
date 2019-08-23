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

        [HttpGet("[action]/{id:int}")]
        public async Task<String> GetIssueById(int id)
        {

            var issue = await _context.Issues.Include(m => m.Customer).FirstOrDefaultAsync(i => i.Id == id);

            return JsonConvert.SerializeObject(issue);
        }


        [HttpPost("[action]")]
        public async Task<String> CreateIssue([FromBody] IssueModel issue)
        {
            issue.CreatedDate = DateTime.Now;
            issue.AgreementId = 1;
            issue.ProductId = 1;
            issue.Status = "Open";

            _context.Issues.Add(issue);
            var success = await _context.SaveChangesAsync();
            return null;

        }

        [HttpPost("[action]")]
        public async Task<String> Update([FromBody] IssueModel issue)
        {

            _context.Issues.Update(issue);
            await _context.SaveChangesAsync();
            return null;

        }

        [HttpDelete("[action]/{id:int}")]
        public async Task<String> Delete(int id)
        {

            var issue = await _context.Issues.FindAsync(id);
            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
            return null;

        }



    }

}