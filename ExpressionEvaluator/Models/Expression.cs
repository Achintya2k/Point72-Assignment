using System.ComponentModel.DataAnnotations;

namespace ExpressionEvaluator.Models
{
    public class Expression
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string? ExpressionString { get; set; }
        
        public double Result { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}