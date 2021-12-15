//using System.Collections.Generic;
//using Application.Common.Mappings;
//using AutoMapper;
//using Domain.Entities;

//namespace Application.Users.Queries
//{
//    public class UserVm : IMapFrom<User>
//    {
//        public string Id { get; set; }
//        public string Name { get; set; }
//        public string Email { get; set; }

//        public void Mapping(Profile profile)
//        {
//            profile.CreateMap<User, UserVm>()
//                   .ForMember(e => e.Name, opt => opt.MapFrom(x => x.UserName));

//            profile.CreateMap<List<User>, List<UserVm>>();
//        }
//    }
//}