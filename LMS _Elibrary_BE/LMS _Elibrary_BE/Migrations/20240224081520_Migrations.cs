using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS__Elibrary_BE.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    totalStudent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(20)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentNotificationFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    featureType = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNotificationFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Avartar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classId = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Class_classId",
                        column: x => x.classId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role_Permissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    CanAccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Permissions", x => new { x.RoleId, x.PermissionsId });
                    table.ForeignKey(
                        name: "FK_Role_Permissions_Permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Permissions_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Avartar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isLocked = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    TimeCounter = table.Column<DateTime>(type: "datetime2", nullable: false),
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentNotification_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentNotificationSetting",
                columns: table => new
                {
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    featuresId = table.Column<int>(type: "int", nullable: false),
                    receiveNotification = table.Column<bool>(type: "bit", nullable: false),
                    StudentNotificationFeaturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNotificationSetting", x => new { x.studentId, x.featuresId });
                    table.ForeignKey(
                        name: "FK_StudentNotificationSetting_StudentNotificationFeatures_StudentNotificationFeaturesId",
                        column: x => x.StudentNotificationFeaturesId,
                        principalTable: "StudentNotificationFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentNotificationSetting_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentQnALikes",
                columns: table => new
                {
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionsLikedID = table.Column<string>(type: "varchar", nullable: false),
                    AnswersLikedID = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQnALikes", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_StudentQnALikes_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Help",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Help", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Help_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    TimeCounter = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_User_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_User_SenderId",
                        column: x => x.SenderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NotificationSetting",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeaturesId = table.Column<int>(type: "int", nullable: false),
                    ReceiveNotification = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSetting", x => new { x.UserId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_NotificationSetting_NotificationFeatures_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "NotificationFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationSetting_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Modifier = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsImage = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateFile_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QnALikes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionsLikedID = table.Column<string>(type: "varchar(max)", nullable: false),
                    AnswersLikedID = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QnALikes", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_QnALikes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<string>(type: "varchar(20)", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_User_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SystemInfomation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolId = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SchoolWebsite = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SchoolType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LibrarySystemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LMSWebsite = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Language = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SchoolLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principals = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemInfomation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemInfomation_User_Principals",
                        column: x => x.Principals,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherClass",
                columns: table => new
                {
                    teacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    classId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClass", x => new { x.classId, x.teacherId });
                    table.ForeignKey(
                        name: "FK_TeacherClass_Class_classId",
                        column: x => x.classId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherClass_User_teacherId",
                        column: x => x.teacherId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubject",
                columns: table => new
                {
                    classId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    subjectId = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubject", x => new { x.classId, x.subjectId });
                    table.ForeignKey(
                        name: "FK_ClassSubject_Class_classId",
                        column: x => x.classId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubject_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomInfoOfSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    subjectId = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomInfoOfSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomInfoOfSubject_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(30)", nullable: false),
                    FileType = table.Column<string>(type: "varchar(30)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Format = table.Column<bool>(type: "bit", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "varchar", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CensorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherCreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exam_User_CensorId",
                        column: x => x.CensorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Exam_User_TeacherCreatedId",
                        column: x => x.TeacherCreatedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    dateSubmited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isHidden = table.Column<bool>(type: "bit", nullable: false),
                    numericalOrder = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    note = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    censorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    teacherCreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subjectId = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Part_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Part_User_censorId",
                        column: x => x.censorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Part_User_teacherCreatedId",
                        column: x => x.teacherCreatedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QuestionBanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Format = table.Column<bool>(type: "bit", nullable: false),
                    Content = table.Column<string>(type: "nvarchar", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherCreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionBanks_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionBanks_User_TeacherCreatedId",
                        column: x => x.TeacherCreatedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subjectId = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    subjectMark = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.studentId, x.subjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyTime",
                columns: table => new
                {
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subjectId = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    studyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyTime", x => new { x.studentId, x.subjectId });
                    table.ForeignKey(
                        name: "FK_StudyTime_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyTime_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    subjectId = table.Column<string>(type: "varchar(20)", nullable: false),
                    teacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectNotification_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectNotification_User_teacherId",
                        column: x => x.teacherId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExamRecentViews",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamRecentViews", x => new { x.UserId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_ExamRecentViews_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamRecentViews_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    dateSubmited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isHidden = table.Column<bool>(type: "bit", nullable: false),
                    numericalOrder = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    note = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    partId = table.Column<int>(type: "int", nullable: false),
                    censorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    teacherCreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_Part_partId",
                        column: x => x.partId,
                        principalTable: "Part",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lesson_User_censorId",
                        column: x => x.censorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Lesson_User_teacherCreatedId",
                        column: x => x.teacherCreatedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QB_Answer_Essay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmitType = table.Column<bool>(type: "bit", nullable: false),
                    LimitWord = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QB_Answer_Essay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QB_Answer_Essay_QuestionBanks_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QB_Answer_MC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerContent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QB_Answer_MC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QB_Answer_MC_QuestionBanks_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question_Exam",
                columns: table => new
                {
                    ExamId = table.Column<string>(type: "varchar(30)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question_Exam", x => new { x.ExamId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_Question_Exam_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Exam_QuestionBanks_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NotificationClassStudent",
                columns: table => new
                {
                    subjectNotificationId = table.Column<int>(type: "int", nullable: false),
                    classId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isForAllStudent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationClassStudent", x => new { x.subjectNotificationId, x.classId, x.studentId });
                    table.ForeignKey(
                        name: "FK_NotificationClassStudent_Class_classId",
                        column: x => x.classId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationClassStudent_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NotificationClassStudent_SubjectNotification_subjectNotificationId",
                        column: x => x.subjectNotificationId,
                        principalTable: "SubjectNotification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    submissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    note = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    lessonId = table.Column<int>(type: "int", nullable: false),
                    censorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    teacherCreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Lesson_lessonId",
                        column: x => x.lessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_User_censorId",
                        column: x => x.censorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Document_User_teacherCreatedId",
                        column: x => x.teacherCreatedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LessonAccess",
                columns: table => new
                {
                    lessonId = table.Column<int>(type: "int", nullable: false),
                    classId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    isForAllClasses = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonAccess", x => x.lessonId);
                    table.ForeignKey(
                        name: "FK_LessonAccess_Class_classId",
                        column: x => x.classId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonAccess_Lesson_lessonId",
                        column: x => x.lessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    likesCounter = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isTeacher = table.Column<bool>(type: "bit", nullable: false),
                    lessonId = table.Column<int>(type: "int", nullable: false),
                    teacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonQuestion_Lesson_lessonId",
                        column: x => x.lessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonQuestion_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonQuestion_User_teacherId",
                        column: x => x.teacherId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DocumentAccess",
                columns: table => new
                {
                    documentId = table.Column<int>(type: "int", nullable: false),
                    classId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    isForAllClasses = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAccess", x => x.documentId);
                    table.ForeignKey(
                        name: "FK_DocumentAccess_Class_classId",
                        column: x => x.classId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentAccess_Document_documentId",
                        column: x => x.documentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyHistory",
                columns: table => new
                {
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    documentId = table.Column<int>(type: "int", nullable: false),
                    watchMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyHistory", x => new { x.studentId, x.documentId });
                    table.ForeignKey(
                        name: "FK_StudyHistory_Document_documentId",
                        column: x => x.documentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyHistory_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    likesCounter = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isTeacher = table.Column<bool>(type: "bit", nullable: false),
                    lessonQuestionId = table.Column<int>(type: "int", nullable: false),
                    teacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonAnswer_LessonQuestion_lessonQuestionId",
                        column: x => x.lessonQuestionId,
                        principalTable: "LessonQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonAnswer_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LessonAnswer_User_teacherId",
                        column: x => x.teacherId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubject_subjectId",
                table: "ClassSubject",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomInfoOfSubject_subjectId",
                table: "CustomInfoOfSubject",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_censorId",
                table: "Document",
                column: "censorId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_lessonId",
                table: "Document",
                column: "lessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_teacherCreatedId",
                table: "Document",
                column: "teacherCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAccess_classId",
                table: "DocumentAccess",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CensorId",
                table: "Exam",
                column: "CensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_SubjectId",
                table: "Exam",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_TeacherCreatedId",
                table: "Exam",
                column: "TeacherCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRecentViews_ExamId",
                table: "ExamRecentViews",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Help_UserId",
                table: "Help",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_censorId",
                table: "Lesson",
                column: "censorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_partId",
                table: "Lesson",
                column: "partId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_teacherCreatedId",
                table: "Lesson",
                column: "teacherCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAccess_classId",
                table: "LessonAccess",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAnswer_lessonQuestionId",
                table: "LessonAnswer",
                column: "lessonQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAnswer_studentId",
                table: "LessonAnswer",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAnswer_teacherId",
                table: "LessonAnswer",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonQuestion_lessonId",
                table: "LessonQuestion",
                column: "lessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonQuestion_studentId",
                table: "LessonQuestion",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonQuestion_teacherId",
                table: "LessonQuestion",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_RecipientId",
                table: "Notification",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_SenderId",
                table: "Notification",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationClassStudent_classId",
                table: "NotificationClassStudent",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationClassStudent_studentId",
                table: "NotificationClassStudent",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationSetting_FeaturesId",
                table: "NotificationSetting",
                column: "FeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_Part_censorId",
                table: "Part",
                column: "censorId");

            migrationBuilder.CreateIndex(
                name: "IX_Part_subjectId",
                table: "Part",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Part_teacherCreatedId",
                table: "Part",
                column: "teacherCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateFile_UserId",
                table: "PrivateFile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QB_Answer_Essay_QuestionId",
                table: "QB_Answer_Essay",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QB_Answer_MC_QuestionId",
                table: "QB_Answer_MC",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBanks_SubjectId",
                table: "QuestionBanks",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBanks_TeacherCreatedId",
                table: "QuestionBanks",
                column: "TeacherCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Exam_QuestionId",
                table: "Question_Exam",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_PermissionsId",
                table: "Role_Permissions",
                column: "PermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_classId",
                table: "Student",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNotification_studentId",
                table: "StudentNotification",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNotificationSetting_StudentNotificationFeaturesId",
                table: "StudentNotificationSetting",
                column: "StudentNotificationFeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_subjectId",
                table: "StudentSubject",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyHistory_documentId",
                table: "StudyHistory",
                column: "documentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTime_subjectId",
                table: "StudyTime",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_DepartmentId",
                table: "Subject",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TeacherId",
                table: "Subject",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectNotification_subjectId",
                table: "SubjectNotification",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectNotification_teacherId",
                table: "SubjectNotification",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemInfomation_Principals",
                table: "SystemInfomation",
                column: "Principals",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClass_teacherId",
                table: "TeacherClass",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentId",
                table: "User",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassSubject");

            migrationBuilder.DropTable(
                name: "CustomInfoOfSubject");

            migrationBuilder.DropTable(
                name: "DocumentAccess");

            migrationBuilder.DropTable(
                name: "ExamRecentViews");

            migrationBuilder.DropTable(
                name: "Help");

            migrationBuilder.DropTable(
                name: "LessonAccess");

            migrationBuilder.DropTable(
                name: "LessonAnswer");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "NotificationClassStudent");

            migrationBuilder.DropTable(
                name: "NotificationSetting");

            migrationBuilder.DropTable(
                name: "PrivateFile");

            migrationBuilder.DropTable(
                name: "QB_Answer_Essay");

            migrationBuilder.DropTable(
                name: "QB_Answer_MC");

            migrationBuilder.DropTable(
                name: "QnALikes");

            migrationBuilder.DropTable(
                name: "Question_Exam");

            migrationBuilder.DropTable(
                name: "Role_Permissions");

            migrationBuilder.DropTable(
                name: "StudentNotification");

            migrationBuilder.DropTable(
                name: "StudentNotificationSetting");

            migrationBuilder.DropTable(
                name: "StudentQnALikes");

            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "StudyHistory");

            migrationBuilder.DropTable(
                name: "StudyTime");

            migrationBuilder.DropTable(
                name: "SystemInfomation");

            migrationBuilder.DropTable(
                name: "TeacherClass");

            migrationBuilder.DropTable(
                name: "LessonQuestion");

            migrationBuilder.DropTable(
                name: "SubjectNotification");

            migrationBuilder.DropTable(
                name: "NotificationFeatures");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "QuestionBanks");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "StudentNotificationFeatures");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
