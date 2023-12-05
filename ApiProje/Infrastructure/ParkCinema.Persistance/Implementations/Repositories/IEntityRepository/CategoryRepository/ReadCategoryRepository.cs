using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.CategoryRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.CategoryRepository;

public class ReadCategoryRepository : ReadRepository<Category>, IReadCategoryRepository
{
    public ReadCategoryRepository(AppDbContext context) : base(context)
    {
    }
}
