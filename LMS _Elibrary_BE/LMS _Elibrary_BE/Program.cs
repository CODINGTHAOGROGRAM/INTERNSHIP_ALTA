
using AutoMapper;
using LMS__Elibrary_BE.Context;
using LMS__Elibrary_BE.Helpers;
using LMS__Elibrary_BE.Services.ClassServices;
using LMS__Elibrary_BE.Services.ClassSubjectServices;
using LMS__Elibrary_BE.Services.CustomInfoOfSubjectServices;
using LMS__Elibrary_BE.Services.DepartmentServices;
using LMS__Elibrary_BE.Services.DocumentAccessServices;
using LMS__Elibrary_BE.Services.ExamServices;
using LMS__Elibrary_BE.Services.FilePrivateServices;
using LMS__Elibrary_BE.Services.QuestionBankServices;
using LMS__Elibrary_BE.Services.QuestionExamServices;
using LMS__Elibrary_BE.Services.RoleServices;
using LMS__Elibrary_BE.Services.StudentQvsALikeServices;
using LMS__Elibrary_BE.Services.StudentServices;
using LMS__Elibrary_BE.Services.StudyHistoryServices;
using LMS__Elibrary_BE.Services.StudyTimeServices;
using LMS__Elibrary_BE.Services.SubjectServices;
using LMS__Elibrary_BE.Services.UserServices;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LMS__Elibrary_BE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            var connectString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectString));

            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUpLoadFileHelper, UpLoadFileHelper>();
            builder.Services.AddScoped<IFilePrivateService, FilePrivateService>();
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<IExamService,  ExamService>();
            builder.Services.AddScoped<IQuestionBankService, QuestionBankService>();
            builder.Services.AddScoped<ISubjectService, SubjectService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IClassSubjectService, ClassSubjectService>();
            builder.Services.AddScoped<IStudentQvsAService,  StudentQvsAService>();
            builder.Services.AddScoped<IQuestionExamService, QuestionExamService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IStudyTimeService, StudyTimeService>();
            builder.Services.AddScoped<IStudyHistoryService, StudyHistoryService>();
            builder.Services.AddScoped<ICustomInfoOfSubjectService, CustomInfoOfSubjectService>();
            builder.Services.AddScoped<IDocumentAccessService, DocumentAccessService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            var supportedCultures = new[] { new CultureInfo("en-US") };

           

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
