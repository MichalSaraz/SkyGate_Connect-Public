using System.Linq.Expressions;
using Web.Helpers;

namespace Web.Extensions;

/// <summary>
/// Provides extension methods for composing lambda expressions.
/// </summary>
public static class ExpressionExtensions
{
    /// <summary>
    /// Combines two lambda expressions into a single expression using a specified merge function.
    /// </summary>
    /// <typeparam name="T">The type of the input parameter for the lambda expressions.</typeparam>
    /// <param name="first">The first lambda expression.</param>
    /// <param name="second">The second lambda expression.</param>
    /// <param name="merge">A function that defines how to merge the bodies of the two expressions.</param>
    /// <returns>A new lambda expression that represents the composition of the two input expressions.</returns>
    public static Expression<Func<T, bool>> Compose<T>(this Expression<Func<T, bool>> first,
        Expression<Func<T, bool>> second, Func<Expression, Expression, Expression> merge)
    {
        // Build parameter map (from parameters of second to parameters of first)
        var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] })
            .ToDictionary(p => p.s, p => p.f);

        // Replace parameters in the second lambda expression with parameters from the first
        var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

        // Apply composition of lambda expression bodies to parameters from the first expression 
        return Expression.Lambda<Func<T, bool>>(merge(first.Body, secondBody), first.Parameters);
    }
}