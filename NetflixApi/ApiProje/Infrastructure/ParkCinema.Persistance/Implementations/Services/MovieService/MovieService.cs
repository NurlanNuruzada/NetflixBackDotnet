using AutoMapper;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.ActorMovieDescriptionRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieCategoryRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieDescriotionRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieRepository;
using ParkCinema.Application.Abstraction.Services.Movie;
using ParkCinema.Application.DTOs.CategoryMovie;
using ParkCinema.Application.DTOs.Movie;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Persistance.Implementations.Services.MovieService;

public class MovieService : IMovieService
{
    private readonly IMovieReadRepository _movieReadRepository;
    private readonly IMovieWriteRepository _movieWriteRepository;
    private readonly IMovieDescriotionWriteRepository _movieDescriotionWriteRepository;
    private readonly IWriteActorMovieDescriptionRepository _writeActorMovieDescriptionRepository;
    private readonly IWriteCategoryMovieRepository _writeCategoryMovieRepository;
    private readonly IMapper _mapper;

    public MovieService(IMovieReadRepository movieReadRepository,
                        IMovieWriteRepository movieWriteRepository,
                        IMovieDescriotionWriteRepository movieDescriotionWriteRepository,
                        IWriteActorMovieDescriptionRepository writeActorMovieDescriptionRepository,
                        IWriteCategoryMovieRepository writeCategoryMovieRepository,
                        IMapper mapper)
    {
        _movieReadRepository = movieReadRepository;
        _movieWriteRepository = movieWriteRepository;
        _movieDescriotionWriteRepository = movieDescriotionWriteRepository;
        _writeActorMovieDescriptionRepository = writeActorMovieDescriptionRepository;
        _writeCategoryMovieRepository = writeCategoryMovieRepository;
        _mapper = mapper;
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

        MovieDescription movieDescription = new()
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
    /*
 public async Task<MovieGetDto2> GetByIdAsync(Guid Id)
    {
        var movie = await _movieReadRepository.GetByIdAsync(Id);
        if (movie is null) throw new NotFoundException("Movie Not Found");

        MovieGetDto2 movieDto = new()
        {
            Id = movie.Id,
            Title = movie.Title,
            ImageLocation = movie.ImageLocation,
            MainDescription = movie.MainDescription,
            movieDescriptionId = movie.movieDescription?.Id ?? Guid.Empty,
            categoryMoviesId = movie.categoryMovies?.Select(cm => cm.Id).ToList() ?? new List<Guid>()
        };

        return movieDto;
    }
    */

    public Task<List<MovieGetDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

   //public async Task<MovieGetDto> GetByIdAsync(Guid Id)
    //{
    //    var movie = await _movieReadRepository.GetByIdAsync(Id);
    //    if (movie is null) throw new NotFoundException("Movie Not Found");

    //    MovieGetDto movieDto = new()
    //    {
    //        Id = movie.Id,
    //        Title = movie.Title,
    //        ImageLocation = movie.ImageLocation,
    //        MainDescription = movie.MainDescription,
    //        movieDescriptionGetDto = movie.movieDescription != null
    //       ? new MovieDescriptionGetDto()
    //       {
    //           Id = movie.movieDescription.Id,
    //           FullDesription = movie.movieDescription.FullDesription,
    //           MovieDuration = movie.movieDescription.MovieDuration,
    //           Rating = movie.movieDescription.Rating,
    //           RelaseDate = movie.movieDescription.RelaseDate,
    //           AgeLimit = movie.movieDescription.AgeLimit,
    //           MovieId = movie.movieDescription.MovieId,
    //           actorMovieDescriptionsGetDto = movie.movieDescription.actorMovieDescriptions
    //               ?.Select(amd => new ActorMovieDescriptionGetDto
    //               {
    //                   Id = amd.Id,
    //                   movieDescriptionId = amd.movieDescriptionId,
    //                   ActorId = amd.ActorId
    //               }).ToList()
    //       }
    //       : null,
    //    };

    //    return movieDto;
    //}


    public Task RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, MovieUpdateDto movieUpdateDto)
    {
        throw new NotImplementedException();
    }
}
