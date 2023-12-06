using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.MovieRepository;

public class MovieReadRepository : ReadRepository<Movie>, IMovieReadRepository
{
    public MovieReadRepository(AppDbContext context) : base(context)
    {
    }
}
