using Microsoft.AspNetCore.Mvc;
using NutriInfo.Data;
using NutriInfo.Models;

namespace NutriInfo.Controllers
{
    public class DietListController : Controller
    {
        public readonly ApplicationDbContext _context;

        public DietListController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dietList = _context.Diets.OrderBy(c => c.Name).ToList();
            
            return View(dietList);
        }
    }
}
