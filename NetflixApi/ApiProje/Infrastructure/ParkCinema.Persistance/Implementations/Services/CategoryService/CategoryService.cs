using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.CategoryRepository;
using ParkCinema.Application.Abstraction.Services.CategoryService;
using ParkCinema.Application.DTOs.Category;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Exceptions;

namespace ParkCinema.Persistance.Implementations.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly IReadCategoryRepository _categoryReadRepository;
    private readonly IWriteCategoryRepository _categoryWriteRepository;
    private readonly IMapper _mapper;

    public CategoryService(IReadCategoryRepository categoryReadRepository,
                           IWriteCategoryRepository categoryWriteRepository,
                           IMapper mapper)
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CategoryCreateDto categoryCreateDto)
    {
        var newCategory = _mapper.Map<Category>(categoryCreateDto);
        await _categoryWriteRepository.AddAsync(newCategory);
        await _categoryWriteRepository.SaveChangeAsync();
    }

    public async Task<List<CategoryGetDto>> GetAllAsync()
    {
        var allCategory = await _categoryReadRepository.GetAll().ToListAsync();
        var toDto = _mapper.Map<List<CategoryGetDto>>(allCategory);
        return toDto;
    }

    public async Task<CategoryGetDto> GetByIdAsync(Guid Id)
    {
        var byCategory = await _categoryReadRepository.GetByIdAsync(Id);
        if (byCategory is null) throw new NotFoundException("Category Not Found");
        var toDto = _mapper.Map<CategoryGetDto>(byCategory);
        return toDto;
    }

    public async Task RemoveAsync(Guid Id)
    {
        var byCategory = await _categoryReadRepository.GetByIdAsync(Id);
        if (byCategory is null) throw new NotFoundException("Category Not Found");
        _categoryWriteRepository.Remove(byCategory);
        await _categoryWriteRepository.SaveChangeAsync();   
    }

    public async Task UpdateAsync(Guid Id, CategoryUpdateDto categoryUpdateDto)
    {
        var byCategory = await _categoryReadRepository.GetByIdAsync(Id);
        if (byCategory is null) throw new NotFoundException("Category Not Found");

        _mapper.Map(categoryUpdateDto, byCategory);
        await _categoryWriteRepository.SaveChangeAsync();
    }
}
