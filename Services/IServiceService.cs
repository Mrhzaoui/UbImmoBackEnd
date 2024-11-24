using UBEE.Models;

namespace UBEE.Services
{
    public interface IServiceService
    {
        Task<Service> GetServiceById(int id);
        Task<IEnumerable<Service>> GetAllServices();
        Task<(bool Succeeded, int ServiceId, string[] Errors)> CreateService(ServiceCreateDto model);
        Task<(bool Succeeded, string[] Errors)> UpdateService(int id, ServiceUpdateDto model);
        Task<(bool Succeeded, string[] Errors)> DeleteService(int id);
    }
}

