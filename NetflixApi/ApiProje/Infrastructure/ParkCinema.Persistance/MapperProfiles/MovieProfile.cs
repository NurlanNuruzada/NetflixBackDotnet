using AutoMapper;
using ParkCinema.Application.DTOs.Movie;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Persistance.MapperProfiles;

public class MovieProfile : Profile
{
	public MovieProfile()
	{
		CreateMap<MovieCreateDto, Movie>().ReverseMap();
		CreateMap<MovieUpdateDto, Movie>().ReverseMap();
		CreateMap<MovieGetDto, Movie>().ReverseMap();
	}
}
