using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.ActorMovieDescriptionRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.ActorMovieDescriptionRepository;

public class ReadActorMovieDescriptionRepository : ReadRepository<ActorMovieDescription>, IReadActorMovieDescriptionRepository
{
    public ReadActorMovieDescriptionRepository(AppDbContext context) : base(context)
    {
    }
}
