using System;
using System.Threading.Tasks;

namespace Mtbs.Core
{
    public interface IBookingsService
    {
        // return booking reference id
        Task<Guid> BookShow(int showId, string userId, int numberOfSeats);
    }
}
