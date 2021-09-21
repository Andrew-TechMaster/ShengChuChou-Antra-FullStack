using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class MovieCardResponseModel
    {
        // Model裡面只放要呈現在view裡面的,例如首頁只要秀出電影Id跟海報
        public int Id { get; set; }
        public string PosterUrl { get; set; }
    }
}
