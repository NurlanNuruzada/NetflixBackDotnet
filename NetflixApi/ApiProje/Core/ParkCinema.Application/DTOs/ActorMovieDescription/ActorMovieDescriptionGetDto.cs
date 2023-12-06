namespace ParkCinema.Application.DTOs.ActorMovieDescription;

public class ActorMovieDescriptionGetDto
{
    public Guid Id { get; set; }
    public Guid movieDescriptionId { get; set; }
    public Guid ActorId { get; set; }
}
