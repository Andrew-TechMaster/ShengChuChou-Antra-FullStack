using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    // we use data annotations for changing our Database constraints
    // Fluent API can also put constraints on the database, it is more powerful (下一堂課)
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        public ICollection<MovieGenre> Movies { get; set; }  // navigation property 
    }
}
