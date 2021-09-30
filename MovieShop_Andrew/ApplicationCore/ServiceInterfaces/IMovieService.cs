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
        Task<IEnumerable<MovieCardResponseModel>> Get30HighestGrossingMovies();

        Task<MovieDetailsResponseModel> GetMovieDetails(int id);
    }
}
