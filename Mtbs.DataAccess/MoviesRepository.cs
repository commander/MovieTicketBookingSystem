using Microsoft.EntityFrameworkCore;
using Mtbs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Mtbs.DataAccess
{
    public class MoviesRepository: IMoviesRepository
    {
        private readonly MtbsContext _dbContext;

        public MoviesRepository(MtbsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _dbContext.Movies.ToArrayAsync();

        }

        public async Task<IEnumerable<Cinema>> FindCinemas(string movieTitle)
        {
            return await _dbContext.Movies.Where(m => m.Title.Equals(movieTitle))
                                            .SelectMany(m => m.Cinemas).ToArrayAsync();

        }

        public async Task<IEnumerable<MovieShow>> FindShows(string movieTitle, string cinemaName)
        {
            return await (from c in _dbContext.Cinemas
                                    where c.Name.Equals(cinemaName)
                                    let shows = c.Shows
                                    from s in shows
                                    where s.Movie.Title.Equals(movieTitle)
                                    select s).ToArrayAsync();

        }
    }
}
