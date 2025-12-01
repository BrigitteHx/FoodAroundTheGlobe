using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodAroundTheGlobe.Data;
using FoodAroundTheGlobe.Models;

public class WorkshopPageModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public List<Workshop> Workshops { get; set; }

    public WorkshopPageModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Workshops = _context.Workshops.ToList();
    }
}



