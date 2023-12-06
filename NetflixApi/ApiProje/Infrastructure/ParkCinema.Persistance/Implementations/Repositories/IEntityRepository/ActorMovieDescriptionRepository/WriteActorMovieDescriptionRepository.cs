using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.ActorMovieDescriptionRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.ActorMovieDescriptionRepository;

public class WriteActorMovieDescriptionRepository : WriteRepository<ActorMovieDescription>, IWriteActorMovieDescriptionRepository
{
    public WriteActorMovieDescriptionRepository(AppDbContext context) : base(context)
    {
    }
}
