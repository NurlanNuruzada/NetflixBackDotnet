using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.SliderRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.SliderRepository;

public class SliderWriteRepository : WriteRepository<Slider>, ISliderWriteRepository
{
    public SliderWriteRepository(AppDbContext context) : base(context)
    {
    }
}
