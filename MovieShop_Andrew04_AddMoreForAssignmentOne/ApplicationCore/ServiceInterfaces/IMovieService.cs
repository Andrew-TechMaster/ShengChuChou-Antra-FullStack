using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        // return Models not Entities
        IEnumerable<MovieCardResponseModel> Get30HighestGrossingMovies();

        MovieDetailModel GetMovieDetails(int id);

        IEnumerable<MoviesByGenreModel> GetMovieByGenre(string inputGenre);
    }
}
