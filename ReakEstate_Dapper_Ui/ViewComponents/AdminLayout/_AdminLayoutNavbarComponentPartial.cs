﻿using Microsoft.AspNetCore.Mvc;

namespace ReakEstate_Dapper_Ui.ViewComponents.AdminLayout
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {  
            return View(); 
        }
    }
}
