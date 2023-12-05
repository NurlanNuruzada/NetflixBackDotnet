using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.CategoryRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.CategoryRepository;

public class WriteCategoryRepository : WriteRepository<Category>, IWriteCategoryRepository
{
    public WriteCategoryRepository(AppDbContext context) : base(context)
    {
    }
}
