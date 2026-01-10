using FoodAroundTheGlobe.Data;
using FoodAroundTheGlobe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace FoodAroundTheGlobe.Pages
{
    [Authorize]
    public class WorkshopModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public WorkshopModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Workshops> Workshops { get; set; } = new();
        public Dictionary<int, int> RemainingSlotsPerWorkshop { get; set; } = new();
        public int? SuccessForWorkshopId { get; set; }
        public string? ErrorMessage { get; set; }


        public void OnGet(int? successId = null, string? error = null)
        {
            try
            {
                Workshops = _context.Workshops
                    .OrderBy(w => w.Date)
                    .ToList();

                RemainingSlotsPerWorkshop = Workshops.ToDictionary(
                    w => w.Id,
                    w => CalcRemainingSlots(w.Id, w.MaxParticipants));

                SuccessForWorkshopId = successId;
                ErrorMessage = error;
            }
            catch (Exception ex)
            {
                // Tijdelijk extra logging:
                Console.WriteLine($"[Workshops OnGet] {ex.GetType().Name}: {ex.Message}");
                // Laat de melding staan voor de UI:
                ErrorMessage = "Er ging iets mis bij het ophalen van de workshops.";
                Workshops = new();
                RemainingSlotsPerWorkshop = new();
            }
        }



        public async Task<IActionResult> OnPostRegisterAsync(int workshopId)
        {
            var workshop = _context.Workshops.FirstOrDefault(w => w.Id == workshopId);
            if (workshop == null)
            {
                return RedirectToPage("/InApp/Workshop", new { error = "Workshop niet gevonden." });
            }

            // Capaciteit check
            int remaining = CalcRemainingSlots(workshop.Id, workshop.MaxParticipants);
            if (remaining <= 0)
            {
                return RedirectToPage("/InApp/Workshop", new { error = "Deze workshop zit vol." });
            }

            // Identity user ophalen
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // niet ingelogd ? naar login met returnUrl terug naar deze pagina
                var returnUrl = Url.Page("/InApp/Workshop");
                return Redirect($"/Identity/Account/Login?returnUrl={returnUrl}");
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var name = User.Identity?.Name; // of haal displayname uit claims, indien aanwezig

            // Duplicate check: per user per workshop slechts 1 inschrijving
            bool alreadyRegistered = _context.WorkshopRegistrations
                .Any(r => r.WorkshopId == workshop.Id && r.UserId == userId);

            if (alreadyRegistered)
            {
                return RedirectToPage("/InApp/Workshop", new { error = "Je bent al ingeschreven voor deze workshop." });
            }

            var reg = new WorkshopRegistrations
            {
                WorkshopId = workshop.Id,
                UserId = userId,
                ParticipantEmail = email ?? string.Empty,
                ParticipantName = name,
                RegisteredAt = DateTime.UtcNow
            };

            _context.WorkshopRegistrations.Add(reg);
            await _context.SaveChangesAsync();

            return RedirectToPage("/InApp/Workshop", new { successId = workshop.Id });
        }

        private int CalcRemainingSlots(int workshopId, int max)
        {
            int count = _context.WorkshopRegistrations.Count(r => r.WorkshopId == workshopId);
            return max <= 0 ? int.MaxValue : max - count;
        }
    }
}
