using Mtbs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mtbs.DataAccess
{
    public interface ICitiesRepository
    {
        Task<IEnumerable<City>> GetAll();
        Task<IEnumerable<Movie>> FindMovies(string cityName);
        Task<IEnumerable<Cinema>> FindCinema(string cityName);

    }
}
