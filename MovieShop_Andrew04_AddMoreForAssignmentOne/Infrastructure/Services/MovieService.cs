using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
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
        // Dependency Injection for the repository
        // Remember to register MoveRepository later in the ConfigureServices
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<MovieCardResponseModel> Get30HighestGrossingMovies()
        {


            // list of movie Entities by calling the Repositories
            var movies = _movieRepository.Get30HighestGrossingMovies();

            // mapping Entities to Models data so that services always return Models not Entities
            var moviesCardResponseModel = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                moviesCardResponseModel.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title, Revenue = movie.Revenue });
            }

            // return list of movie Models (movieresponse models)
            return moviesCardResponseModel;
        }


        public MovieDetailModel GetMovieDetails(int id)
        {
            // list of movie Entities by calling the Repositories
            MovieDetailModel moviebyid = _movieRepository.GetMovieDetails(id);
            
            // mapping Entities to Models data so that services always return Models not Entities
            // var movieDetailModel = new MovieDetailModel();
            // movieDetailModel.movie.PosterUrl = 

            /*
            movieDetailModel.PosterUrl = (string)moviebyid?.GetType().GetProperty("PosterUrl")?.GetValue(moviebyid, null);
            movieDetailModel.Title = (string)moviebyid.GetType().GetProperty("Title").GetValue(moviebyid, null);
            movieDetailModel.Revenue = Convert.ToDecimal(moviebyid?.GetType().GetProperty("Revenue")?.GetValue(moviebyid, null).ToString());
            */

            return moviebyid;
        }

        public IEnumerable<MoviesByGenreModel> GetMovieByGenre(string inputGenre)
        {
            IEnumerable<MoviesByGenreModel> moviesByGenre = _movieRepository.GetMovieByGenre(inputGenre);
            
            // mapping? 
            /*
            List<MoviesByGenreModel> result = new List<MoviesByGenreModel>();
            foreach (var abc in moviesByGenre)
            {
                result.Add(new MoviesByGenreModel
                {
                    GenreTable = (ApplicationCore.Entities.Genre)abc?.GetType().GetProperty("GenreTable")?.GetValue(abc, null),
                    MovieTable = (ApplicationCore.Entities.Movie)abc?.GetType().GetProperty("MovieTable")?.GetValue(abc, null)
                });

            };
            */

            return moviesByGenre;

        }

    }
}