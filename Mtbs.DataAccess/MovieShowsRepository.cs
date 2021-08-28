using Microsoft.EntityFrameworkCore;
using Mtbs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Mtbs.DataAccess
{
    public class MovieShowsRepository: IMovieShowsRepository
    {
        private readonly MtbsContext _dbContext;
        
        public MovieShowsRepository(MtbsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MovieShow> GetShow(int showId)
        {
            return await _dbContext.MovieShows.FindAsync(showId);

        }

        public async Task<bool> UpdateSeatsAvailable(int showId, int numberOfSeats)
        {
            var movieShow = _dbContext.MovieShows.Find(showId);

            if(movieShow == null)
            {
                return false;
            }
            
            movieShow.SeatsAvailable = numberOfSeats;

            await _dbContext.SaveChangesAsync();
            
            return true;
        }

    }
}
