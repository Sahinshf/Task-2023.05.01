using Microsoft.AspNetCore.Mvc;
using Task.Contexts;

namespace Task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {

        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;       
        }

        public IActionResult Index()
        {

            List<Slide> slides = _context.Slides.ToList();

            return View(slides);
        }

        public IActionResult Create() {
        
            return View();  
        }

        [HttpPost]
        public IActionResult Create(Slide slide)
        {

            if (!ModelState.IsValid) // Check annotation is valid
            {
                return View();
            }

            if (slide.Offer >100)
            {
                ModelState.AddModelError("Offer", "More than 100");
                return View(); 

            }

            _context.Slides.Add(slide); // Add slide`ı to table
            _context.SaveChanges(); // Save table to Database

            return RedirectToAction(nameof(Index));
        }

    }
}
