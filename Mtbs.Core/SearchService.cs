using Mtbs.DataAccess;
using Mtbs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mtbs.Core
{
    public class SearchService : ISearchService
    {
        private IMoviesRepository _moviesRepository;
        private ICitiesRepository _citiesRepository;

        public SearchService(IMoviesRepository moviesRepository, ICitiesRepository citiesRepository)
        {
            _moviesRepository = moviesRepository;
            _citiesRepository = citiesRepository;
        }

        public async Task<IEnumerable<Cinema>> FindCinema(string movieTitle)
        {
            return await _moviesRepository.FindCinemas(movieTitle);
        }

        public async Task<IEnumerable<Movie>> FindMovies(string cityName)
        {
            return await _citiesRepository.FindMovies(cityName);
        }

        public async Task<IEnumerable<MovieShow>> FindShows(string cinema, string movieTitle)
        {
            return await _moviesRepository.FindShows(movieTitle, cinema);
        }
    }
}
