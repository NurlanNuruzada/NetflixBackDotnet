using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.ActorRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.ActorRepository;

public class ReadActorRepository : ReadRepository<Actor>, IReadActorRepository
{
    public ReadActorRepository(AppDbContext context) : base(context)
    {
    }
}
