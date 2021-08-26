using Mtbs.DataAccess;
using Mtbs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtbs.Core
{
    public class BookingsService : IBookingsService
    {
        private readonly IBookingsRepository _bookingsRepository;

        public BookingsService(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        public async Task<Guid> BookShow(int showId, string userId, int numberOfSeats)
        {
            return await _bookingsRepository.BookShow(showId, userId, numberOfSeats, DateTime.UtcNow);
        }
    }
}
