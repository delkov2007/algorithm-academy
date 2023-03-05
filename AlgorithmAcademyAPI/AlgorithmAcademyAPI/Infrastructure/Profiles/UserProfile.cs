using AlgorithmAcademyAPI.Data.Entities;
using AutoMapper;

namespace AlgorithmAcademyAPI.Infrastructure.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserContact, Core.Models.Users.UserContact>();
            CreateMap<Name, Core.Models.Users.Name>();
            CreateMap<UserType, Core.Models.Users.UserType>();
            CreateMap<User, Core.Models.Users.User>();

        }
    }
}
