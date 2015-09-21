using System;
using System.Collections.Generic;

namespace CommandParser
{
    public class Program
    {
        public void Help()
        {
            Console.WriteLine(
            "CommandParser.exe have this commands:\n\t /?, /help, -help \n\t -k key1 value1 key2 value2\n\t -ping \n\t -print<massage>\n\t esc, stop, end - exit");
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
        public string ValuesToLine(List<string> values)
        {
            string result = null;
            int i = 0;
            while (i + 1 < values.Count)
            {
                result += values[i] + " - " + values[i + 1] + "\n";
                i += 2;
            }
            if (1 == values.Count % 2)
            {
                result += values[values.Count - 1] + " - null\n";
            }
            return result;
        }

        public void Parse()
        {
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
                var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
                        case "help":
                            Help();
                            break;
                    }
                    switch (words[i])
                    {
                        case "-ping":
                            Ping();
                            Console.WriteLine();
                            break;
                        case "-print":
                            while (i + 1 < words.Length && !words[i + 1].StartsWith("-"))
                            {
                                Print(words[++i]);
                            }
                            Console.WriteLine();
                            break;
                        case "-k":
                            var values = new List<string>();
                            while (i + 1 < words.Length && !words[i + 1].StartsWith("-"))
                            {
                                values.Add(words[++i]);
                            }
                            Console.Write(ValuesToLine(values));
                            break;

                        case "esc":
                        case "stop":
                        case "end":
                            return;
                        default:
                            Error(words[i]);
                            break;
                    }
                }
            }

        }

        private static void Main()
        {
            var parser = new Program();
            parser.Parse();

        }
    }
}