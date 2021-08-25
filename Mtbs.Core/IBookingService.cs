using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtbs.Core
{
    public interface IBookingService
    {
        // return booking reference id
        Task<int> BookShow(string cinema, string movieTitle, int showId);
    }
}
