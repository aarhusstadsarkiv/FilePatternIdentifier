using System;

namespace FilePatternIdentifier
{
    class Program
    {
        static void Main(string[] args)
        {
            PatternIdentifier Identifier = new PatternIdentifier();
            Console.WriteLine("Please specify a directory: ");
            string directory = Console.ReadLine();
            
            Console.WriteLine("Specify the number of bytes to read from each file");
            string n_bytes_input = Console.ReadLine();
            int n_bytes;

            try
            {
                n_bytes = int.Parse(n_bytes_input);
            }

            catch(FormatException)
            {
                Console.WriteLine(String.Format("The entered value {0} is not a valid number", n_bytes_input));
                Console.WriteLine("Reading 8 bytes from each file as default");
                n_bytes = 8;
            }

           Identifier.IdentifyPatterns(directory, n_bytes);
           Console.WriteLine("\nPress enter to exit the application"); 
           Console.ReadLine();
        }
    }
}
