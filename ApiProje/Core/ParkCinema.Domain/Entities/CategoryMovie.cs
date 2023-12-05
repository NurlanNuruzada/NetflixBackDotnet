using ParkCinema.Domain.Entities.Common;

namespace ParkCinema.Domain.Entities;

public class CategoryMovie:BaseEntity
{
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
