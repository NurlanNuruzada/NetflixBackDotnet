using ParkCinema.Application.DTOs.ActorMovieDescription;
using ParkCinema.Application.DTOs.CategoryMovie;
using ParkCinema.Application.DTOs.Movie;
using ParkCinema.Application.DTOs.MovieDescription;

namespace ParkCinema.Application.Abstraction.Services.MovieDescription;

public interface IMovieDescriptionService
{
    Task<MovieDescriptionGetDto> GetByIdAsync(Guid movieId);
    Task<List<ActorMovieDescriptionGetDto>> ActorMovieGetByIdAllAsync(Guid movieDescriptionId);
    Task<List<CategoryMovieGetDto>> CategoryMovieGetByIdAllAsync(Guid movieId);
}
