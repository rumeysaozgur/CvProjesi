using Microsoft.AspNetCore.Mvc;

namespace cvProjesi.Controllers
{
	public class DenemeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
