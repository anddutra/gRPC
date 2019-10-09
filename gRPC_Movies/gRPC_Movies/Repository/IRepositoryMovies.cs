using gRPC_Movies.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gRPC_Movies.Repository
{
    public interface IRepositoryMovies
    {
        SearchMovie ReturnMovies(string title);
        Task<List<DetailMovie>> ReturnMoviesByPage(string title, int page);
    }
}
