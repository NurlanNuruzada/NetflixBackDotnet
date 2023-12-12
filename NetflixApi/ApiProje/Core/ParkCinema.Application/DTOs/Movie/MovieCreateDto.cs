using ParkCinema.Application.DTOs.CategoryMovie;
using ParkCinema.Application.DTOs.MovieDescription;

namespace ParkCinema.Application.DTOs.Movie;

public class MovieCreateDto
{
    public string? Title { get; set; }
    public string? ImageLocation { get; set; }
    public string? MainDescription { get; set; }

    //Relations
    public MovieDescriptionCreateDto? movieDescriptionCreateDto { get; set; }
    public List<CategoryMovieCreateDto>? categoryMoviesCreateDto { get; set; }
}
