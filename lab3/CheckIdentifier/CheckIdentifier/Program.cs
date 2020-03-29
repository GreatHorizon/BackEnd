using System;

namespace CheckIdentifier
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (!CheckInput(args))
            {
                Console.WriteLine("Invalid argument count\nUsage: <identifier>");
                return 1;
            }

            if (!CheckIdentifier(args[0]))
            {
                return 1;
            }

            return 0;
        }

        public static bool IsLetter(char sybmol)
        {
            if (sybmol >= 65 && sybmol <= 90 || sybmol >= 97 && sybmol <= 122)
            {
                return true;
            }

            return false;
        }

        public static bool CheckIdentifier(string identifier)
        {
            if (identifier.Length == 0)
            {
                Console.WriteLine("No");
                Console.WriteLine("identifier could not be empty string");
                return false;

            }

            if (!IsLetter(identifier[0]))
            {
                Console.WriteLine("No");
                Console.WriteLine("First symbol should be a letter");
                return false;
            }

            for (int i = 1; i < identifier.Length; i++)
            {
                if (!IsLetter(identifier[i]) && !char.IsDigit(identifier[i]))
                {
                    Console.WriteLine("No");
                    Console.WriteLine(i + 1 + " symbol is not a letter and digit");
                    return false;
                }
            }

            Console.WriteLine("Yes");
            return true;
        }

        public static bool CheckInput(string[] args)
        {
            if (args.Length != 1)
            {
                return false;
            }

            return true;
        }
    }
}
