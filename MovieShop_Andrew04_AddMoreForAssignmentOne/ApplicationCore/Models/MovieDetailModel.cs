using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{



    public class MovieDetailModel
    {
        public Movie movie { get; set; }
        // public Review review { get; set; }
        public Trailer trailer { get; set; }
        public MovieCast movieCast { get; set; }
        public Cast cast { get; set; }
    }


    /*
    public class MovieDetailModel
    {
        /// For Row One =>
        // Column One:
        public int MovieId { get; set; }
        public string PosterUrl { get; set; }
        // Column Two:
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; } // from Review Table
        public string Overview { get; set; }
        // Column Three : We need to add buttons here


        /// For Row Two =>
        // Column One:
        public DateTime ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public decimal Revenue { get; set; }
        public decimal Budget { get; set; }
        public List<string> TrailerUrl { get; set; }  // from Trailer Table
        // Column Two: 
        public string TmdbUrl { get; set; } // from Cast Table
        public string CastName { get; set; }
        public string Character { get; set; } // from MovieCast Table
    }
    */
}
