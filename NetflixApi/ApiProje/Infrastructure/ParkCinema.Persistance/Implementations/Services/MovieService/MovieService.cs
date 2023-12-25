using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.ActorMovieDescriptionRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieCategoryRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieDescriotionRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieRepository;
using ParkCinema.Application.Abstraction.Services.Movie;
using ParkCinema.Application.Abstraction.Services.MovieDescription;
using ParkCinema.Application.DTOs.Movie;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Exceptions;

namespace ParkCinema.Persistance.Implementations.Services.MovieService;

public class MovieService : IMovieService
{
    private readonly IMovieReadRepository _movieReadRepository;
    private readonly IMovieWriteRepository _movieWriteRepository;
    private readonly IMovieDescriotionWriteRepository _movieDescriotionWriteRepository;
    private readonly IWriteActorMovieDescriptionRepository _writeActorMovieDescriptionRepository;
    private readonly IWriteCategoryMovieRepository _writeCategoryMovieRepository;
    private readonly IMapper _mapper;
    private readonly IMovieDescriptionService _movieDescriptionService;
    public MovieService(IMovieReadRepository movieReadRepository,
                        IMovieWriteRepository movieWriteRepository,
                        IMovieDescriotionWriteRepository movieDescriotionWriteRepository,
                        IWriteActorMovieDescriptionRepository writeActorMovieDescriptionRepository,
                        IWriteCategoryMovieRepository writeCategoryMovieRepository,
                        IMapper mapper,
                        IMovieDescriptionService movieDescriptionService)
    {
        _movieReadRepository = movieReadRepository;
        _movieWriteRepository = movieWriteRepository;
        _movieDescriotionWriteRepository = movieDescriotionWriteRepository;
        _writeActorMovieDescriptionRepository = writeActorMovieDescriptionRepository;
        _writeCategoryMovieRepository = writeCategoryMovieRepository;
        _mapper = mapper;
        _movieDescriptionService = movieDescriptionService;
    }

    public async Task<MovieGetDto> CreateAsync(MovieCreateDto movieCreateDto)
    {

        Movie movie = new()
        {
            Title = movieCreateDto.Title,
            ImageLocation = movieCreateDto.ImageLocation,
            MainDescription = movieCreateDto.MainDescription,
        };
        await _movieWriteRepository.AddAsync(movie);
        await _movieWriteRepository.SaveChangeAsync();

        ParkCinema.Domain.Entities.MovieDescription movieDescription = new()
        {
            FullDesription = movieCreateDto.movieDescriptionCreateDto.FullDesription,
            MovieDuration = movieCreateDto.movieDescriptionCreateDto.MovieDuration,
            Rating = movieCreateDto.movieDescriptionCreateDto.Rating,
            RelaseDate = movieCreateDto.movieDescriptionCreateDto.RelaseDate,
            AgeLimit = movieCreateDto.movieDescriptionCreateDto.AgeLimit,
            MovieId = movie.Id
        };
        await _movieDescriotionWriteRepository.AddAsync(movieDescription);
        await _movieDescriotionWriteRepository.SaveChangeAsync();

        foreach (var item in movieCreateDto.movieDescriptionCreateDto.actorMovieDescriptionsCreateDto)
        {
            ActorMovieDescription actorMovieDescription = new()
            {
                ActorId = item.ActorId,
                movieDescriptionId = movieDescription.Id
            };
            await _writeActorMovieDescriptionRepository.AddAsync(actorMovieDescription);
            await _writeActorMovieDescriptionRepository.SaveChangeAsync();
        }

        foreach (var item in movieCreateDto.categoryMoviesCreateDto)
        {
            CategoryMovie categoryMovie = new()
            {
                CategoryId = item.CategoryId,
                MovieId = movie.Id
            };
            await _writeCategoryMovieRepository.AddAsync(categoryMovie);
            await _writeCategoryMovieRepository.SaveChangeAsync();
        }



        //var newMovie = _mapper.Map<Movie>(movieCreateDto);
        //await _movieWriteRepository.AddAsync(newMovie);
        //await _movieWriteRepository.SaveChangeAsync();

        var toDto = _mapper.Map<MovieGetDto>(movie);
        return toDto;
    }

    public async Task<List<MovieGetDto>> GetAllAsync()
    {

        var allMovie = await _movieReadRepository.GetAll().ToListAsync();
        List<MovieGetDto> result = new();
        foreach (var movie in allMovie)
        {
            var toMovie = await GetByIdAsync(movie.Id);
            result.Add(toMovie);
        }
        return result;
    }

    public async Task<MovieGetDto> GetByIdAsync(Guid Id) //3d4209bb-a02a-415a-188e-08dc057c16c2
    {
        var movie = await _movieReadRepository.GetByIdAsync(Id);
        if (movie is null) throw new NotFoundException("Movie Not Found");

        MovieGetDto movieDto = new()
        {
            Id = movie.Id,
            Title = movie.Title,
            ImageLocation = movie.ImageLocation,
            MainDescription = movie.MainDescription,
        };
        movieDto.movieDescriptionGetDto = await _movieDescriptionService.GetByIdAsync(movie.Id);
        movieDto.categoryMoviesGetDto = await _movieDescriptionService.CategoryMovieGetByIdAllAsync(movie.Id);
        return movieDto;
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
