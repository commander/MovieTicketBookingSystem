using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Mtbs.Core;

namespace Mtbs.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly ISearchService _searchService;
        public MoviesController(ILogger<MoviesController> logger, ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        //[HttpGet]
        //public async Task<ActionResult> Get()
        //{
        //    var movies = await _dbContext.Movies.ToArrayAsync();
        //    return Ok(movies);
        //}

        [HttpGet]
        [Route("{movieName}/Cinemas")]
        public async Task<ActionResult> GetMovieCinemas(string movieName)
        {
            var cinemas = await _searchService.FindCinema(movieName);

            return Ok(cinemas);
        }

        [HttpGet]
        [Route("{movieName}/Cinemas/{cinema}/Shows")]
        public async Task<ActionResult> GetMovieShows(string movieName, string cinema)
        {
            var movieShows = await _searchService.FindShows(cinema, movieName);

            return Ok(movieShows);
        }
    }
}
