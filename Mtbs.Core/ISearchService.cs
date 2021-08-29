using Mtbs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mtbs.Core
{
    public interface ISearchService
    {
        Task<IEnumerable<Movie>> FindMovies(string cityName);

        Task<IEnumerable<Cinema>> FindCinema(string movieTitle);

        Task<IEnumerable<MovieShow>> FindShows(string cinema, string movieTitle);
    }
}
