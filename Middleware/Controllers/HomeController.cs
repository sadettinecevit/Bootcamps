using Dapper;
using Microsoft.AspNetCore.Mvc;
using Middleware.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Middleware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=myDataBase;Trusted_Connection=True;";
            using SqlConnection conn = new SqlConnection(ConnectionString);
            //C# 9 - 10'daki kısa kullanımlara bak.

            conn.Open();
            conn.Query("");

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