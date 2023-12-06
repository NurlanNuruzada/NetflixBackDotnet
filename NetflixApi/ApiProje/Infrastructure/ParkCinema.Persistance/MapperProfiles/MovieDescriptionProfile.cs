using AutoMapper;
using ParkCinema.Application.DTOs.MovieDescription;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Persistance.MapperProfiles;

public class MovieDescriptionProfile:Profile
{
	public MovieDescriptionProfile()
	{
		CreateMap<MovieDescriptionCreateDto, MovieDescription>().ReverseMap();
		CreateMap<MovieDescriptionUpdateDto, MovieDescription>().ReverseMap();
		CreateMap<MovieDescriptionGetDto, MovieDescription>().ReverseMap();
	}
}
