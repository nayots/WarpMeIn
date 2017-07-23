using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarpMeIn.ViewModels;

namespace WarpMeIn.Controllers.Web
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult WarpUrl(string url)
        {
            if (ModelState.IsValid)
            {
                return Redirect($@"https://www.google.bg/{url}");
            }

            return RedirectToAction("Index");
        }
    }
}