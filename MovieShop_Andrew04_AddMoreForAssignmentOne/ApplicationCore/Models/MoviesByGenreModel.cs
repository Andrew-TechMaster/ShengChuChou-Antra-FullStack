using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class MoviesByGenreModel
    {
        public Movie movieTable { get; set; }
        public MovieGenre movieGenreTable { get; set; }
        public Genre genreTable { get; set; }
    }
}
