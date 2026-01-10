using FoodAroundTheGlobe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodAroundTheGlobe.Models;

namespace FoodAroundTheGlobe.Pages
{

    public class PlattegrondModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<FoodStands> FoodStands { get; set; } = new List<FoodStands>();

        public PlattegrondModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
    }
}


