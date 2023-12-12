using Microsoft.AspNetCore.Mvc;
using ParkCinema.Application.Abstraction.Services.ActorService;
using ParkCinema.Application.DTOs.Actor;
using System.Net;

namespace ParkCinema.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorController : ControllerBase
{

    private readonly IActorService _actorService;
    public ActorController(IActorService actorService) => _actorService = actorService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var actor = await _actorService.GetAllAsync();
        return Ok(actor);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var byActor = await _actorService.GetByIdAsync(id);
        return Ok(byActor);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlider([FromForm] ActorCreateDto actorCreateDto)
    {
        await _actorService.CreateAsync(actorCreateDto);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSlider(Guid Id, [FromForm] ActorUpdateDto actorUpdateDto)
    {
        await _actorService.UpdateAsync(Id, actorUpdateDto);
        return Ok();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        await _actorService.RemoveAsync(id);
        return Ok();
    }
}
