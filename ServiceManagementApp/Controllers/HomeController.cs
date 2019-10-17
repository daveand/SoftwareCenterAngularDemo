using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagementApp.Models;
using ServiceManagementApp.Models.ViewModels;

namespace ServiceManagementApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SoftwareCenterWebAppDbContext _context;

        public HomeController(SoftwareCenterWebAppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var claims = ((ClaimsIdentity)User.Identity).Claims;
            var group = claims.First(c => c.Type == "groups").Value;
            string email;

            string pattern = @"#(.*)";
            Match match = Regex.Match(User.Identity.Name, pattern);

            if (match.Success)
            {
                email = match.Groups[1].Value;
            }
            else
            {
                email = User.Identity.Name;
            }

            var users = _context.Users;

            Users user = new Users
            {
                Name = claims.First(c => c.Type == "name").Value,
                Email = email,
                Group = group.ToString()
            };

            if (!users.Any(u => u.Email == email))
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            var userIssues = GetUserIssues(user);

            return View(new DashboardViewModel { Issues = userIssues });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<Issues> GetUserIssues(Users user)
        {
            var userIssues = _context.Issues
                .Where(i => i.User.Email == user.Email && i.Status != "Closed")
                .Include(c => c.Customer)
                .ToList();
            return userIssues;
        }

    }
}
