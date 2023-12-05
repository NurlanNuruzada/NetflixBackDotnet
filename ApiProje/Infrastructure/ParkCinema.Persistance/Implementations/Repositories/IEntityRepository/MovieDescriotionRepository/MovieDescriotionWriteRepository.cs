using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieDescriotionRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.MovieDescriotionRepository;

public class MovieDescriotionWriteRepository : WriteRepository<MovieDescription>, IMovieDescriotionWriteRepository
{
    public MovieDescriotionWriteRepository(AppDbContext context) : base(context)
    {
    }
}
