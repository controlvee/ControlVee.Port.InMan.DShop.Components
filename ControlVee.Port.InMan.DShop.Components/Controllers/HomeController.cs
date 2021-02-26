using ControlVee.Port.InMan.DShop.Components.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ControlVee.Port.InMan.DShop.Components.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateBatchRecord()
        {
            

            List<string> names = new List<string>()
            {
                "Classic G",
                "Emma Nom",
                "Sugar High",
                "Shred Tha Gnar",
                "Bacon"
            };

            var randomNameIndex = new Random().Next(names.Count);
            var randomTotal = new Random().Next(6, 24);

            var batch = new BatchModel()
            {
                ID = Guid.NewGuid(),
                NameOf = names[randomNameIndex],
                Started = DateTime.Now,
                Total = randomTotal
            };

            return PartialView("_Batch", batch);
        }
    }
}
