using Microsoft.AspNetCore.Mvc;
using ParkCinema.Application.Abstraction.Services.CategoryService;
using ParkCinema.Application.DTOs.Actor;
using ParkCinema.Application.DTOs.Category;
using System.Net;

namespace ParkCinema.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var actor = await _categoryService.GetAllAsync();
        return Ok(actor);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var byActor = await _categoryService.GetByIdAsync(id);
        return Ok(byActor);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlider([FromForm] CategoryCreateDto categoryCreateDto)
    {
        await _categoryService.CreateAsync(categoryCreateDto);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSlider(Guid Id, [FromForm] CategoryUpdateDto categoryUpdateDto)
    {
        await _categoryService.UpdateAsync(Id, categoryUpdateDto);
        return Ok();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        await _categoryService.RemoveAsync(id);
        return Ok();
    }
}

