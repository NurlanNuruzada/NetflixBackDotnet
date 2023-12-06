using AutoMapper;
using ParkCinema.Application.DTOs.Actor;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Persistance.MapperProfiles;

public class ActorProfile : Profile
{
	public ActorProfile()
	{
		CreateMap<ActorCreateDto, Actor>().ReverseMap();
		CreateMap<ActorUpdateDto, Actor>().ReverseMap();
		CreateMap<ActorGetDto, Actor>().ReverseMap();
	}
}
