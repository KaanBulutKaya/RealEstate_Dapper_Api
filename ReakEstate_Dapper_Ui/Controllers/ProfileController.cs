using Microsoft.AspNetCore.Mvc;

namespace ReakEstate_Dapper_Ui.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
