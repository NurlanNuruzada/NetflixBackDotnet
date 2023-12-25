using ParkCinema.Application.DTOs.CategoryMovie;
using ParkCinema.Application.DTOs.MovieDescription;

namespace ParkCinema.Application.DTOs.Movie;

public class MovieGetDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ImageLocation { get; set; }
    public string MainDescription { get; set; }

    //Relations
    public MovieDescriptionGetDto movieDescriptionGetDto {get;set;}
    public List<CategoryMovieGetDto>? categoryMoviesGetDto { get; set; }
}
