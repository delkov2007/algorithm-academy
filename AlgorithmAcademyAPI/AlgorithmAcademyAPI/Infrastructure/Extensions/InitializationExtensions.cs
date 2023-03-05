using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlgorithmAcademyAPI.Infrastructure.Extensions
{
    using AlgorithmAcademyAPI.Data;
    using AlgorithmAcademyAPI.Infrastructure.Profiles;

    public static class InitializationExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddDbContext<AlgorithmAcademyContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
            });
            services.AddSingleton(RegisterAutomapperProfiles);
        }



        private static IMapper RegisterAutomapperProfiles(IServiceProvider serviceProvider)
        {
            return new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<UserProfile>();

                configuration.ConstructServicesUsing(type => ActivatorUtilities.CreateInstance(serviceProvider, type));
            }).CreateMapper();
        }
    }
}
