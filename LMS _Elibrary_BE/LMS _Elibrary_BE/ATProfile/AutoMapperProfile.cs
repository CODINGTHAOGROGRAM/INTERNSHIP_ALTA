using AutoMapper;
using LMS__Elibrary_BE.Models;
using LMS__Elibrary_BE.ModelsDTO;
using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.ATProfile
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile() 
        {
            //Mapping Role
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();

            //Mapping User
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            //Mapping Class
            CreateMap<Class, ClassDTO>();
            CreateMap<ClassDTO, Class>();   

        }

    }
}
