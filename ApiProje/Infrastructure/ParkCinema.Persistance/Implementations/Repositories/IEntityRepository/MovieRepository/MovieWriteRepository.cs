using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.MovieRepository;

public class MovieWriteRepository : WriteRepository<Movie>, IMovieWriteRepository
{
    public MovieWriteRepository(AppDbContext context) : base(context)
    {
    }
}
