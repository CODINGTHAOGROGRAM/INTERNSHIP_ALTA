using AutoMapper;
using LMS__Elibrary_BE.Models;
using LMS__Elibrary_BE.ModelsDTO;
using LMS_Library_API.Models;
using LMS_Library_API.Models.Exams;

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

            //Mapping Exam
            CreateMap<ExamDTO, Exam>();
            CreateMap<Exam, ExamDTO>();
            
            //Mapping QuestionBank
            CreateMap<QuestionBanks, QuestionBankDTO>();
            CreateMap<QuestionBankDTO, QuestionBanks>();

            //Mapping Student
            CreateMap<StudentDTO, Student>();
            CreateMap<StudentDTO, StudentDTO>();
        }

    }
}
