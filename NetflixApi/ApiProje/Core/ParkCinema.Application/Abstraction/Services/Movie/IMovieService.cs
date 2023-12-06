using ParkCinema.Application.DTOs.Movie;

namespace ParkCinema.Application.Abstraction.Services.Movie;

public interface IMovieService
{
    Task<List<MovieGetDto>> GetAllAsync();
    Task CreateAsync(MovieCreateDto movieCreateDto);
    Task<MovieGetDto> GetByIdAsync(Guid Id);
    Task UpdateAsync(Guid id, MovieUpdateDto movieUpdateDto);
    Task RemoveAsync(Guid id);
}
