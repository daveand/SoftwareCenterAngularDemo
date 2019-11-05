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
    public class KnowledgesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KnowledgesController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet("[action]")]
        public String GetKnowledges()
        {
            var knowledges = _context.Knowledges.Include(m => m.Customer).Include(m => m.User).Include(m => m.Product).ToList();


            return JsonConvert.SerializeObject(knowledges);
        }

        [HttpGet("[action]/{id:int}")]
        public async Task<String> GetKnowledgeById(int id)
        {

            var knowledge = await _context.Knowledges.Include(m => m.Customer).Include(m => m.User).Include(m => m.Product).FirstOrDefaultAsync(i => i.Id == id);

            return JsonConvert.SerializeObject(knowledge);
        }


        [HttpPost("[action]")]
        public async Task<String> CreateKnowledge([FromBody] KnowledgeModel knowledge)
        {
            knowledge.CreatedDate = DateTime.Now;
            knowledge.AgreementId = 1;

            _context.Knowledges.Add(knowledge);
            var success = await _context.SaveChangesAsync();
            return null;

        }

        [HttpPost("[action]")]
        public async Task<String> Update([FromBody] KnowledgeModel knowledge)
        {

            _context.Knowledges.Update(knowledge);
            await _context.SaveChangesAsync();
            return null;

        }

        [HttpDelete("[action]/{id:int}")]
        public async Task<String> Delete(int id)
        {

            var knowledge = await _context.Knowledges.FindAsync(id);
            _context.Knowledges.Remove(knowledge);
            await _context.SaveChangesAsync();
            return null;

        }



    }

}