using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        // Repository Should Return Entities
        // IEnumerable<Movie> Get30HighestGrossingMovies();
        // SELECT TOP 30 * FROM Movie ORDER BY Revenue

        Task<IEnumerable<Movie>> Get30HighestGrossingMovies();

    }
}
