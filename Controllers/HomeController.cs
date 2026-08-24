using _241230812_NguyenThiNhung_BTThucHanh_BTVN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _241230812_NguyenThiNhung_BTThucHanh_BTVN.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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
