using Microsoft.AspNetCore.Mvc;

namespace PetShopProject.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
