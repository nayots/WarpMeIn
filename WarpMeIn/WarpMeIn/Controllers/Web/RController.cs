using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WarpMeIn.Controllers.Web
{
    [Route("r")]
    public class RController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult RedirectTo(string id)
        {
            return View();
        }
    }
}