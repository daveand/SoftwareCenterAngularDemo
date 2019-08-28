using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SoftwareCenterWebApp.Data;
using SoftwareCenterWebApp.Models;

namespace SoftwareCenterWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : Controller
    {
        private readonly AppDbContext _context;

        public FilesController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet("[action]")]
        public String GetFiles()
        {
            var files = _context.Files.Include(m => m.Customer).Include(m => m.User).ToList();


            return JsonConvert.SerializeObject(files);
        }

        [HttpPost("[action]")]
        public async Task<String> CreateFile([FromBody] FileModel file)
        {
            file.Uploaded = DateTime.Now;

            _context.Files.Add(file);
            var success = await _context.SaveChangesAsync();
            return null;

        }

        [HttpGet("[action]/{id}")]
        public async Task<JsonResult> DeleteFile(string id)
        {
            id = id.Replace("^", "/");

            try
            {
                var file = await _context.Files.FirstOrDefaultAsync(m => m.FilePath == id);
                _context.Files.Remove(file);
                await _context.SaveChangesAsync();
                return Json( new { success = true });

            }
            catch (Exception)
            {

                return Json(new { success = false });

            }
        }


    }
}