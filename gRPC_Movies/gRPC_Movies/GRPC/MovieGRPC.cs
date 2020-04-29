using Grpc.Core;
using System.Threading.Tasks;

namespace gRPC_Movies.GRPC
{
    public class MovieGRPC : Movie.MovieBase
    {
        private readonly MoviesService _moviesService;

        public MovieGRPC(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public override async Task<Movies> GetMoviesByTitle(NameMovie request, ServerCallContext context) => await _moviesService.GetMoviesSummarizedByYear(request.Name);
    }
}
