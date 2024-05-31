namespace BasicTextInterpreter;

/// <summary>
/// Composition of expressions: tries to match all the expressions of the list and stops
/// with the first element which match.
/// </summary>
public class ExpressionOr(IEnumerable<IExpression> expressions) : IExpression
{
    public bool IsMatching(string text, out IInterpretedElement production, out string remainingText)
    {
        foreach (var expression in expressions)
        {
            if (expression.IsMatching(text, out production, out remainingText))
            {
                return true;
            }
        }

        remainingText = text;
        production = new InterpretedElement("null");
        return false;
    }
}