using Mtbs.DataAccess;
using Mtbs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtbs.Core
{
    public class BookingService : IBookingService
    {
        public BookingService()
        {
        }

        public Task<int> BookShow(string cinema, string movieTitle, int showId)
        {
            throw new NotImplementedException();
        }
    }
}
