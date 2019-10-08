using System.Collections.Generic;

namespace gRPC_Movies.Models
{
    public class ResultMovie
    {
        public List<MovieByYear> moviesByYear { get;set; }
        public int total { get; set; }
    }
}
