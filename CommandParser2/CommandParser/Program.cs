using System;

namespace CommandParser
{
    internal class Program
    {
        public void Help()
        {
            Console.WriteLine(
            "CommandParser.exe have this commands:\n\t /?, /help, -help \n\t -k key1 value1 key2 value2\n\t -ping \n\t -print<massage>");
        }

        public void Ping()
        {
            const string value = "Pinging ...";
            foreach (var t in value)
            {
                Console.Write(t);
                Console.Beep();
            }
        }

        public void Print(string message)
        {
            Console.Write("{0} ", message);
        }

        public void Error(string value)
        {
            Console.WriteLine(
            "Command <{0}> is not supported, use CommandParser.exe /? to see set of allowed commands", value);
        }

        private static void Main()
        {
            var parser = new Program();
            Console.WriteLine("Hello. This is CommandParser.");
            Console.WriteLine("Please, enter data");
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    continue;
                }
                line = line.ToLower();
                var words = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < words.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Command -->  " + words[i] + "!");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    switch (words[i])
                    {
                        case "":
                        case "/?":
                        case "-help":
                        case "/help":
                            parser.Help();
                            break;
                    }
                    switch (words[i])
                    {
                        case "-ping":
                            parser.Ping();
                            Console.WriteLine();
                            break;
                        case "-print":
                            while (i + 1 < words.Length && !words[i + 1].StartsWith("-"))
                            {
                                parser.Print(words[++i]);
                            }
                            Console.WriteLine();
                            break;
                        case "-k":
                            while (i + 1 < words.Length && !words[i + 1].StartsWith("-"))
                            {
                                Console.Write(words[i + 1] + " - ");
                                if (i + 2 < words.Length && !words[i + 2].StartsWith("-"))
                                {
                                    Console.WriteLine(words[i + 2]);
                                    i += 2;
                                }
                                else
                                {
                                    Console.WriteLine("null");
                                    ++i;
                                }

                            }
                            break;
                        default:
                            parser.Error(words[i]);
                            break;
                    }
                }
            }
        }
    }
}