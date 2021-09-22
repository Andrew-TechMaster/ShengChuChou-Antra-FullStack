using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        public IEnumerable<MovieCardResponseModel> Get30HighestGrossingMovies()
        {
            MovieRepository repo = new MovieRepository();

            // list of movie entities
            var movies = repo.Get30HighestGrossingMovies();

            // mapping entities to models data so that services always return models not entities
            var moviesCardResponseModel = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                moviesCardResponseModel.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl });
            }

            return moviesCardResponseModel;
        }
    }
}
