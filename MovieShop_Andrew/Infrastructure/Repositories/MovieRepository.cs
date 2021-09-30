using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class MovieRepository : EFRepository<Movie>, IMovieRepository
    {

        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        /*
        public IEnumerable<Movie> Get30HighestGrossingMovies()
        {
            var movies = _movieShopDbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }
        */

        public async Task<IEnumerable<Movie>> Get30HighestGrossingMovies()
        {
            var movies = await _movieShopDbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }


        public override async Task<Movie> GetByIdAsync(int id)
        {
            var moviedetails = await _movieShopDbContext.Movies.Include(m => m.Genres)
                                                               .ThenInclude(m => m.Genre)
                                                               .Include(m => m.Trailers)
                                                               .FirstOrDefaultAsync(m => m.Id == id);

            if (moviedetails == null) throw new Exception($"NO Movie Found for this {id}");

            // get average rating
            var rating = await _movieShopDbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty().AverageAsync(r => r == null ? 0 : r.Rating);
            moviedetails.Rating = rating;

            return moviedetails;
        }


    }
}
