using FoodAroundTheGlobe.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodAroundTheGlobe.Models;
using System.Linq;

namespace FoodAroundTheGlobe.Pages
{
    public class PlattegrondModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<FoodStands> FoodStands { get; set; } = new();

        public PlattegrondModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
           
        }
    }
}


