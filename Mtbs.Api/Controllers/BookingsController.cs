using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mtbs.Api.Models;
using Mtbs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mtbs.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize] 
    public class BookingsController : ControllerBase
    {
        private readonly ILogger<BookingsController> _logger;
        private readonly IBookingsService _bookingsService;

        public BookingsController(ILogger<BookingsController> logger, IBookingsService bookingsService)
        {
            _logger = logger;
            _bookingsService = bookingsService;
        }

        [HttpPost]
        public async Task<ActionResult> BookShow([FromBody] BookingModel model)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Guid bookingId = await _bookingsService.BookShow(model.ShowId, userId, model.NumberOfSeats);

            if(bookingId == Guid.Empty)
            {
                _logger.LogError("Could not book ticket for user {@userId}, show {@showId}", userId, model.ShowId);
                return Ok(new BookingResponse
                {
                    Message = "Show is full. Please try another show.",
                    Status = BookingStatus.ShowFull.ToString()
                });
            }
            else
            {
                _logger.LogInformation("Created Booking {@bookingId} for user {@userId}", bookingId, userId);
                return Ok(new BookingResponse 
                {
                    BookingId = bookingId,
                    Status = BookingStatus.Succeeded.ToString(),
                    Message = "Success"
                });
            }
            
        }
    }
}
