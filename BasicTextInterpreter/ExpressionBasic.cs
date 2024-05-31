using System.Text.RegularExpressions;

namespace BasicTextInterpreter;

/// <summary>
/// A basic expression of the grammar, defined by its RegEx pattern.
/// </summary>
public class ExpressionBasic(string expressionName, string regExPattern) : IExpression
{
    public bool IsMatching(string text, out IInterpretedElement production, out string remainingText)
    {
        var matchResult = Regex.Match(text, regExPattern);
        if (matchResult.Success)
        {
            remainingText = matchResult.Groups[1].Value.Trim();
            production = new InterpretedElement(expressionName);
            return true;
        }

        remainingText = text;
        production = new InterpretedElement("null");
        return false;
    }
}