using System.ComponentModel.DataAnnotations;

namespace ExpressionEvaluator.Models.DTOs
{
    public class CalculateRequest
    {
        [Required(ErrorMessage = "Expression is required")]
        [MaxLength(500, ErrorMessage = "Expression cannot exceed 500 characters")]
        public string? Expression { get; set; }
    }
}