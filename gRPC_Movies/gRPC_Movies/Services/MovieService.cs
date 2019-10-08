using System.Threading.Tasks;
using Grpc.Core;
using gRPC_Movies.Business;
using gRPC_Movies.Repository;
using Microsoft.Extensions.Logging;

namespace gRPC_Movies
{
    public class MovieService : MovieSvc.MovieSvcBase
    {
        private readonly ILogger<MovieService> _logger;
        public MovieService(ILogger<MovieService> logger)
        {
            _logger = logger;
        }

        public override async Task<MovieReply> GetMovies(MovieRequest request, ServerCallContext context)
        {
            MovieBusiness movie = new MovieBusiness(new RepositoryMovies());
            var resultMovies = await movie.ReturnMovies(request.TitleMovie);

            return await Task.FromResult(new MovieReply
            {
                ResultMovies = resultMovies.ToString()
            });
        }
    }
}
