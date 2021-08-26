using System.ComponentModel.DataAnnotations;

namespace Mtbs.Api.Models
{
    public class BookingModel
    {
        [Required(ErrorMessage = "Show Id is required")]
        public int ShowId { get; set; }

        [Required(ErrorMessage = "NumberOfSeats is required")]
        [Range(1, 10, ErrorMessage = "Minimum 1 seat, Maximum 10 Seats")]
        public int NumberOfSeats { get; set; }
    }
}
