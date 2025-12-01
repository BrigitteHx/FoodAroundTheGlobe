using FoodAroundTheGlobe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodAroundTheGlobe.Data;
using FoodAroundTheGlobe.Models;

namespace FoodAroundTheGlobe.Pages.Shared
{
    
    public class PlattegrondModel : PageModel
    {
    private readonly ApplicationDbContext _context;
    public List<FoodStand> FoodStands { get; set; }

    public PlattegrondModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        FoodStands = _context.FoodStands.ToList();
        }

    }
}


