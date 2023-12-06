using ParkCinema.Domain.Entities.Common;

namespace ParkCinema.Domain.Entities;

public class Actor:BaseEntity
{
    public string Name { get; set; }
    public string SurName { get; set; }

    //Relations
    public List<ActorMovieDescription> actorMovieDescriptions { get; set; }
}
