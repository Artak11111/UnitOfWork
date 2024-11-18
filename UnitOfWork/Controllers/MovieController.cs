using Microsoft.AspNetCore.Mvc;

using UnitOfWork.Contracts.Services;

namespace UnitOfWork.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieController : ControllerBase
    {
        protected IMovieService MovieService { get; }

        public MovieController(IMovieService movieService)
        {
            MovieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await MovieService.GetMoviesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]string name, [FromQuery]string bookName)
        {
            return Ok(await MovieService.CreateAsync(name, bookName));
        }
    }
}
