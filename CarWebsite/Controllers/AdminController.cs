using CarWebsite.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarWebsite.Models;

namespace CarWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Cars()
        {
            return View();
        }
        public IActionResult Customers()
        {
            return View();
        }
        public IActionResult RentRequest()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _context.Cars.ToList();
            return Json(cars);
        }

        [HttpPost]
        public IActionResult AddCar(Cars car, IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                var uploadPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/uploads",
                    fileName
                );

                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                car.Image_Url = "/uploads/" + fileName;
            }

            _context.Cars.Add(car);
            _context.SaveChanges();

            return Json(new { success = true });
        }

    }
}
