using gRPC_Movies.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace gRPC_Movies.Repository
{
    public class RepositoryMovies : IRepositoryMovies
    {
        public SearchMovie ReturnMovies(string title)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync(string.Format("https://jsonmock.hackerrank.com/api/movies/search/?Title={0}",
                        title)).Result;

                if (result.IsSuccessStatusCode)
                {
                    SearchMovie searchMovie = JsonConvert.DeserializeObject<SearchMovie>
                        (result.Content.ReadAsStringAsync().Result);

                    return searchMovie;
                }
            }
            return null;
        }

        public async Task<List<DetailMovie>> ReturnMoviesByPage(string title, int page)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(string.Format("https://jsonmock.hackerrank.com/api/movies/search/?Title={0}&page={1}",
                        title, page));

                if (result.IsSuccessStatusCode)
                {
                    SearchMovie searchMovie = JsonConvert.DeserializeObject<SearchMovie>
                        (result.Content.ReadAsStringAsync().Result);

                    return searchMovie.data;
                }
            }
            return null;
        }
    }
}
