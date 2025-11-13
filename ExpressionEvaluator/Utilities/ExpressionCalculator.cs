using System.Data;
using NCalc;

namespace ExpressionEvaluator.Utilities
{
    public class ExpressionCalculator
    {
        public static double Evaluate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("Expression cannot be empty");

            try
            {
                var expr = new Expression(expression);
                expr.EvaluateFunction += (name, args) => 
                {
                    throw new ArgumentException("Functions are not allowed");
                };
                
                var result = expr.Evaluate();
                
                if (result is double d)
                {
                    if (double.IsInfinity(d))
                        throw new ArgumentException("Result is infinity (division by zero?)");
                    if (double.IsNaN(d))
                        throw new ArgumentException("Result is not a valid number");
                    
                    return d;
                }
                
                return Convert.ToDouble(result);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Invalid expression: {ex.Message}", ex);
            }

        }

        private static bool IsValidExpression(string expression)
        {
            // Allow only digits, operators, parentheses, and decimal point
            return expression.All(c => char.IsDigit(c) || 
                                      c == '+' || c == '-' || c == '*' || 
                                      c == '/' || c == '(' || c == ')' || 
                                      c == '.');
        }
    }
}
