using LMS_Library_API.Models.AboutStudent;
using LMS_Library_API.Models.AboutSubject;
using LMS_Library_API.Models.AboutUser;
using LMS_Library_API.Models.Exams;
using LMS_Library_API.Models.Notification;
using LMS_Library_API.Models.StudentNotification;
using LMS_Library_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using LMS__Elibrary_BE.Models;

namespace LMS__Elibrary_BE.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<SystemInfomation> SystemInfomation { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationFeatures> NotificationFeatures { get; set; }
        public DbSet<NotificationSetting> NotificationSetting { get; set; }
        public DbSet<QnALikes> QnALikes { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<PrivateFile> PrivateFiles { get; set; }
        public DbSet<ExamRecentViews> ExamRecentViews { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<QuestionBanks> QuestionBanks { get; set; }
        public DbSet<QB_Answer_Essay> QB_Answers_Essay { get; set; }
        public DbSet<QB_Answer_MC> QB_Answers_MC { get; set; }
        public DbSet<Question_Exam> Question_Exam { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonQuestion> LessonQuestions { get; set; }
        public DbSet<LessonAnswer> LessonAnswers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<CustomInfoOfSubject> CustomInfoOfSubjects { get; set; }
        public DbSet<SubjectNotification> SubjectNotifications { get; set; }
        public DbSet<NotificationClassStudent> NotificationClassStudents { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentQnALikes> StudentQnALikes { get; set; }
        public DbSet<StudentNotification> StudentNotifications { get; set; }
        public DbSet<StudentNotificationSetting> StudentNotificationSetting { get; set; }
        public DbSet<StudentNotificationFeatures> StudentNotificationFeatures { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<StudyTime> StudyTimes { get; set; }
        public DbSet<StudyHistory> StudyHistories { get; set; }
        public DbSet<LessonAccess> LessonAccess { get; set; }
        public DbSet<DocumentAccess> DocumentAccess { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<SystemInfomation>().ToTable("SystemInfomation");
            modelBuilder.Entity<Notification>().ToTable("Notification");
            modelBuilder.Entity<NotificationFeatures>().ToTable("NotificationFeatures");
            modelBuilder.Entity<NotificationSetting>().ToTable("NotificationSetting");
            modelBuilder.Entity<QnALikes>().ToTable("QnALikes");
            modelBuilder.Entity<Help>().ToTable("Help");
            modelBuilder.Entity<PrivateFile>().ToTable("PrivateFile");
            modelBuilder.Entity<ExamRecentViews>().ToTable("ExamRecentViews");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Exam>().ToTable("Exam");
            modelBuilder.Entity<QuestionBanks>().ToTable("QuestionBanks");
            modelBuilder.Entity<QB_Answer_Essay>().ToTable("QB_Answer_Essay");
            modelBuilder.Entity<QB_Answer_MC>().ToTable("QB_Answer_MC");
            modelBuilder.Entity<Question_Exam>().ToTable("Question_Exam");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<Part>().ToTable("Part");
            modelBuilder.Entity<Lesson>().ToTable("Lesson");
            modelBuilder.Entity<LessonQuestion>().ToTable("LessonQuestion");
            modelBuilder.Entity<LessonAnswer>().ToTable("LessonAnswer");
            modelBuilder.Entity<Document>().ToTable("Document");
            modelBuilder.Entity<CustomInfoOfSubject>().ToTable("CustomInfoOfSubject");
            modelBuilder.Entity<SubjectNotification>().ToTable("SubjectNotification");
            modelBuilder.Entity<NotificationClassStudent>().ToTable("NotificationClassStudent");
            modelBuilder.Entity<Class>().ToTable("Class");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<StudentNotificationFeatures>().ToTable("StudentNotificationFeatures");
            modelBuilder.Entity<StudentNotification>().ToTable("StudentNotification");
            modelBuilder.Entity<StudentQnALikes>().ToTable("StudentQnALikes");
            modelBuilder.Entity<StudentNotificationSetting>().ToTable("StudentNotificationSetting");
            modelBuilder.Entity<StudentSubject>().ToTable("StudentSubject");
            modelBuilder.Entity<ClassSubject>().ToTable("ClassSubject");
            modelBuilder.Entity<TeacherClass>().ToTable("TeacherClass");
            modelBuilder.Entity<StudyTime>().ToTable("StudyTime");
            modelBuilder.Entity<StudyHistory>().ToTable("StudyHistory");
            modelBuilder.Entity<LessonAccess>().ToTable("LessonAccess");
            modelBuilder.Entity<DocumentAccess>().ToTable("DocumentAccess");


            modelBuilder.Entity<NotificationSetting>()
            .HasKey(ns => new { ns.UserId, ns.FeaturesId });

            modelBuilder.Entity<Question_Exam>()
            .HasKey(qe => new { qe.ExamId, qe.QuestionId });

            modelBuilder.Entity<ExamRecentViews>()
            .HasKey(erv => new { erv.UserId, erv.ExamId });

            modelBuilder.Entity<NotificationClassStudent>()
            .HasKey(ncs => new { ncs.subjectNotificationId, ncs.classId, ncs.studentId });

            modelBuilder.Entity<StudentNotificationSetting>()
            .HasKey(sns => new { sns.studentId, sns.featuresId });

            modelBuilder.Entity<StudentSubject>()
            .HasKey(ss => new { ss.studentId, ss.subjectId });

            modelBuilder.Entity<ClassSubject>()
           .HasKey(cs => new { cs.classId, cs.subjectId });

            modelBuilder.Entity<TeacherClass>()
            .HasKey(tc => new { tc.classId, tc.teacherId });

            modelBuilder.Entity<StudyTime>()
            .HasKey(st => new { st.studentId, st.subjectId });

            modelBuilder.Entity<StudyHistory>()
            .HasKey(sh => new { sh.studentId, sh.documentId });

        }

    } 
}
