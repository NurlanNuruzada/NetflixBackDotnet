using AutoMapper;
using ParkCinema.Application.DTOs.ActorMovieDescription;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Persistance.MapperProfiles;

public class ActorMovieDescriptionProfile : Profile
{
	public ActorMovieDescriptionProfile()
	{
		CreateMap<ActorMovieDescriptionCreateDto, ActorMovieDescription>().ReverseMap();
		CreateMap<ActorMovieDescriptionUpdateDto, ActorMovieDescription>().ReverseMap();
		CreateMap<ActorMovieDescriptionGetDto, ActorMovieDescription>().ReverseMap();
	}
}
