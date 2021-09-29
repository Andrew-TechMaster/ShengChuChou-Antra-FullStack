using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; } // Foreign Key
                                         // Movie + Id
                                         // (EntityPart) + (Property)
                                         // EF smart enough to automatically build Foreign Key for us  


        public Movie Movie { get; set; } // Navigation Property
        // return type is Move (not ICollection) is because one trailer belongs to one movie: one to one relationship
    }
}
