using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.ActorRepository;
using ParkCinema.Application.Abstraction.Services.ActorService;
using ParkCinema.Application.DTOs.Actor;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Exceptions;

namespace ParkCinema.Persistance.Implementations.Services.ActorService;

public class ActorService : IActorService
{
    private readonly IReadActorRepository _readActorRepository;
    private readonly IWriteActorRepository _writeActorRepository;
    private readonly IMapper _mapper;

    public ActorService(IReadActorRepository readActorRepository,
                        IWriteActorRepository writeActorRepository,
                        IMapper mapper)
    {
        _readActorRepository = readActorRepository;
        _writeActorRepository = writeActorRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(ActorCreateDto actorCreateDto)
    {
        var newActor = _mapper.Map<Actor>(actorCreateDto);
        await _writeActorRepository.AddAsync(newActor);
        await _writeActorRepository.SaveChangeAsync();
    }

    public async Task<List<ActorGetDto>> GetAllAsync()
    {
        var allActor = await _readActorRepository.GetAll().ToListAsync();
        var toDto = _mapper.Map<List<ActorGetDto>>(allActor);
        return toDto;
    }

    public async Task<ActorGetDto> GetByIdAsync(Guid Id)
    {
        var byActor = await _readActorRepository.GetByIdAsync(Id);
        if (byActor is null) throw new NotFoundException("Actor Not Found");
        var toDto = _mapper.Map<ActorGetDto>(byActor);
        return toDto;
    }

    public async Task RemoveAsync(Guid id)
    {
        var byActor = await _readActorRepository.GetByIdAsync(id);
        if (byActor is null) throw new NotFoundException("Actor Not Found");
        _writeActorRepository.Remove(byActor);
        await _writeActorRepository.SaveChangeAsync();
    }

    public async Task UpdateAsync(Guid id, ActorUpdateDto actorUpdateDto)
    {
        var byActor = await _readActorRepository.GetByIdAsync(id);
        if (byActor is null) throw new NotFoundException("Actor Not Found");

        _mapper.Map(actorUpdateDto, byActor);
        _writeActorRepository.Update(byActor);
        await _writeActorRepository.SaveChangeAsync();
    }
}
