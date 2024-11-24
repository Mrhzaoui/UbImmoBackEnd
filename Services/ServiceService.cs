using Microsoft.EntityFrameworkCore;
using UBEE.Data;
using UBEE.Models;

namespace UBEE.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ApplicationDbContext _context;

        public ServiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Service> GetServiceById(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<(bool Succeeded, int ServiceId, string[] Errors)> CreateService(ServiceCreateDto model)
        {
            var service = new Service
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Category = model.Category
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return (true, service.Id, Array.Empty<string>());
        }

        public async Task<(bool Succeeded, string[] Errors)> UpdateService(int id, ServiceUpdateDto model)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return (false, new[] { "Service not found." });
            }

            service.Name = model.Name;
            service.Description = model.Description;
            service.Price = model.Price;
            service.Category = model.Category;

            await _context.SaveChangesAsync();

            return (true, Array.Empty<string>());
        }

        public async Task<(bool Succeeded, string[] Errors)> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return (false, new[] { "Service not found." });
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return (true, Array.Empty<string>());
        }
    }
}

