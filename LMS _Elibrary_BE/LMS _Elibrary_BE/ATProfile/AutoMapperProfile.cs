using AutoMapper;
using LMS__Elibrary_BE.Models;
using LMS__Elibrary_BE.ModelsDTO;

namespace LMS__Elibrary_BE.ATProfile
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile() 
        {
            //Mapping Role
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();



        }

    }
}
