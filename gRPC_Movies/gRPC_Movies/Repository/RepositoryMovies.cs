using gRPC_Movies.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace gRPC_Movies.Repository
{
    public class RepositoryMovies : IRepositoryMovies
    {
        private HttpClient _client = new HttpClient();
        public SearchMovie ReturnMovies(string title)
        {
            HttpResponseMessage response = _client.GetAsync(
                    string.Format("https://jsonmock.hackerrank.com/api/movies/search/?Title={0}",
                    title)).Result;
            if (response.IsSuccessStatusCode)
            {
                SearchMovie searchMovie = JsonConvert.DeserializeObject<SearchMovie>
                    (response.Content.ReadAsStringAsync().Result);

                return searchMovie;
            }
            return null;
        }

        public async Task<List<DetailMovie>> ReturnMoviesByPage(string title, int page)
        {
            HttpResponseMessage response = _client.GetAsync(
                    string.Format("https://jsonmock.hackerrank.com/api/movies/search/?Title={0}&page={1}",
                    title, page)).Result;

            if (response.IsSuccessStatusCode)
            {
                SearchMovie searchMovie = JsonConvert.DeserializeObject<SearchMovie>
                    (response.Content.ReadAsStringAsync().Result);

                return searchMovie.data;
            }
            return null;
        }
    }
}
