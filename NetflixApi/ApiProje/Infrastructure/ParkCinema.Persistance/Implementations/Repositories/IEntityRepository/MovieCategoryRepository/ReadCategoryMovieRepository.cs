using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieCategoryRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.MovieCategoryRepository;

public class ReadCategoryMovieRepository : ReadRepository<CategoryMovie>, IReadCategoryMovieRepository
{
    public ReadCategoryMovieRepository(AppDbContext context) : base(context)
    {
    }
}
