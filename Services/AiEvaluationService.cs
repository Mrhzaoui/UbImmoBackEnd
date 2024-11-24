using UBEE.Data;
using UBEE.Models;

namespace UBEE.Services
{
    public interface IAIEvaluationService
    {
        Task<AIEvaluation> EvaluateProperty(int propertyId);
    }

    public class AIEvaluationService : IAIEvaluationService
    {
        private readonly ApplicationDbContext _context;

        public AIEvaluationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AIEvaluation> EvaluateProperty(int propertyId)
        {
            var property = await _context.Properties.FindAsync(propertyId);
            if (property == null)
            {
                throw new ArgumentException("Property not found");
            }

            // This is where you would integrate with an actual AI service
            // For now, we'll use a simple placeholder implementation
            var evaluation = new AIEvaluation
            {
                PropertyId = propertyId,
                EstimatedValue = property.Price * 1.1m, // Placeholder: 10% higher than listed price
                OptimizationSuggestions = "Consider updating the property description with more details.",
                EvaluationDate = DateTime.UtcNow
            };

            _context.AIEvaluations.Add(evaluation);
            await _context.SaveChangesAsync();

            return evaluation;
        }
    }
}

