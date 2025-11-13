using ExpressionEvaluator.DBContext;
using ExpressionEvaluator.Models;
using ExpressionEvaluator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpressionEvaluator.Repositories
{
    public class ExpressionRepository : IExpressionRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpressionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Expression> AddAsync(Expression expression)
        {
            _context.Expressions.Add(expression);
            await _context.SaveChangesAsync();
            return expression;
        }

        public async Task<IEnumerable<Expression>> GetByResultAsync(double result)
        {
            return await _context.Expressions
                .Where(e => Math.Abs(e.Result - result) < 0.0001)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expression>> GetAllAsync()
        {
            return await _context.Expressions
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }
    }
}
