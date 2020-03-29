using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveExtraBlanks
{
    struct Args
    {
        public string inputFileName;
        public string outputFileName;
        public Args(string inputFileNameLine, string outputFileNameLine)
        {
            this.inputFileName = inputFileNameLine;
            this.outputFileName = outputFileNameLine;
        }
    };

    public class Program
    {
        static int Main(string[] args)
        {

            if (!CheckArguments(args))
            {
                Console.WriteLine("Invalud argument count\n" +
                "Usage: <inputFileName> <outputFileName>");
                return 1;
            }

            Args arguments = new Args(args[0], args[1]);
            CopyWithRemove(arguments.inputFileName, arguments.outputFileName);
            return 0;
        }
        public static bool CheckArguments(string[] args)
        {
            if (args.Length != 2)
            {
                return false;
            }

            return true;
        }
        public static bool CopyWithRemove(string inputFileName, string outputFileName)
        {
            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Failed to open \"" + inputFileName + "\" for reading");
                return false;
            }

            string line;
            StreamReader inputFile = new StreamReader(inputFileName);
            StreamWriter outputFile = new StreamWriter(outputFileName);

            while ((line = inputFile.ReadLine()) != null)
            {
                outputFile.WriteLine(RemoveExtraBlanks(line));
            }

            inputFile.Close();
            outputFile.Close();
            return true;
        }
      
        public static string RemoveExtraBlanks(string line)
        {
            line = line.Trim();
            line = Regex.Replace(line, "\\[ ]{2,}", " ");
            line = Regex.Replace(line, "\\t{2,}", "\t");
            line = Regex.Replace(line, "\\s{2,}", " ");
            return line;
        }
    }
}