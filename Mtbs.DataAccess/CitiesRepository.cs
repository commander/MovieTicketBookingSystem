using Microsoft.EntityFrameworkCore;
using Mtbs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Mtbs.DataAccess
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly MtbsContext _dbContext;

        public CitiesRepository(MtbsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _dbContext.Cities.ToArrayAsync();

        }

        public async Task<IEnumerable<Movie>> FindMovies(string cityName)
        {
            return await (from c in _dbContext.Cities 
                          where c.Name.Equals(cityName)
                          let cinemas = c.Cinemas
                          from cn in cinemas
                          select cn.Movies).SelectMany(m => m).Distinct().ToListAsync();

        }

        public async Task<IEnumerable<Cinema>> FindCinema(string cityName)
        {
            return await (from c in _dbContext.Cities
                          where c.Name.Equals(cityName)
                          select c.Cinemas).SelectMany(c => c).Distinct().ToArrayAsync();
        }
    }
}
