using AutoMapper;
using ParkCinema.Application.DTOs.CategoryMovie;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Persistance.MapperProfiles;

public class CategoryMovieProfile : Profile
{
	public CategoryMovieProfile()
	{
		CreateMap<CategoryMovieCreateDto, CategoryMovie>().ReverseMap();
		CreateMap<CategoryMovieUpdateDto, CategoryMovie>().ReverseMap();
		CreateMap<CategoryMovieGetDto, CategoryMovie>().ReverseMap();
	}
}
