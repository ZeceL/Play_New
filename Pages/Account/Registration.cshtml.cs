using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Play_New.data;
using Play_New.data.Models;
using BCrypt.Net;

namespace Play_New.Pages.Account
{
    public class RegistrationModel : PageModel
    {
        private readonly AppDbContext _context;

        public RegistrationModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User NewUser { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Hash the password before saving (optional, but recommended)
            NewUser.Password = BCrypt.Net.BCrypt.HashPassword(NewUser.Password);

            _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();

            // Redirect to the login page after successful registration
            return RedirectToPage("/Account/Login");
        }
    }
}
