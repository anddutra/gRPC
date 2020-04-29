using System;
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
        public async Task<Movies> SearchMovie(string title)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Movie.MovieClient(channel);
            title = String.IsNullOrEmpty(title) ? string.Empty : title;
            var reply = await client.GetMoviesByTitleAsync(
                              new NameMovie { Name = title });
            
            return reply;
        }
    }
}
