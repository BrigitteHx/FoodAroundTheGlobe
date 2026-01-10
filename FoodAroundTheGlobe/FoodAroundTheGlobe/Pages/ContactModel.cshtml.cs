using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodAroundTheGlobe.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactFormModel ContactForm { get; set; } = new ContactFormModel();

        public bool IsSubmitted { get; set; } = false;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
            }

            IsSubmitted = true;

            return Page();
        }
    }

    public class ContactFormModel
    {
        [Required(ErrorMessage = "Naam is verplicht.")]
        [Display(Name = "Naam")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "E-mail is verplicht.")]
        [EmailAddress(ErrorMessage = "Voer een geldig e-mailadres in.")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Bericht is verplicht.")]
        [Display(Name = "Bericht")]
        public string? Message { get; set; }
    }
}
