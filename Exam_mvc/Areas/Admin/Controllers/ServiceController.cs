using Exam_mvc.DAL;
using Exam_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exam_mvc.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        AppDbContext _contect;

        public ServiceController(AppDbContext contect)
        {
            _contect = contect;
        }

        public IActionResult Index()
        {
            List<Service> services = _contect.Services.ToList();
            return View(services);
        }
        public IActionResult Delete(int id)
        {
            Service service = _contect.Services.FirstOrDefault(x => x.Id == id);
            if (service != null)
            {
                _contect.Services.Remove(service);
                _contect.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (service.Photofile == null)
            {
                ModelState.AddModelError("Create", "Shekil secmemish yarada bilmezsen!!!");
                return View("Create");
            }
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            if (!service.Photofile.ContentType.Contains("image/"))
            {
                return View("Create");
            }
            if (service.Photofile.Length > 2000000)
            {
                return View();
            }
            

            string path = @"C:\Users\II novbe\Desktop\Exam\Exam_mvc\wwwroot\Upload\" + service.Photofile.FileName;
            using(FileStream stream= new FileStream(path, FileMode.Create))
            {
                service.Photofile.CopyTo(stream);
            }
            service.ImgUrl = service.Photofile.FileName;
            _contect.Services.Add(service);
            _contect.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var service = _contect.Services.FirstOrDefault(x => x.Id == id);
            return View(service);
        }
        [HttpPost]
        public IActionResult Update(Service newservice)
        {
            var oldservice=_contect.Services.FirstOrDefault(x=>x.Id == newservice.Id);
            if (!ModelState.IsValid)
            {
                return View("Update");
            }
            if (oldservice != null)
            {
                if (newservice.Photofile != null)
                {
                    if (!newservice.Photofile.ContentType.Contains("image/"))
                    {
                        return View("Create");
                    }

                    string path = @"C:\Users\II novbe\Desktop\Exam\Exam_mvc\wwwroot\Upload\" + newservice.Photofile.FileName;
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    newservice.Photofile.CopyTo(stream);
                }
                oldservice.ImgUrl = newservice.Photofile.FileName;

                }
                
                oldservice.Name=newservice.Name;
                oldservice.Description=newservice.Description;
                _contect.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(newservice);
        }
    }
}
