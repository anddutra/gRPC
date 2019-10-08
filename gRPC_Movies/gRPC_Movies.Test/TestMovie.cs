using gRPC_Movies.Business;
using gRPC_Movies.Models;
using gRPC_Movies.Repository;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace gRPC_Movies.Test
{
    public class TestMovie
    {
        [Theory]
        [InlineData("Harry Potter", 76)]
        [InlineData("Water", 21)]
        public void TestApiTotalMovies(string title, int result)
        {
            MovieBusiness movie = new MovieBusiness(new RepositoryMovies());
            var json = movie.ReturnMovies(title);
            ResultMovie resultMovies = JsonConvert.DeserializeObject<ResultMovie>(json.Result.ToString());

            Assert.Equal(resultMovies.total, result);
        }

        [Fact]
        public void TestMockMovies()
        {
            SearchMovie searchMovie = new SearchMovie();
            searchMovie.page = 1;
            searchMovie.per_page = 10;
            searchMovie.total = 9;
            searchMovie.total_pages = 1;
            List<DetailMovie> data = new List<DetailMovie>();
            data.Add(new DetailMovie { title = "MovieTest", imdbID = "xxxxx", year = 2019 });
            data.Add(new DetailMovie { title = "MovieTest", imdbID = "xxxxx", year = 2017 });
            data.Add(new DetailMovie { title = "MovieTest", imdbID = "xxxxx", year = 2012 });
            data.Add(new DetailMovie { title = "MovieTest", imdbID = "xxxxx", year = 2019 });
            data.Add(new DetailMovie { title = "MovieTest", imdbID = "xxxxx", year = 2017 });
            data.Add(new DetailMovie { title = "MovieTest", imdbID = "xxxxx", year = 2017 });
            data.Add(new DetailMovie { title = "MovieTest", imdbID = "xxxxx", year = 2012 });
            data.Add(new DetailMovie { title = "MovieTest", imdbID = "xxxxx", year = 2019 });
            data.Add(new DetailMovie { title = "MovieTest", imdbID = "xxxxx", year = 2017 });
            searchMovie.data = data;

            var mockRepository = new Mock<IRepositoryMovies>();
            mockRepository.Setup(x => x.ReturnMovies(string.Empty, 0)).Returns(searchMovie);
            var movie = new MovieBusiness(mockRepository.Object);
            var json = movie.ReturnMovies(string.Empty);

            ResultMovie resultMovies = JsonConvert.DeserializeObject<ResultMovie>(json.Result.ToString());

            Assert.Equal(9, resultMovies.total);
            Assert.Equal(2012, resultMovies.moviesByYear[0].year);
            Assert.Equal(2, resultMovies.moviesByYear[0].movies);
            Assert.Equal(2017, resultMovies.moviesByYear[1].year);
            Assert.Equal(4, resultMovies.moviesByYear[1].movies);
            Assert.Equal(2019, resultMovies.moviesByYear[2].year);
            Assert.Equal(3, resultMovies.moviesByYear[2].movies);
        }
    }
}
