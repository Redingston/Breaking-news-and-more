using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries.Users
{
    public class UserVm : IMapFrom<User>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserVm>()
                   .ForMember(e => e.Name, opt => opt.MapFrom(x => x.UserName));
        }
    }
}