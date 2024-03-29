﻿using System;
using System.Threading.Tasks;

namespace Mtbs.DataAccess
{
    public interface IBookingsRepository
    {
        Task<Guid> BookShow(int showId, string userId, int numberOfSeats, DateTime bookingTime);
    }
}
