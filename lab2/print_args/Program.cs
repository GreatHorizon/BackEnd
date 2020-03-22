using System;

namespace printArgs
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No parameters were specified!");
            }
            else
            {
                Console.WriteLine("Number of arguments: " + args.Length);
                Console.Write("Arguments: ");

                for (int i = 0; i < args.Length; i++)
                {
                    Console.Write(args[i] + " ");
                }
            }
        }
    }
}
