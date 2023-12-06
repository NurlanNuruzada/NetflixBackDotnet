using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieDescriotionRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.MovieDescriotionRepository;

public class MovieDescriotionReadRepository : ReadRepository<MovieDescription>, IMovieDescriotionReadRepository
{
    public MovieDescriotionReadRepository(AppDbContext context) : base(context)
    {
    }
}
