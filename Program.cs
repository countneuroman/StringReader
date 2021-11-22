using static StringReader.Enum.Command;

namespace StringReader
{
    internal static class Program
    {
        private const string _path = "./resources/test.txt";
        private static void Main()
        {
            var charList = new List<char>();
            string str = Reader();
            var action = LookForString;
            foreach (var ch in str)
            {
                action = action switch
                {
                    LookForString => States.SearchString(ch),
                    InString => States.ReadChar(ch, ref charList),
                    ReadNextChar => States.ReadNextChar(ch, ref charList),
                    _ => action
                };
            }

            foreach (var c in charList)
            {
                Console.Write(c);
            }
            
            Console.ReadKey();
        }
        
        private static string Reader()
        {
            try
            {
                return File.ReadAllText(_path);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: e.Message");
                throw;
            }
        }
    }
}
