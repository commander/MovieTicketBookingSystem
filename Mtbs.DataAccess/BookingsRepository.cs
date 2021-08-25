using Mtbs.Models;
using System;
using System.Threading.Tasks;

namespace Mtbs.DataAccess
{
    public class BookingsRepository : IBookingsRepository
    {
        private readonly MtbsContext _dbContext;

        public BookingsRepository(MtbsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> BookShow(int showId, string userId, DateTime bookingTime)
        {
            Booking booking = new Booking
            {
                ShowId = showId,
                UserId = userId,
                BookingTime = bookingTime
            };

            var newBooking = await _dbContext.Bookings.AddAsync(booking);

            return newBooking.Entity.Id;
        }
    }
}
