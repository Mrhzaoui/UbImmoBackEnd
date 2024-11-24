namespace UBEE.Models
{
    public class AIEvaluation
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public decimal EstimatedValue { get; set; }

        public string OptimizationSuggestions { get; set; }

        public DateTime EvaluationDate { get; set; }

        public Property Property { get; set; }
    }
}

