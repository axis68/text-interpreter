// Example program to demonstrate the parsing of a single row.

using BasicTextInterpreter;

var allKindOfExpressions = new List<IExpression>()
{
    new ExpressionBasic("Select", "^Select the menu(.*)$"),
    new ExpressionBasic("And", "^and(.*)$"),
    new ExpressionBasic("Click", "click the button(.*)$")
};
var interpretationGrammar = new ExpressionOr(allKindOfExpressions);
var parsedProduction = new List<IInterpretedElement>();

var text = "Select the menu and click the button";

while (text.Length > 0)
{
    if (interpretationGrammar.IsMatching(text, out var production, out var remainingText))
    {
        parsedProduction.Add(production);
        text = remainingText;
        continue;
    }

    throw new Exception($"Text cannot be interpreted {text}");
}

Console.WriteLine("Production:");
foreach (var production in parsedProduction)
{
    Console.WriteLine($"- {production.GetText()}");
}
