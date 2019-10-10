using System.Threading.Tasks;
using Grpc.Net.Client;
using gRPC_Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gRPC_MoviesClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> SearchMovie(string title)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new MovieSvc.MovieSvcClient(channel);
            var reply = await client.GetMoviesAsync(
                              new MovieRequest { TitleMovie = title != null ? title : string.Empty });
            
            return reply.ResultMovies.ToString();
        }
    }
}
