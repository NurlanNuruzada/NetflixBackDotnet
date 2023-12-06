using AutoMapper;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieRepository;
using ParkCinema.Application.Abstraction.Services.Movie;
using ParkCinema.Application.DTOs.Movie;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Persistance.Implementations.Services.MovieService;

public class MovieService : IMovieService
{
    private readonly IMovieReadRepository _movieReadRepository;
    private readonly IMovieWriteRepository _movieWriteRepository;
    private readonly IMapper _mapper;

    public MovieService(IMovieReadRepository movieReadRepository,
                        IMovieWriteRepository movieWriteRepository,
                        IMapper mapper)
    {
        _movieReadRepository = movieReadRepository;
        _movieWriteRepository = movieWriteRepository;
        _mapper = mapper;
    }

    public Task CreateAsync(MovieCreateDto movieCreateDto)
    {
        var newMovie = _mapper.Map<Movie>(movieCreateDto);
        Console.WriteLine(newMovie.Id);
        Console.WriteLine(newMovie.Title);
        Console.WriteLine(newMovie.categoryMovies);
        Console.WriteLine(newMovie.ImageLocation);
        Console.WriteLine(newMovie.MainDescription);
        Console.WriteLine(newMovie.movieDescription);
        Console.WriteLine(newMovie.movieDescription.Rating);
        Console.WriteLine(newMovie.movieDescription.AgeLimit);
        Console.WriteLine(newMovie.movieDescription.Id);
        Console.WriteLine(newMovie.movieDescription.AgeLimit);
        Console.WriteLine(newMovie.movieDescription.MovieDuration);
        Console.WriteLine(newMovie.movieDescription.actorMovieDescriptions);
        throw new NotImplementedException();
    }

    public Task<List<MovieGetDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<MovieGetDto> GetByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, MovieUpdateDto movieUpdateDto)
    {
        throw new NotImplementedException();
    }
}
