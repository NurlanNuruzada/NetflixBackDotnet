using AutoMapper;
using ParkCinema.Application.DTOs.Category;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Persistance.MapperProfiles;

public class CategoryProfile : Profile
{
	public CategoryProfile()
	{
		CreateMap<CategoryCreateDto, Category>();	
		CreateMap<CategoryUpdateDto, Category>();	
		CreateMap<CategoryGetDto, Category>();	
	}
}
