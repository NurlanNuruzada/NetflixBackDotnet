using ParkCinema.Domain.Entities.Common;

namespace ParkCinema.Domain.Entities;

public class ActorMovieDescription:BaseEntity
{
    public Guid movieDescriptionId { get; set; }
    public MovieDescription movieDescription { get; set; }
    public Guid ActorId { get; set; }
    public Actor Actor { get; set; }
}
