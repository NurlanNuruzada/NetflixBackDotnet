using ParkCinema.Domain.Entities.Common;

namespace ParkCinema.Domain.Entities;

public class MovieDescription:BaseEntity
{
    public string FullDesription { get; set; }  
    public DateTime MovieDuration { get; set; }
    public double Rating { get; set; }
    public DateTime RelaseDate { get; set; }
    public int AgeLimit { get; set; }
    
    
    //Relatihons
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }
    public List<ActorMovieDescription>? actorMovieDescriptions { get; set; }
}
