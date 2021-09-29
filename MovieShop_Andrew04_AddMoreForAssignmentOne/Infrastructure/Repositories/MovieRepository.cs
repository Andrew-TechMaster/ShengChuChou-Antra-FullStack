using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieShopDbContext _movieShopDbContext;

        public MovieRepository(MovieShopDbContext dbContext)
        {
            _movieShopDbContext = dbContext;
        }

        public IEnumerable<Movie> Get30HighestGrossingMovies()
        {
            // go to database and get data using LINQ with EF
            var movies = _movieShopDbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }



        public MovieDetailModel GetMovieDetails(int id)
        {
            /*
            var movieDetails = _movieShopDbContext.Movies
                .Where(m => m.Id == id)
                .Join(_movieShopDbContext.Trailers, m => m.Id, t => t.MovieId,
                      (m, t) => new { MovieId = m.Id, PosterUrl = m.PosterUrl, TrailerUrl = t.TrailerUrl})
                .SingleOrDefault();
            */


            var movieDetails = (from m in _movieShopDbContext.Movies
                                    // join r in _movieShopDbContext.Reviews on m.Rating equals r.Rating
                                join t in _movieShopDbContext.Trailers on m.Id equals t.MovieId
                                join mc in _movieShopDbContext.MovieCasts on m.Id equals mc.MovieId
                                join c in _movieShopDbContext.Casts on mc.CastId equals c.Id
                                select new MovieDetailModel
                                {
                                    movie = m,
                                    trailer = t,
                                    movieCast = mc,
                                    cast = c,
                                    // review = r
                                }
                                            ).FirstOrDefault(obj => obj.movie.Id == id);

            return movieDetails;

            /*
                                    MovieId = m.Id,
                                    PosterUrl = m.PosterUrl,
                                    Title = m.Title,
                                    Rating = m.Rating,
                                    Overview = m.Overview,
                                    ReleaseDate = m.ReleaseDate,
                                    RunTime = m.RunTime,
                                    Revenue = m.Revenue,
                                    Budget = m.Budget,
                                    TrailerUrl = t.TrailerUrl,
                                    CastId = c.Id,
                                    TmdbUrl = c.TmdbUrl,
                                    CastName = c.Name,
                                    Character = mc.Character
            */
        }

        public IEnumerable<MoviesByGenreModel> GetMovieByGenre(string inputGenre)
        {
            var movies = _movieShopDbContext.Movies;
            var moviegenres = _movieShopDbContext.MovieGenres;
            var genres = _movieShopDbContext.Genres;

            var movieByGenre = (from mg in moviegenres
                                join m in movies on mg.MovieId equals m.Id
                                join g in genres on mg.GenreId equals g.Id
                                where g.Name == inputGenre
                                select new MoviesByGenreModel
                                {
                                    movieGenreTable = mg,
                                    genreTable = g,
                                    movieTable = m
                                }).ToList();
          
            return movieByGenre;
            
            /*
            _movieShopDbContext.Movies
                    .Join(_movieShopDbContext.MovieGenres, m => m.Id, mg => mg.MovieId, (m, mg) => new { m, mg })
                    .Join(_movieShopDbContext.Genres, mmg => mmg.mg.GenreId, g => g.Id, (mmg, g) => new { mmg, g })
                    .Select (new MoviesByGenreModel { MovieTable = m, MovieGenreTable = mg, GenreTable = g });
            */
        }
    }
}
