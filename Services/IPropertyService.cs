using UBEE.Models;

namespace UBEE.Services
{
    public interface IPropertyService
    {
        Task<Property> GetPropertyById(int id);
        Task<IEnumerable<Property>> GetAllProperties();
        Task<(bool Succeeded, int PropertyId, string[] Errors)> CreateProperty(PropertyCreateDto model);
        Task<(bool Succeeded, string[] Errors)> UpdateProperty(int id, PropertyUpdateDto model);
        Task<(bool Succeeded, string[] Errors)> DeleteProperty(int id);
    }
}

