using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.Services.SystemInforServices
{
    public interface ISystemInforService
    {
        Task<SystemInfomation> GetInforSystem(Guid id);
        Task<string> AddGetInfor(SystemInfomation newSystem);
        Task<string> RemoveGetInfor(Guid id);
        Task<string> UpdateInfor(SystemInfomation systemObj);

    }
}
