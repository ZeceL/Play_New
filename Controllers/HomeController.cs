using Microsoft.AspNetCore.Mvc;

namespace Play_New.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
