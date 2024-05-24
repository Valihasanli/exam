using Exam_mvc.DAL;
using Exam_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Service>services=_context.Services.ToList();
            return View(services);
        }
    }
}
