namespace ExpressionEvaluator.Models.DTOs
{
    public class CalculateResponse
    {
        public int Id { get; set; }
        public string? Expression { get; set; }
        public double Result { get; set; }
        public DateTime CalculatedAt { get; set; }
    }
}