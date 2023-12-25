using ParkCinema.Domain.Entities.Common;

namespace ParkCinema.Domain.Entities;

public class Movie : BaseEntity
{
    public string Title { get; set; }
    public string ImageLocation { get; set; }
    public string MainDescription { get; set; }


    //Relations
    public MovieDescription movieDescription { get; set; }
    public List<CategoryMovie> categoryMovies { get; set; }
}
