using gRPC_Movies.Models;
using gRPC_Movies.Repository;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xunit;

namespace gRPC_Movies.Test
{
    public class TestMovie
    {
        private MoviesService _moviesService;

        public TestMovie()
        {
            var services = new ServiceCollection();
            services.AddScoped<MoviesService>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddHttpClient("movies", _ => _.BaseAddress = new Uri(@"https://jsonmock.hackerrank.com"));

            var serviceProvider = services.BuildServiceProvider();

            _moviesService = serviceProvider.GetService<MoviesService>();
        }

        [Theory]
        [InlineData("Harry Potter", 76)]
        [InlineData("Water", 21)]
        public void TestApiTotalMovies(string title, int result)
        {
            var json = _moviesService.GetMoviesSummarizedByYear(title);
            var movies = json.Result;

            Assert.Equal(movies.Total, result);
        }

        [Fact]
        public void TestMockMovies()
        {
            MoviesPage moviesPage = new MoviesPage
            {
                Page = 1,
                Per_page = 10,
                Total = 9,
                Total_pages = 1
            };
            moviesPage.Data.Add(new MovieData { Title = "MovieTest", Year = 2019 });
            moviesPage.Data.Add(new MovieData { Title = "MovieTest", Year = 2017 });
            moviesPage.Data.Add(new MovieData { Title = "MovieTest", Year = 2012 });
            moviesPage.Data.Add(new MovieData { Title = "MovieTest", Year = 2019 });
            moviesPage.Data.Add(new MovieData { Title = "MovieTest", Year = 2017 });
            moviesPage.Data.Add(new MovieData { Title = "MovieTest", Year = 2017 });
            moviesPage.Data.Add(new MovieData { Title = "MovieTest", Year = 2012 });
            moviesPage.Data.Add(new MovieData { Title = "MovieTest", Year = 2019 });
            moviesPage.Data.Add(new MovieData { Title = "MovieTest", Year = 2017 });

            var mockRepository = new Mock<IMoviesRepository>();
            mockRepository.Setup(x => x.GetMoviesByTitle(string.Empty, 1)).Returns(Task.FromResult(moviesPage));
            //mockRepository.Setup(x => x.GetMoviesByTitle(string.Empty, 2)).Returns(Task.FromResult(new MoviesPage()));
            var moviesService = new MoviesService(mockRepository.Object);
            var json = moviesService.GetMoviesSummarizedByYear(string.Empty);

            Movies resultMovies = JsonConvert.DeserializeObject<Movies>(json.Result.ToString());

            Assert.Equal(9, resultMovies.Total);
            Assert.Equal(2012, resultMovies.MoviesByYear[0].Year);
            Assert.Equal(2, resultMovies.MoviesByYear[0].Movies);
            Assert.Equal(2017, resultMovies.MoviesByYear[1].Year);
            Assert.Equal(4, resultMovies.MoviesByYear[1].Movies);
            Assert.Equal(2019, resultMovies.MoviesByYear[2].Year);
            Assert.Equal(3, resultMovies.MoviesByYear[2].Movies);
        }
    }
}
