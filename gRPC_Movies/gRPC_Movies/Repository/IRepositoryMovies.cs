using gRPC_Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPC_Movies.Repository
{
    public interface IRepositoryMovies
    {
        SearchMovie ReturnMovies(string title, int page);
    }
}
