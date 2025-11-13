using ExpressionEvaluator.Models.DTOs;

namespace ExpressionEvaluator.Interfaces
{
    public interface IExpressionService
    {
        Task<CalculateResponse> CalculateAsync(string expression);
        Task<IEnumerable<CalculateResponse>> FindByResultAsync(double result);
    }
}