using Microsoft.AspNetCore.Mvc;
using ParkCinema.Application.Abstraction.Services.Movie;
using ParkCinema.Application.DTOs.Movie;

namespace ParkCinema.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{

    private readonly IMovieService _movieService;
    public MovieController(IMovieService movieService) => _movieService = movieService;

    [HttpGet("[Action]")]
    public Task<IActionResult> getAllMovie()
    {
        return null;
    }

    [HttpGet("Guid:Id")]
    public Task<IActionResult> getAllMovie(Guid Id)
    {
        return null;
    }

    [HttpPost]
    public async Task<IActionResult> postMovie(MovieCreateDto movieCreateDto)
    {
        await _movieService.CreateAsync(movieCreateDto);    
        return null;
    }

    [HttpDelete]
    public Task<IActionResult> removeById(Guid Id)
    {
        return null;
    }

    [HttpPut]
    public Task<IActionResult> updateById(Guid Id, MovieUpdateDto movieUpdateDto)
    {
        return null;
    }
}
