using System.Collections.Generic;

namespace gRPC_Movies.Models
{
    public class SearchMovie
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<DetailMovie> data { get; set; }
    }
}
