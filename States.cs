using StringReader.Enum;

namespace StringReader;
internal static class States
{
    internal static Command SearchString(char ch)
    {
        return ch == '"' ? Command.InString : Command.LookForString;
    }

    internal static Command ReadChar(char ch, ref List<char> charList)
    {
        switch (ch)
        {
            case '"':
                return Command.LookForString;
            case '\\':
                return Command.ReadNextChar;
            default:
                charList.Add(ch);
                return Command.InString;
        }
    }

    internal static Command ReadNextChar(char ch, ref List<char> charList)
    {
        charList.Add(ch);
        return Command.InString;
    }
    
}