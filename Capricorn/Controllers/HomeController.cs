using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Capricorn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Capricorn.Cache.Redis;
using System.Threading.Tasks;
using Capricorn.Logic.Organization;

namespace Capricorn.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public async Task<IActionResult> SetCacheAsync(string setkey, string setvalue)
        {
            UserEntity user = new UserEntity();
            user.Create();
            return Content("ok");
        }
    }
}
