using gRPC_Movies.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace gRPC_Movies.Repository
{
    public class RepositoryMovies : IRepositoryMovies
    {
        private HttpClient _client = new HttpClient();
        public SearchMovie ReturnMovies(string title, int page)
        {
            HttpResponseMessage response = _client.GetAsync(
                    string.Format("https://jsonmock.hackerrank.com/api/movies/search/?Title={0}{1}",
                    title, page > 0 ? string.Format("&page={0}", page) : string.Empty)).Result;

            if (response.IsSuccessStatusCode)
            {
                SearchMovie searchMovie = JsonConvert.DeserializeObject<SearchMovie>
                    (response.Content.ReadAsStringAsync().Result);

                return searchMovie;
            }
            return null;
        }
    }
}
