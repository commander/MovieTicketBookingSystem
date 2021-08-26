using Mtbs.Models.Authentication;
using System;

namespace Mtbs.Models
{
    public class Booking
    {
        public Guid Id { get; set; }

        public int ShowId { get; set; }

        public string UserId { get; set; }

        public int NumberOfSeats { get; set; }

        public DateTime BookingTime { get; set; }

        public MovieShow Show { get; set; }

        public ApplicationUser User { get; set; }
    }
}
