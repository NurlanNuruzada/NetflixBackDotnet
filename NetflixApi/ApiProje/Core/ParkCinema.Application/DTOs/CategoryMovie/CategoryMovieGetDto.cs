namespace ParkCinema.Application.DTOs.CategoryMovie;

public class CategoryMovieGetDto
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public Guid CategoryId { get; set; }
}
