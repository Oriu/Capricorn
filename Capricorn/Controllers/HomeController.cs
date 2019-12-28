using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Capricorn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Capricorn.Cache.Redis;
using System.Threading.Tasks;

namespace Capricorn.Controllers
{
    public class HomeController : Controller
    {
        private RedisCache redisCache = new RedisCache();
        public HomeController()
        {
        }
        public async Task<IActionResult> SetCacheAsync(string setkey, string setvalue)
        {
            await redisCache.SetStringAsync("13123","213123");
            return Content("ok");
        }
    }
}
