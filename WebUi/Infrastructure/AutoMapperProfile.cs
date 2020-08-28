using AutoMapper;
using Domain.Entities;
using WebUi.Models;

namespace WebUi.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserView>();
            CreateMap<UserView, User>();
        }
    }
}
