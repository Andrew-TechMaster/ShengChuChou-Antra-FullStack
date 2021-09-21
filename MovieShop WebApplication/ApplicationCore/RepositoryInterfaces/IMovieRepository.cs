using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get30HighestGrossingMovies();
        // SELECT TOP 30 * FROM Movie ORDER BY Revenue
    }
}
