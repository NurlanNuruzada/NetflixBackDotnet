using ParkCinema.Application.DTOs.ActorMovieDescription;

namespace ParkCinema.Application.DTOs.Actor;

public class ActorGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public List<ActorMovieDescriptionGetDto>? actorMovieDescriptionsGetDto { get; set; }

}
