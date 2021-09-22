using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
       

        public HomeController(ILogger<HomeController> logger)
        {
           
        }

        public IActionResult Index()
        {
            // it will look inside views folder => folder name with sae name as controller name and look for the view with the same name as action method name
            // get model data (top 30 revenue)
            var movieService = new MovieService();
            var movies = movieService.Get30HighestGrossingMovies();
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Test()
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
