using ExpressionEvaluator.Models;

namespace ExpressionEvaluator.Interfaces
{
    public interface IExpressionRepository
    {
        Task<Expression> AddAsync(Expression expression);
        Task<IEnumerable<Expression>> GetByResultAsync(double result);
        Task<IEnumerable<Expression>> GetAllAsync();
    }
}