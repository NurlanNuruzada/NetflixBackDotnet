using ParkCinema.Application.DTOs.Category;

namespace ParkCinema.Application.Abstraction.Services.CategoryService;

public interface ICategoryService
{
    Task<List<CategoryGetDto>> GetAllAsync();
    Task<CategoryGetDto> GetByIdAsync(Guid Id);
    Task CreateAsync(CategoryCreateDto categoryCreateDto);
    Task UpdateAsync(Guid Id, CategoryUpdateDto categoryUpdateDto);
    Task RemoveAsync(Guid Id);
}
