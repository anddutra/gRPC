using System.Collections.Generic;
using System.Linq;

namespace gRPC_Movies.Models
{
    public class ResultMovie
    {
        public List<MovieByYear> moviesByYear { get;set; }
        public int total { get; set; }

        public ResultMovie(List<MovieByYear> moviesByYear, int total)
        {
            this.moviesByYear = moviesByYear.GroupBy(x => x.year)
                .Select(g => new MovieByYear { year = g.Key, movies = g.Count() })
                .OrderBy(y => y.year)
                .ToList();
            this.total = total;
        }
        public ResultMovie()
        {

        }
    }
}
