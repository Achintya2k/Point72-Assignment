using ExpressionEvaluator.Models.DTOs;
using ExpressionEvaluator.Services;
using ExpressionEvaluator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpressionEvaluator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ExpressionsController : ControllerBase
    {
        private readonly IExpressionService _expressionService;
        private readonly ILogger<ExpressionsController> _logger;

        public ExpressionsController(
            IExpressionService expressionService,
            ILogger<ExpressionsController> logger)
        {
            _expressionService = expressionService;
            _logger = logger;
        }

        /// <summary>
        /// Calculate a mathematical expression
        /// </summary>
        /// <param name="request">Expression to calculate</param>
        /// <returns>Calculation result</returns>
        [HttpPost("calculate")]
        [ProducesResponseType(typeof(CalculateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CalculateResponse>> Calculate(
            [FromBody] CalculateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (request.Expression.Length > 500)
                return BadRequest(new { error = "Expression too long" });

            try
            {
                var result = await _expressionService.CalculateAsync(request.Expression);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid expression: {Expression}", request.Expression);
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Find expressions by their calculated result
        /// </summary>
        /// <param name="result">Result value to search for</param>
        /// <returns>List of expressions with matching result</returns>
        [HttpGet("by-result/{result}")]
        [ProducesResponseType(typeof(IEnumerable<CalculateResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CalculateResponse>>> GetByResult(
            [FromRoute] double result)
        {
            var expressions = await _expressionService.FindByResultAsync(result);
            return Ok(expressions);
        }
    }
}
