using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mtbs.Core;
using System.Threading.Tasks;

namespace Mtbs.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly ISearchService _searchService;
        public CitiesController(ILogger<CitiesController> logger, ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        //[HttpGet]
        //public async Task<ActionResult> Get()
        //{
        //    var cities = await _dbContext.Cities.ToArrayAsync();
        //    return Ok(cities);
        //}

        [HttpGet()]
        [Route("{cityName}/Movies")]
        public async Task<ActionResult> GetMovies([FromRoute] string cityName)
        {
            var movies = await _searchService.FindMovies(cityName);
            
            return Ok(movies);
        }

        //[HttpGet()]
        //[Route("{cityName}/Cinemas")]
        //public async Task<ActionResult> GetCinema([FromRoute] string cityName)
        //{
        //    var cinemas = await (from c in _dbContext.Cities
        //                         where c.Name.Equals(cityName, StringComparison.OrdinalIgnoreCase)
        //                         select c.Cinemas).Distinct().ToArrayAsync();

        //    return Ok(cinemas);
        //}
    }
}
