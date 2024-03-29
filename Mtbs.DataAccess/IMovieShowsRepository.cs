﻿using Mtbs.Models;
using System.Threading.Tasks;

namespace Mtbs.DataAccess
{
    public interface IMovieShowsRepository
    {
        Task<MovieShow> GetShow(int showId);
        Task<bool> UpdateSeatsAvailable(int showId, int numberOfSeats);
    }
}
