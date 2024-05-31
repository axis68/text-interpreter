namespace BasicTextInterpreter;

public class InterpretedElement(string expressionName) : IInterpretedElement
{
    public string GetText()
    {
        return expressionName;
    }
}