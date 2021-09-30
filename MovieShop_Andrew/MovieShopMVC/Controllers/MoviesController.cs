using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        

        // readonly type only could be modified in constructor
        private readonly IMovieService _movieService;   // remeber add "readonly" keyworld since we don't want others to _movieService = new... in other place
        public MoviesController(IMovieService movieService) // Constructor Injection
        {
            _movieService = movieService;
        }


        public IActionResult GetTopRevenueMovies()
        {
            
            var movies = _movieService.Get30HighestGrossingMovies();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            return View(movie);
        }

        /*
        public IActionResult Genre(string inputGenre)
        {
            var movies = _movieService.GetMovieByGenre(inputGenre);
            return View(movies);
        }
        */
    }
}
