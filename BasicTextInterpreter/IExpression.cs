namespace BasicTextInterpreter;

/// <summary>
/// One expression of the grammar
/// </summary>
public interface IExpression
{
    bool IsMatching(string text, out IInterpretedElement production, out string remainingText);
}