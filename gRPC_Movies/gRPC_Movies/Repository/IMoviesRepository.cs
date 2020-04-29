using gRPC_Movies.Models;
using System.Threading.Tasks;

namespace gRPC_Movies.Repository
{
    public interface IMoviesRepository
    {
        Task<MoviesPage> GetMoviesByTitle(string title, int page = 1);
    }
}
