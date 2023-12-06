using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieCategoryRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.MovieCategoryRepository;

public class WriteCategoryMovieRepository : WriteRepository<CategoryMovie>, IWriteCategoryMovieRepository
{
    public WriteCategoryMovieRepository(AppDbContext context) : base(context)
    {
    }
}
