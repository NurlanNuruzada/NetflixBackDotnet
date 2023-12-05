using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.ActorMovieDescriptionRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.ActorRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.CategoryRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieCategoryRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieDescriotionRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.MovieRepository;
using ParkCinema.Application.Abstraction.Repositories.IEntityRepository.SliderRepository;
using ParkCinema.Application.Abstraction.Services;
using ParkCinema.Application.Validators.SliderValidators;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;
using ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.ActorMovieDescriptionRepository;
using ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.ActorRepository;
using ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.CategoryRepository;
using ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.MovieCategoryRepository;
using ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.MovieDescriotionRepository;
using ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.MovieRepository;
using ParkCinema.Persistance.Implementations.Repositories.IEntityRepository.SliderRepository;
using ParkCinema.Persistance.Implementations.Services;
using ParkCinema.Persistance.MapperProfiles;

namespace ParkCinema.Persistance.ExtensionsMethods;

public static class ServiceRegistration
{

    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString("Default"));
        });


        //Repository
        services.AddReadRepositories();
        services.AddWriteRepositories();

        //Service
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ISliderServices,SliderServices>();


        //User
        services.AddIdentity<AppUser, IdentityRole>(Options =>
        {
            Options.User.RequireUniqueEmail = true;
            Options.Password.RequireNonAlphanumeric = true;
            Options.Password.RequiredLength = 8;
            Options.Password.RequireDigit = true;
            Options.Password.RequireUppercase = true;
            Options.Password.RequireLowercase = true;

            Options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            Options.Lockout.MaxFailedAccessAttempts = 3;
            Options.Lockout.AllowedForNewUsers = true;
        }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();


        //Mapper
        services.AddAutoMapper(typeof(SliderProfile).Assembly);


        //Validator
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<SliderGetDtoValidator>();

    }

    private static void AddReadRepositories(this IServiceCollection services)
    {
        services.AddScoped<IReadActorMovieDescriptionRepository, ReadActorMovieDescriptionRepository>();
        services.AddScoped<IReadActorRepository, ReadActorRepository>();
        services.AddScoped<IReadCategoryRepository, ReadCategoryRepository>();
        services.AddScoped<IReadCategoryMovieRepository, ReadCategoryMovieRepository>();
        services.AddScoped<IMovieDescriotionReadRepository, MovieDescriotionReadRepository>();
        services.AddScoped<IMovieReadRepository, MovieReadRepository>();
        services.AddScoped<ISliderReadRepository, SliderReadRepository>();
    }

    private static void AddWriteRepositories(this IServiceCollection services) 
    {
        services.AddScoped<IWriteActorMovieDescriptionRepository, WriteActorMovieDescriptionRepository>();
        services.AddScoped<IWriteActorRepository, WriteActorRepository>();
        services.AddScoped<IWriteCategoryRepository, WriteCategoryRepository>();
        services.AddScoped<IWriteCategoryMovieRepository, WriteCategoryMovieRepository>();
        services.AddScoped<IMovieDescriotionWriteRepository, MovieDescriotionWriteRepository>();
        services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();
        services.AddScoped<ISliderWriteRepository, SliderWriteRepository>();
    }

}
