using Microsoft.Extensions.Logging;
using Mtbs.DataAccess;
using Mtbs.Models;
using System;
using System.Threading.Tasks;

namespace Mtbs.Core
{
    public class BookingsService : IBookingsService
    {
        private readonly ILogger<BookingsService> _logger;
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IMovieShowsRepository _movieShowsRepository;

        public BookingsService(ILogger<BookingsService> logger, IBookingsRepository bookingsRepository, IMovieShowsRepository movieShowsRepository)
        {
            _logger = logger;
            _bookingsRepository = bookingsRepository;
            _movieShowsRepository = movieShowsRepository;
        }

        public async Task<Guid> BookShow(int showId, string userId, int numberOfSeats)
        {
            // Get the show from Id
            MovieShow show = await _movieShowsRepository.GetShow(showId);
            
            var bookingId = Guid.Empty;

            if(show.SeatsAvailable - numberOfSeats >= 0)
            {
                bookingId = await _bookingsRepository.BookShow(showId, userId, numberOfSeats, DateTime.UtcNow);
                var result = await _movieShowsRepository.UpdateSeatsAvailable(showId, show.SeatsAvailable - numberOfSeats);
                if(!result)
                {
                    _logger.LogError("Could not update SeatsAvailable for {@showId}.", showId);
                }
            }
            else
            {
                _logger.LogInformation("Show {@showId} is full.", showId);
            }

            return bookingId;
        }
    }
}
