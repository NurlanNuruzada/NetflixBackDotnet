using ParkCinema.Application.DTOs.CategoryMovie;
using ParkCinema.Application.DTOs.MovieDescription;

namespace ParkCinema.Application.DTOs.Movie;

public class MovieUpdateDto
{
    public string Title { get; set; }
    public string ImageLocation { get; set; }
    public string MainDescription { get; set; }

    //Relations
    public List<CategoryMovieUpdateDto>? categoryMoviesUpdateDto { get; set; }
    public MovieDescriptionUpdateDto? movieDescriptionUpdateDto { get; set; }

}
