using System.Linq.Expressions;

namespace Web.Helpers;

/// <summary>
/// A helper class that allows rebinding of parameters in LINQ expressions.
/// Inherits from <see cref="ExpressionVisitor"/> to traverse and modify expression trees.
/// </summary>
public class ParameterRebinder : ExpressionVisitor
{
    private readonly Dictionary<ParameterExpression, ParameterExpression> _map;
    
    private ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    {
        _map = map;
    }

    /// <summary>
    /// Replaces parameters in the given expression based on the provided mapping.
    /// </summary>
    /// <param name="map">A dictionary mapping original parameters to replacement parameters.</param>
    /// <param name="exp">The expression in which parameters will be replaced.</param>
    /// <returns>A new expression with parameters replaced.</returns>
    public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
    {
        return new ParameterRebinder(map).Visit(exp);
    }

    /// <inheritdoc/>
    protected override Expression VisitParameter(ParameterExpression p)
    {
        if (_map.TryGetValue(p, out var replacement))
        {
            p = replacement;
        }

        return base.VisitParameter(p);
    }
}