using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrength
{
    public class Program
    {
        public struct Args
        {
            public string password;
            public Args(string password)
            {
                this.password = password;
            }
        };

        static int Main(string[] args)
        {
            Args? argument = ParseArgument(args);
            if (argument == null)
            {
                Console.WriteLine("Invalid argument count");
                Console.WriteLine("Usage: <password>");
                return 1;
            }

            if (!IsCorrectPassword(argument.Value.password))
            {
                Console.WriteLine("Ivalid password");
                Console.WriteLine("Password should contain symbols from \"A\" to \"Z\" or from \"a\" to \"z\" or digits");
                return 1;
            }

            Console.WriteLine(CalculateStrength(argument.Value.password));
            Console.Read();
            return 0;

        }

        public static bool IsCorrectPassword(string password)
        {
            if (password.Length == 0)
            {
                return false;
            }

            foreach (var symbol in password)
            {
                if (!(symbol >= 65 && symbol <= 90) && !(symbol >= 97 && symbol <= 122) && !char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        public static int CalculateStrength(string password)
        {
            int passwordStrength = 0;
            passwordStrength += CalculateStrengthByLength(password);
            passwordStrength += CalculateStrengthByDigitAmount(password);
            passwordStrength += CalculateStrengthByUpperCaseLettersAmount(password);
            passwordStrength += CalculateStrengthByLowerCaseLettersAmount(password);
            passwordStrength += CalculateStrengthByOnlyLetters(password);
            passwordStrength += CalculateStrengthByOnlyDigits(password);
            passwordStrength += CalculateStrengthByRepeatingSymbols(password);
            return passwordStrength;
        }

        public static int CalculateStrengthByLength(string password)
        {
            return password.Length * 4;
        }

        public static int CalculateStrengthByDigitAmount(string password)
        {
            int digitAmount = 0;

            foreach (var symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitAmount++;
                }
            }

            return digitAmount * 4;
        }

        public static int CalculateStrengthByUpperCaseLettersAmount(string password)
        {
            int upperCaseLettersAmount = 0;
            foreach (var symbol in password)
            {
                if (char.IsUpper(symbol))
                {
                    upperCaseLettersAmount++;
                }
            }

            if (upperCaseLettersAmount == 0)
            {
                return 0;
            }

            return (password.Length - upperCaseLettersAmount) * 2;
        }

        public static int CalculateStrengthByOnlyLetters(string password)
        {
            bool onlyLetters = true;
            foreach (var symbol in password)
            {
                if (!char.IsLetter(symbol))
                {
                    onlyLetters = false;
                }
            }

            if (onlyLetters)
            {
                return -password.Length;
            }

            return 0;
        }

        public static int CalculateStrengthByOnlyDigits(string password)
        {
            bool onlyDigits = true;
            foreach (var symbol in password)
            {
                if (!char.IsDigit(symbol))
                {
                    onlyDigits = false;
                }
            }

            if (onlyDigits)
            {
                return -password.Length;
            }

            return 0;
        }

        public static int CalculateStrengthByLowerCaseLettersAmount(string password)
        {
            int lowerCaseLettersAmount = 0;
            foreach (var symbol in password)
            {
                if (char.IsLower(symbol))
                {
                    lowerCaseLettersAmount++;
                }
            }

            if (lowerCaseLettersAmount == 0)
            {
                return 0;
            }

            return (password.Length - lowerCaseLettersAmount) * 2;
        }

        public static int CalculateStrengthByRepeatingSymbols(string password)
        {
            int result = 0;
            int count = 1;
            char prevSymbol = '\0';
            char[] symbolsArray;
            symbolsArray = password.ToCharArray();
            Array.Sort(symbolsArray);

            for (int i = 0; i < symbolsArray.Length; i++)
            {
                if (symbolsArray[i] == prevSymbol)
                {
                    count++;
                }
                else
                {
                    prevSymbol = symbolsArray[i];
                    if (count > 1)
                    {
                        result += count;
                        count = 1;
                    }
                }

                if (i == symbolsArray.Length - 1 && count > 1)
                {
                    result += count;
                }
            }

            return -result;
        }

        public static Args? ParseArgument(string[] args)
        {
            if (args.Length != 1)
            {
                return null;
            }

            return new Args(args[0]);
        }
    }
}
