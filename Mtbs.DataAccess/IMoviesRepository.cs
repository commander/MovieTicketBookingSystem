using Mtbs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mtbs.DataAccess
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<IEnumerable<Cinema>> FindCinemas(string movieTitle);
        Task<IEnumerable<MovieShow>> FindShows(string movieTitle, string cinemaName);

    }
}
