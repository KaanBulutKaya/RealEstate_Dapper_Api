using Microsoft.AspNetCore.Mvc;

namespace ReakEstate_Dapper_Ui.ViewComponents.Layout
{
    public class _HeaderViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
