using AutoMapper;
using Confitec.API.Domain.Commands.Requests.User;
using Confitec.API.Domain.Commands.Responses;
using Confitec.API.Models;

namespace Confitec.API.Mapping
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<User, CreateUserRequest>();
            CreateMap<User, UpdateUserRequest>();

            CreateMap<CreateUserRequest, User>();

            CreateMap<UpdateUserRequest, User>();

        }
    }
}
