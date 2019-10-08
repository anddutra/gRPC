using gRPC_Movies.Models;

namespace gRPC_Movies.Repository
{
    public interface IRepositoryMovies
    {
        SearchMovie ReturnMovies(string title, int page);
    }
}
