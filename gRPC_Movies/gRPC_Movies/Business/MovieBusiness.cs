using gRPC_Movies.Models;
using gRPC_Movies.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace gRPC_Movies.Business
{
    public class MovieBusiness
    {
        IRepositoryMovies _repository;
        private List<MovieByYear> _moviesByYear = new List<MovieByYear>();

        public MovieBusiness(IRepositoryMovies repository)
        {
            _repository = repository;
        }

        public async Task<string> ReturnMovies(string title)
        {
            try
            {
                SearchMovie searchMovie = _repository.ReturnMovies(title, 0);

                if (searchMovie != null)
                {
                    foreach (DetailMovie mov in searchMovie.data)
                        _moviesByYear.Add(new MovieByYear { year = mov.year });

                    var lTasks = new List<Task>();
                    for (int page = 2; page <= searchMovie.total_pages; page++)
                        lTasks.Add(ReturnTasks(title, page));

                    await Task.WhenAll(lTasks);

                    ResultMovie resultMovies = new ResultMovie(_moviesByYear, searchMovie.total);
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

        private async Task ReturnMoviesByPage(string title, int page)
        {
            try
            {
                SearchMovie searchMovie = _repository.ReturnMovies(title, page);

                if (searchMovie != null)
                {
                    foreach (DetailMovie mov in searchMovie.data)
                        _moviesByYear.Add(new MovieByYear { year = mov.year });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
