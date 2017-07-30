using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarpMeIn.ViewModels;
using WarpMeIn.Data.DTO;

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
                WarpGateDTO testDTO = new WarpGateDTO
                {
                    Url = "https://www.warpme.in/r/abcde"
                };

                return View("Success", testDTO);
            }

            return RedirectToAction("Index");
        }
    }
}