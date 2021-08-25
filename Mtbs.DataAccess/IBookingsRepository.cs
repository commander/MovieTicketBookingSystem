using Mtbs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mtbs.DataAccess
{
    public interface IBookingsRepository
    {
        Task<Guid> BookShow(int showId, string userId, DateTime bookingTime);
    }
}
