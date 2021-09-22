using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    // Entity代表table,table中的columns即是class的property
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Revenue { get; set; }
        public string PosterUrl { get; set; }
    }
}
