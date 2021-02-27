using ControlVee.Port.InMan.DShop.Components.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ControlVee.Port.InMan.DShop.Components.Controllers
{
    public class HomeController : Controller
    {
        private readonly string cstring = @"Data Source=(localdb)\mssqllocaldb;Database=DutShop;Integrated Security=True";
        private DataAccess context;
        List<BatchModel> batches;

        public HomeController()
        {
            
        }
       
        public IActionResult Index()
        {
            batches = new List<BatchModel>();
            using (var connection = new System.Data.SqlClient.SqlConnection())
            {
                connection.ConnectionString = cstring;

                context = new DataAccess(connection);

                batches = context.GetAllBatchesFromDb();

            };

            return View(batches);
        }

        [HttpPost]
        public IActionResult CreateBatch(string data)
        {
            // TODO: Handle unterminated string exc.
            var createBatchModel = JsonConvert.DeserializeObject<CreateBatchModel>(data);

            using (var connection = new System.Data.SqlClient.SqlConnection())
            {
                connection.ConnectionString = cstring;

                context = new DataAccess(connection);

                foreach (var model in context.CreateBatchRecordFromDb(createBatchModel.nameOf, createBatchModel.total))
                {
                    batches.Add(model);
                }
            };

            return PartialView(batches);
        }
    }
}
