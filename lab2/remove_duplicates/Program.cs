using System;
using System.Linq;

namespace removeDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!" + "\n" + "Usage remove_duplicates.exe < input string >");
            }
            else
            {
                string resultString;
                resultString = new string(args[0].Distinct().ToArray());
                Console.WriteLine(resultString);
            }
        }
    }
}
