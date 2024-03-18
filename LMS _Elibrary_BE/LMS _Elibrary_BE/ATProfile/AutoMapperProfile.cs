using AutoMapper;
using LMS__Elibrary_BE.Models;
using LMS__Elibrary_BE.ModelsDTO;
using LMS_Library_API.Models;
using LMS_Library_API.Models.AboutSubject;
using LMS_Library_API.Models.AboutUser;
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


            //Mapping LessonAnswer
            CreateMap<LessonAnswerDTO, LessonAnswer>();
            CreateMap<LessonAnswer, LessonAnswerDTO>();

            //Mapping LessonQuestion
            CreateMap<LessonQuestionDTO, LessonQuestion>();
            CreateMap<LessonQuestion, LessonQuestionDTO>();

            //Mapping NotificationClassStudent
            CreateMap<NotificationClassStudentDTO, NotificationClassStudent>();
            CreateMap<NotificationClassStudent, NotificationClassStudentDTO>();

            //Mapping Part
            CreateMap<PartDTO, Part>();
            CreateMap<Part, PartDTO>();

            //Mapping SystemInformation
            CreateMap<SystemDTO, SystemInfomation>();
            CreateMap<SystemInfomation, SystemDTO>();

            //Mapping ExamRecent
            CreateMap<ExamRecentDTO, ExamRecentViews>();
            CreateMap<ExamRecentViews, ExamRecentDTO>();
            
            //Mapping Help
            CreateMap<HelpDTO, Help>();
            CreateMap<Help, HelpDTO>();

            //Mapping QvsAlike
            CreateMap<QvsALikeDTO, QnALikeDTO>();
            CreateMap<QnALikeDTO, QvsALikeDTO>();

            //Mapping TeacherClass
            CreateMap<TeacherClassDTO, TeacherClass>();
            CreateMap<TeacherClass, TeacherClassDTO>();
        }

    }
}
