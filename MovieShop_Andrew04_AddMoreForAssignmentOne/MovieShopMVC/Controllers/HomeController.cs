using ApplicationCore.ServiceInterfaces;
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

        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        public IActionResult Index()
        {
            var movies = _movieService.Get30HighestGrossingMovies();
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Test() // for: localhost/Home/Test
        {
            return View();  // 會自動呼叫 Views (folder) 裡面的 Test.cshtml (取名需相同)
            // return View(string XXXX);  // 取名不同時,用overload method,也就是要填參數 string XXXX
        }

        /*
        public IActionResult Details(int id)
        {
            var movieService = new MovieService();
            var movieDetails = movieService.GetMovieDetails(id);
            return View(movieDetails);
        }
        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
