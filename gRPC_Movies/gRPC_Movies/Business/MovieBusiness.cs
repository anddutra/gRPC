using gRPC_Movies.Models;
using gRPC_Movies.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPC_Movies.Business
{
    public class MovieBusiness
    {
        IRepositoryMovies _repository;
        public MovieBusiness(IRepositoryMovies repository)
        {
            _repository = repository;
        }

        public async Task<string> ReturnMovies(string title)
        {
            try
            {
                SearchMovie searchMovie = _repository.ReturnMovies(title);

                if (searchMovie != null)
                {
                    var lTasks = new List<Task>();
                    for (int page = 2; page <= searchMovie.total_pages; page++)
                        lTasks.Add(ReturnTasks(title, page));

                    await Task.WhenAll(lTasks);

                    List<MovieByYear> moviesByYear = new List<MovieByYear>();
                    moviesByYear.AddRange(searchMovie.data
                        .Select(x => new MovieByYear { year = x.year }));

                    lTasks.ForEach(x =>
                    {
                        moviesByYear.AddRange(((Task<List<DetailMovie>>)x).Result
                            .Select(m => new MovieByYear { year = m.year }));
                    });

                    ResultMovie resultMovies = new ResultMovie
                    {
                        total = moviesByYear.Count(),
                        moviesByYear = moviesByYear.GroupBy(x => x.year)
                        .Select(g => new MovieByYear { year = g.Key, movies = g.Count() })
                        .OrderBy(y => y.year)
                        .ToList()
                    };

                    return JsonConvert.SerializeObject(resultMovies);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "Erro ao processar solicitação";
        }

        private Task ReturnTasks(string title, int page)
        {
            return Task.Run(() => { return ReturnMoviesByPage(title, page); });
        }

        private Task<List<DetailMovie>> ReturnMoviesByPage(string title, int page)
        {
            try
            {
                return _repository.ReturnMoviesByPage(title, page);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
