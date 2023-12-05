using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.SliderRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.SliderRepository;

public class SliderReadRepository : ReadRepository<Slider>, ISliderReadRepository
{
    public SliderReadRepository(AppDbContext context) : base(context)
    {
    }
}
