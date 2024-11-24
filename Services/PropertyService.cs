using Microsoft.EntityFrameworkCore;
using UBEE.Data;
using UBEE.Models;

namespace UBEE.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _context;

        public PropertyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Property> GetPropertyById(int id)
        {
            return await _context.Properties.FindAsync(id);
        }

        public async Task<IEnumerable<Property>> GetAllProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task<(bool Succeeded, int PropertyId, string[] Errors)> CreateProperty(PropertyCreateDto model)
        {
            var property = new Property
            {
                UserId = model.UserId,
                Address = model.Address,
                Price = model.Price,
                Description = model.Description
            };

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return (true, property.Id, Array.Empty<string>());
        }

        public async Task<(bool Succeeded, string[] Errors)> UpdateProperty(int id, PropertyUpdateDto model)
        {
            var property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return (false, new[] { "Property not found." });
            }

            property.Address = model.Address;
            property.Price = model.Price;
            property.Description = model.Description;

            await _context.SaveChangesAsync();

            return (true, Array.Empty<string>());
        }

        public async Task<(bool Succeeded, string[] Errors)> DeleteProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return (false, new[] { "Property not found." });
            }

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return (true, Array.Empty<string>());
        }
    }
}

