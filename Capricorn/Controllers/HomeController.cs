using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capricorn.Models;
using Capricorn.Db.SqlServer;
using Capricorn.Logic.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Capricorn.Cache.Redis;
using StackExchange.Redis;

namespace Capricorn.Controllers
{
    public class HomeController : Controller
    {
        private DataBaseContext context;
        private readonly IDistributedCache cache;
        public HomeController(DataBaseContext _context, IDistributedCache _cache)
        {
            this.context = _context;
            this.cache = _cache;
        }
        public IActionResult SetCache(string setkey, string setvalue)
        {

            var redisConnection = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            GeoEntry[] geoEntry = new GeoEntry[] {
                new GeoEntry(120.20000, 30.26667, "hangzhou"),
                new GeoEntry(116.41667, 39.91667, "beijing"),
                new GeoEntry(121.47, 31.23, "shanghai"),
            };
            while (true)
            {
                redisConnection.GetSubscriber().Subscribe("channel_?*", (channel, message) =>
                {
                    var msg = message;//收到的消息
                    var chan = channel;//频道名称
                });
            }

            return new JsonResult(new { Code = 200, Message = "设置缓存成功"});
        }
        public IActionResult Index()
        {
            CompanyEntity entity = context.Set<CompanyEntity>().FromSql("select * from BASE_COMPANY").First();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
