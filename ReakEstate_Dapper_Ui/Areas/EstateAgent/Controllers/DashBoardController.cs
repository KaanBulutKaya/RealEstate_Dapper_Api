using Microsoft.AspNetCore.Mvc;

namespace ReakEstate_Dapper_Ui.Areas.EstateAgent.Controllers
{
    public class DashBoardController : Controller
    {
        [Area("EstateAgent")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
