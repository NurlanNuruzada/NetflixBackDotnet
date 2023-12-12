using ParkCinema.Application.DTOs.Actor;

namespace ParkCinema.Application.Abstraction.Services.ActorService;

public interface IActorService
{
    Task<List<ActorGetDto>> GetAllAsync();
    Task<ActorGetDto> GetByIdAsync(Guid Id);
    Task CreateAsync(ActorCreateDto actorCreateDto);
    Task UpdateAsync(Guid id, ActorUpdateDto actorUpdateDto);
    Task RemoveAsync(Guid id);
}
