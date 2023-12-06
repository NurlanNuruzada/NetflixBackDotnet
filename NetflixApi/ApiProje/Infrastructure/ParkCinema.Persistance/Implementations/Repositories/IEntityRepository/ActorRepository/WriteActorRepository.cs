using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.ActorRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.ActorRepository;

public class WriteActorRepository : WriteRepository<Actor>, IWriteActorRepository
{
    public WriteActorRepository(AppDbContext context) : base(context)
    {
    }
}
