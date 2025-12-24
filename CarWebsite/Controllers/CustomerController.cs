using Microsoft.AspNetCore.Mvc;
using CarWebsite.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarWebsite.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Home()
        {
            var cars = _context.Cars.ToList();
            return View(cars);
        }

        public IActionResult Details(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);

            if (car == null)
                return NotFound();

            return View(car);
        }

        [HttpPost]
        public JsonResult SaveRent([FromBody] RentRequest rent)
        {
            DateTime newStart = rent.StartDate;
            DateTime newEnd = rent.EndDate;

            var existing = _context.Set<RentRequest>()
                                   .Where(r => r.Car_Id == rent.Car_Id)
                                   .ToList();

            foreach (var old in existing)
            {
                DateTime oldStart = old.StartDate;
                DateTime oldEnd = old.EndDate;

                bool overlaps = newStart <= oldEnd && newEnd >= oldStart;

                if (overlaps)
                {
                    return Json(new
                    {
                        success = false,
                        message = $"This car is already booked from {oldStart:yyyy-MM-dd} to {oldEnd:yyyy-MM-dd}. Please choose another date."
                    });
                }
            }
 
            _context.Set<RentRequest>().Add(rent);
            _context.SaveChanges();

            return Json(new { success = true });
        }


    }
}
