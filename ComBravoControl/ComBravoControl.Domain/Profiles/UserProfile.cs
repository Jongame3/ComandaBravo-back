using AutoMapper;
using ComBravo.Domains.Entities.User;
using ComBravo.Domains.Models.User;

namespace ComBravo.Domains.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserData, UserDto>();
            CreateMap<UserData, UserDto>().ReverseMap();
        }
    }
}
