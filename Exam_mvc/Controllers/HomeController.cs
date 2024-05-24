using Exam_mvc.DAL;
using Exam_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam_mvc.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Service> services = _context.Services.ToList();
            return View(services);
        }

       
    }
}