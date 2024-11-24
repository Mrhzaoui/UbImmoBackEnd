using System.ComponentModel.DataAnnotations;

namespace UBEE.Models
{
    public class AiEvaluationCreateDtos
    {
        [Required]
        public int PropertyId { get; set; }
    }

    public class AIEvaluationUpdateDto
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal EstimatedValue { get; set; }

        [Required]
        public string OptimizationSuggestions { get; set; }
    }
}

