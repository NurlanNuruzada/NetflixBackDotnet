using ParkCinema.Domain.Entities.Common;

namespace ParkCinema.Domain.Entities;

public class Slider: BaseEntity
{
    public string ImagePath { get; set; }
    public string Name { get; set; }
}
