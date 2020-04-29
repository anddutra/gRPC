using System.Linq;
using System.Threading.Tasks;
using gRPC_Movies.Repository;

namespace gRPC_Movies
{
    public class MoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<Movies> GetMoviesSummarizedByYear(string title)
        {
            var teste = await _moviesRepository.GetMoviesByTitle(title, 2);
            var firstPage = await _moviesRepository.GetMoviesByTitle(title);

            if(firstPage.Total_pages > 1)
            {
                var tasks = Enumerable.Range(2, firstPage.Total_pages).Select(async page => await _moviesRepository.GetMoviesByTitle(title, page));
                var pages = await Task.WhenAll(tasks);
                var movies = pages.SelectMany(moviesPage => moviesPage.Data);
                firstPage.Data.AddRange(movies);
            }

            var result = new Movies() { Total = firstPage.Total };
            result.MoviesByYear.AddRange(firstPage.Data.GroupBy(d => d.Year).Select(d => new MoviesByYear { Year = d.Key, Movies = d.Count() }).OrderBy(y => y.Year));
            return result;
        }
    }
}
