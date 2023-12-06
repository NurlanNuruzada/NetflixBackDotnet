using ParkCinema.Domain.Entities.Common;

namespace ParkCinema.Domain.Entities;

public class Category:BaseEntity
{
    public string Name { get; set; }

    //Relations
    public List<CategoryMovie> categoryMovies { get; set; }
}
