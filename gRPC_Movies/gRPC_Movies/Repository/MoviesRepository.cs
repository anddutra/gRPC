using gRPC_Movies.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace gRPC_Movies.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MoviesRepository(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;


        public async Task<MoviesPage> GetMoviesByTitle(string title, int page = 1)
        {
            var result = await _httpClientFactory.CreateClient("movies").GetAsync($"/api/movies/search/?Title={title}&page={page}").ConfigureAwait(false);
            result.EnsureSuccessStatusCode();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<MoviesPage>(await result.Content.ReadAsStringAsync());
        }
    }
}
