using AutoMapper;
using BreakingNewsCore.DTO.UsersDTO;
using BreakingNewsCore.Entities.UserEntity;

namespace BreakingNewsCore.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id));
        }
    }
}