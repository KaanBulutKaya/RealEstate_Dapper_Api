using Microsoft.AspNetCore.Mvc;

namespace ReakEstate_Dapper_Ui.ViewComponents.HomePage
{
    public class _DefaultScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
