using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class MovieCardResponseModel
    {
        // Model裡面只放要呈現在view裡面的,例如首頁只要秀出電影Id,海報,Title,跟票房
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public decimal? Revenue { get; set; }
    }
}
