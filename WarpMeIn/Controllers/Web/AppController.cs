using Microsoft.AspNetCore.Mvc;
using WarpMeIn.Data.DTO;
using WarpMeIn.Core.Providers;
using WarpMeIn.Core.Utils.Contracts;
using WarpMeIn.Core.Utils;
using WarpMeIn.Data;
using WarpMeIn.Core.Factories;
using WarpMeIn.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using WarpMeIn.Models;

namespace WarpMeIn.Controllers.Web
{
    public class AppController : Controller
    {
        private WarpMeInDBContext dBContext;

        public AppController(WarpMeInDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WarpUrl(string url)
        {
            if (ModelState.IsValid)
            {
                IGenerator stringGenerator = new StringGenerator();
                IBaseConverter baseConverter = new BaseConverter();

                IdProvider idProvider = new IdProvider(stringGenerator, baseConverter, this.dBContext);
                WarpGateFactory warpGateFactory = new WarpGateFactory(idProvider);

                WarpGate warpGate = warpGateFactory.Create(url);

                this.dBContext.WarpGates.Add(warpGate);
                this.dBContext.SaveChanges();

                WarpGateDTO testDTO = new WarpGateDTO
                {
                    Url = $"https://www.warpme.in/r/{warpGate.Keyword}"
                };

                return View("Success", testDTO);
            }

            return RedirectToAction("Index");
        }
    }
}