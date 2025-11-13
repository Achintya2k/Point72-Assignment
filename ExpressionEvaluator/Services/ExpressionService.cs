using ExpressionEvaluator.Models;
using ExpressionEvaluator.Models.DTOs;
using ExpressionEvaluator.Repositories;
using ExpressionEvaluator.Interfaces;
using ExpressionEvaluator.Utilities;

namespace ExpressionEvaluator.Services
{
    public class ExpressionService : IExpressionService
    {
        private readonly IExpressionRepository _repository;
        private readonly ILogger<ExpressionService> _logger;

        public ExpressionService(
            IExpressionRepository repository,
            ILogger<ExpressionService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CalculateResponse> CalculateAsync(string expression)
        {
            try
            {
                var result = ExpressionCalculator.Evaluate(expression);

                var expressionEntity = new Expression
                {
                    ExpressionString = expression,
                    Result = result,
                    CreatedAt = DateTime.UtcNow
                };

                var savedExpression = await _repository.AddAsync(expressionEntity);

                _logger.LogInformation(
                    "Expression calculated: {Expression} = {Result}", 
                    expression, 
                    result);

                return MapToResponse(savedExpression);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating expression: {Expression}", expression);
                throw;
            }
        }

        public async Task<IEnumerable<CalculateResponse>> FindByResultAsync(double result)
        {
            var expressions = await _repository.GetByResultAsync(result);
            return expressions.Select(MapToResponse);
        }

        private static CalculateResponse MapToResponse(Expression expression)
        {
            return new CalculateResponse
            {
                Id = expression.Id,
                Expression = expression.ExpressionString,
                Result = expression.Result,
                CalculatedAt = expression.CreatedAt
            };
        }
    }
}
