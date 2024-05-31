using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Play_New.data;
using Play_New.data.models;

namespace Play_New.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (model != null)
            {
                Console.WriteLine($"Received data - Username: {model.Username}, Password: {model.Password}");
            }
            else
            {
                Console.WriteLine("Model is null");
            }

            if (ModelState.IsValid)
            {
                // Найти пользователя по имени пользователя
                var user = await _context.Users
                    .SingleOrDefaultAsync(u => u.Login == model.Username);

                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                {
					// Успешная авторизация, можно создать сессию, куки и т.д.
					// Пример: HttpContext.Session.SetString("UserId", user.Id_User.ToString());
					Console.WriteLine("User authenticated successfully.");
					return RedirectToAction("Index", "Home");
                }
                else
                {
					Console.WriteLine("Authentication failed: incorrect username or password.");
					ModelState.AddModelError("", "Неправильное имя пользователя или пароль");
                }
                
            }
			else
			{
				Console.WriteLine("Model validation failed.");
				foreach (var error in ModelState)
				{
					Console.WriteLine($"Key: {error.Key}, Error: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
				}
			}
			return View(model);
        }
    }
}
