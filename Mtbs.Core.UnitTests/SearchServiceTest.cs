using Xunit;
using Mtbs.DataAccess;
using Moq;
using Mtbs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Mtbs.Core.UnitTests
{
    public class SearchServiceTest
    {
        private SearchService sut = null;
        
        [Fact]
        public async Task SearchFindsCinemaByMovieTitleSuccessfully()
        {
            // Arrange
            var moviesRepository = new Mock<IMoviesRepository>();

            var cinema = new Cinema
            {
                Id = 1,
                CityId = 1,
                Name = "PVR",
            };
            moviesRepository.Setup(x => x.FindCinemas(It.IsAny<string>()))
                            .ReturnsAsync(new List<Cinema>
                            {
                                cinema
                            });

            sut = new SearchService(moviesRepository.Object, null);

            // Act
            var result = await sut.FindCinema("Movie1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cinema, result.First());
        }

        [Fact]
        public async Task SearchCallsMoviesRepositoryFindCinemaOnce()
        {
            // Arrange
            var moviesRepository = new Mock<IMoviesRepository>();

            var cinema = new Cinema
            {
                Id = 1,
                CityId = 1,
                Name = "PVR",
            };
            moviesRepository.Setup(x => x.FindCinemas(It.IsAny<string>()))
                            .ReturnsAsync(new List<Cinema>
                            {
                                cinema
                            }).Verifiable();

            sut = new SearchService(moviesRepository.Object, null);

            // Act
            var result = await sut.FindCinema("Movie1");

            // Assert
            moviesRepository.Verify(x => x.FindCinemas(It.IsAny<string>()), Times.Once);
        }
    }
}
