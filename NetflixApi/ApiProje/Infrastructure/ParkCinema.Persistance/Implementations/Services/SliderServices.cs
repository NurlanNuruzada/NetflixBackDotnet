using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.SliderRepository;
using ParkCinema.Application.Abstraction.Services.EntitiyServices;
using ParkCinema.Application.DTOs;
using ParkCinema.Application.DTOs.Slider;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.ExtensionsMethods;

namespace ParkCinema.Persistance.Implementations.Services;

public class SliderServices : ISliderServices
{
    private readonly ISliderReadRepository _SliderReadRepository;
    private readonly ISliderWriteRepository _SliderWriteRepository;
    private readonly IMapper _mapper;

    public SliderServices(ISliderReadRepository sliderReadRepository,
                          ISliderWriteRepository sliderWriteRepository,
                          IMapper mapper)
    {
        _SliderReadRepository = sliderReadRepository;
        _SliderWriteRepository = sliderWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(SliderCreateDTO sliderCreateDTO)
    {
        var DtoToEntity = _mapper.Map<Slider>(sliderCreateDTO);
        if (sliderCreateDTO.Image is not null)
        {
            //DtoToEntity.ImagePath = await sliderCreateDTO.Image.GetBytes();
        }
        await _SliderWriteRepository.AddAsync(DtoToEntity);
        await _SliderWriteRepository.SaveChangeAsync();
    }

    public async Task<List<SliderGetDTO>> GetAllAsync()
    {
        var silder = await _SliderReadRepository.GetAll().OrderByDescending(x => x.CreatedDate).ToListAsync();
        if (silder is null) throw new NullReferenceException();
        var entityToDto = _mapper.Map<List<SliderGetDTO>>(silder);

        foreach (var dto in entityToDto)
        {
            Slider sliderTo = silder.FirstOrDefault(x => x.Id == dto.Id)
                                   ?? throw new NullReferenceException();

            List<string> images = new();
            //images.Add(Convert.ToBase64String(sliderTo.ImagePath));
            dto.imagePath = images[0];
        }
        return entityToDto;
    }

    public async Task<SliderGetDTO> GetByIdAsync(Guid Id)
    {
        var bySlider = await _SliderReadRepository.GetByIdAsync(Id);
        if (bySlider is null) throw new NullReferenceException();

        var toDto = _mapper.Map<SliderGetDTO>(bySlider);
        //toDto.imagePath = Convert.ToBase64String(bySlider.ImagePath);
        return toDto;
    }

    public async Task RemoveAsync(Guid Id)
    {
        var bySlider = await _SliderReadRepository.GetByIdAsync(Id);
        if (bySlider is null) throw new NullReferenceException();

        _SliderWriteRepository.Remove(bySlider);
        await _SliderWriteRepository.SaveChangeAsync();
    }

    public async Task Test(SliderCreateDTO sliderCreateDTO)
    {
        if (sliderCreateDTO.Image is not null)
        {
            Slider newSlider = _mapper.Map<Slider>(sliderCreateDTO);
            string currentDirectory = Directory.GetCurrentDirectory();
            int index = currentDirectory.IndexOf("ApiProje\\");
            if (index >= 0)
            {
                currentDirectory = currentDirectory.Substring(0, index + 8); // +8 to include "FinalApp\"
            }
            //Dynamic get current location
            string uploadsRootDirectory = Path.Combine(currentDirectory, "Images");
            Directory.CreateDirectory(uploadsRootDirectory);
            ReturnRootDto returnRootDto = new ReturnRootDto();
            returnRootDto.root = uploadsRootDirectory;
            //end

            //upload Image
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(sliderCreateDTO.Image.FileName);
            string filePath = Path.Combine(uploadsRootDirectory, fileName);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await sliderCreateDTO.Image.CopyToAsync(fileStream);
            }

            newSlider.ImagePath = fileName;
            await _SliderWriteRepository.AddAsync(newSlider);
            await _SliderWriteRepository.SaveChangeAsync();
        }
    }

    public async Task UpdateAsync(Guid Id, SliderUpdateDTO sliderUpdateDTO)
    {
        var bySlider = await _SliderReadRepository.GetByIdAsync(Id);
        if (bySlider is null) throw new NullReferenceException();

        //_mapper.Map(sliderUpdateDTO, bySlider);
        //if (sliderUpdateDTO.Image is not null)
        //    bySlider.ImagePath = await sliderUpdateDTO.Image.GetBytes();

        _SliderWriteRepository.Update(bySlider);
        await _SliderWriteRepository.SaveChangeAsync();
    }
}
