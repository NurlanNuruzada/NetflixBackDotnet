using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.ActorMovieDescriptionRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieCategoryRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieDescriotionRepository;
using ParkCinema.Application.Abstraction.Services.MovieDescription;
using ParkCinema.Application.DTOs.ActorMovieDescription;
using ParkCinema.Application.DTOs.CategoryMovie;
using ParkCinema.Application.DTOs.MovieDescription;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Exceptions;

namespace ParkCinema.Persistance.Implementations.Services.MovieDescription;

public class MovieDescriptionService : IMovieDescriptionService
{
    private readonly IMovieDescriotionReadRepository _movieDescriptionReadRepository;
    private readonly IMovieDescriotionWriteRepository _movieDescriptionWriteRepository;
    private readonly IReadActorMovieDescriptionRepository _readActorMovieDescriptionRepository;
    private readonly IWriteActorMovieDescriptionRepository _writeActorMovieDescriptionRepository;
    private readonly IReadCategoryMovieRepository _readCategoryMovieRepository;
    private readonly IWriteCategoryMovieRepository _writeCategoryMovieRepository;
    private readonly IMapper _mapper;

    public MovieDescriptionService(IMovieDescriotionReadRepository movieDescriptionReadRepository,
                                   IMovieDescriotionWriteRepository movieDescriptionWriteRepository,
                                   IReadActorMovieDescriptionRepository readActorMovieDescriptionRepository,
                                   IWriteActorMovieDescriptionRepository writeActorMovieDescriptionRepository,
                                   IReadCategoryMovieRepository readCategoryMovieRepository,
                                   IWriteCategoryMovieRepository writeCategoryMovieRepository,
                                   IMapper mapper)
    {
        _movieDescriptionReadRepository = movieDescriptionReadRepository;
        _movieDescriptionWriteRepository = movieDescriptionWriteRepository;
        _readActorMovieDescriptionRepository = readActorMovieDescriptionRepository;
        _writeActorMovieDescriptionRepository = writeActorMovieDescriptionRepository;
        _readCategoryMovieRepository = readCategoryMovieRepository;
        _writeCategoryMovieRepository = writeCategoryMovieRepository;
        _mapper = mapper;
    }

    public async Task<MovieDescriptionGetDto> GetByIdAsync(Guid movieId)
    {
        var movieDescription = await _movieDescriptionReadRepository.GetByIdAsyncExpression(x => x.MovieId == movieId);
        if (movieDescription is null) throw new NotFoundException("Movie Description Not Found");

        var toDto = _mapper.Map<MovieDescriptionGetDto>(movieDescription);
        toDto.actorMovieDescriptionsGetDto = await ActorMovieGetByIdAllAsync(movieDescription.Id);
        return toDto;
    }


    public async Task<List<ActorMovieDescriptionGetDto>> ActorMovieGetByIdAllAsync(Guid movieDescriptionId)
    {
        var actorMovieDescription = await _readActorMovieDescriptionRepository.GetAllExpression(x => x.movieDescriptionId == movieDescriptionId).ToListAsync();
        if (actorMovieDescription is null) throw new NotFoundException("Actor Movie Description Not Found");


        var toDto = _mapper.Map<List<ActorMovieDescriptionGetDto>>(actorMovieDescription);
        return toDto;
    }

    public async Task<List<CategoryMovieGetDto>> CategoryMovieGetByIdAllAsync(Guid movieId)
    {
        var categoryMovie = await _readCategoryMovieRepository.GetAllExpression(x => x.MovieId == movieId).ToListAsync();
        if (categoryMovie is null) throw new NotFoundException("Category Movie Not Found");


        var toDto = _mapper.Map<List<CategoryMovieGetDto>>(categoryMovie);
        return toDto;
    }
}
