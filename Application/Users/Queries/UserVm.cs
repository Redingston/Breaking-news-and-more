using System.Collections.Generic;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Queries
{
    public class UserVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}