using System.Collections.Generic;

namespace gRPC_Movies.Models
{
    public class MoviesPage
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<MovieData> Data { get; set; } = new List<MovieData>();
    }
}
