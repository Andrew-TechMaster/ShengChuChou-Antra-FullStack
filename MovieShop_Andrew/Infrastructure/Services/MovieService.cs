using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using OpenQA.Selenium;
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

        public async Task<IEnumerable<MovieCardResponseModel>> Get30HighestGrossingMovies()
        {


            // list of movie Entities by calling the Repositories
            var movies = await _movieRepository.Get30HighestGrossingMovies();

            // mapping Entities to Models data so that services always return Models not Entities
            var moviesCardResponseModel = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                moviesCardResponseModel.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title, Revenue = movie.Revenue });
            }

            // return list of movie Models (movieresponse models)
            return moviesCardResponseModel;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var movieDetails = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Rating = movie.Rating,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Price = movie.Price,

            };


            movieDetails.Genres = new List<GenreModel>();
            foreach (var movieGenre in movie.Genres)
            {
                movieDetails.Genres.Add(new GenreModel
                {
                    Id = movieGenre.GenreId,
                    Name = movieGenre.Genre.Name
                });
            };


            movieDetails.Casts = new List<CastModel>();
            if (movie.Casts != null)
            {
            
                foreach (var movieCast in movie.Casts)
                {
                    movieDetails.Casts.Add(new CastModel
                    {
                        Id = movieCast.Cast.Id,
                        Name = movieCast.Cast.Name,
                        Character = movieCast.Character,
                        Gender = movieCast.Cast.Gender,
                        ProfilePath = movieCast.Cast.ProfilePath,
                        TmdbUrl = movieCast.Cast.TmdbUrl
                    });
                };
            };



            movieDetails.Trailers = new List<TrailerModel>();
            foreach (var trailer in movie.Trailers)
            {
                movieDetails.Trailers.Add(new TrailerModel
                {
                    Id = trailer.Id,
                    Name = trailer.Name,
                    TrailerUrl = trailer.TrailerUrl,
                    MovieId = trailer.MovieId
                });
            };



            return movieDetails;
        }
    }
}