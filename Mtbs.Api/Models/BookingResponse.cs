using System;

namespace Mtbs.Api.Models
{
    public class BookingResponse
    {
        public Guid? BookingId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public enum BookingStatus
    {
        Succeeded,
        ShowFull
    }
}
