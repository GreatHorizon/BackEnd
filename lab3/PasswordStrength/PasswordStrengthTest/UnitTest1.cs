using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrength;

namespace PasswordStrengthTest
{
    [TestClass]
    public class IsCorrectPassword
    {
        [TestMethod]
        public void correct_password_should_return_true()
        {
            string password = "123aasd";
            bool res = Program.IsCorrectPassword(password);
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void special_symbol_in_password_should_retur_false()
        {
            string password = "123aasd@";
            bool res = Program.IsCorrectPassword(password);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void ñyrillic_symbols_in_password_should_retur_false()
        {
            string password = "éôûâ213";
            bool res = Program.IsCorrectPassword(password);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void empty_password_should_retur_false()
        {
            string password = "";
            bool res = Program.IsCorrectPassword(password);
            Assert.AreEqual(false, res);
        }
    }

    [TestClass]
    public class CalculateStrengthByLengthTest
    {
        [TestMethod]
        public void password_aaaaa12345_should_return_strength_equals_to_40()
        {
            string password = "aaaaa12345";
            int requiredStrength = 40;
            int res = Program.CalculateStrengthByLength(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_a_should_return_strength_equals_to_4()
        {
            string password = "a";
            int requiredStrength = 4;
            int res = Program.CalculateStrengthByLength(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_as12x_should_return_strength_equals_to_20()
        {
            string password = "as12x";
            int requiredStrength = 20;
            int res = Program.CalculateStrengthByLength(password);
            Assert.AreEqual(requiredStrength, res);
        }
    }

    [TestClass]
    public class CalculateStrengthByDigitAmountTest
    {
        [TestMethod]
        public void password_sdas2223_should_return_digit_amount_mylipty_by_4()
        {
            string password = "sdas222322";
            int requiredStrength = 24;
            int res = Program.CalculateStrengthByDigitAmount(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_fd3123_should_return_strength_equals_to_8()
        {
            string password = "fd3123";
            int requiredStrength = 16;
            int res = Program.CalculateStrengthByDigitAmount(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_as12x_should_return_strength_equals_to_16()
        {
            string password = "as12x";
            int requiredStrength = 8;
            int res = Program.CalculateStrengthByDigitAmount(password);
            Assert.AreEqual(requiredStrength, res);
        }
    }

    [TestClass]
    public class CalculateStrengthByUpperCaseLettersAmountTest
    {
        [TestMethod]
        public void password_AABBDSX_should_return_strength_equals_to_0()
        {
            string password = "AABBDSX";
            int requiredStrength = 0;
            int res = Program.CalculateStrengthByUpperCaseLettersAmount(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_AAsBBsXaaa_should_return_strength_equals_to_10()
        {
            string password = "AAsBBsXaaa";
            int requiredStrength = 10;
            int res = Program.CalculateStrengthByUpperCaseLettersAmount(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_absc123_should_return_strength_equals_to_0()
        {
            string password = "absc123";
            int requiredStrength = 0;
            int res = Program.CalculateStrengthByUpperCaseLettersAmount(password);
            Assert.AreEqual(requiredStrength, res);
        }
    }

    [TestClass]
    public class CalculateStrengthByLowerCaseLettersAmountTest
    {
        [TestMethod]
        public void password_absc123_should_return_strength_equals_to_6()
        {
            string password = "absc123";
            int requiredStrength = 6;
            int res = Program.CalculateStrengthByLowerCaseLettersAmount(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_AAsBBsXaaa_should_return_strength_equals_to_10()
        {
            string password = "AAsBBsXaaa";
            int requiredStrength = 10;
            int res = Program.CalculateStrengthByLowerCaseLettersAmount(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_aaaaa_should_return_strength_equals_to_0()
        {
            string password = "aaaaa";
            int requiredStrength = 0;
            int res = Program.CalculateStrengthByLowerCaseLettersAmount(password);
            Assert.AreEqual(requiredStrength, res);
        }
    }

    [TestClass]
    public class CalculateStrengthByOnlyLettersTest
    {
        [TestMethod]
        public void password_absc123_should_return_strength_equals_to_0()
        {
            string password = "absc123";
            int requiredStrength = 0;
            int res = Program.CalculateStrengthByOnlyLetters(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_AAsBBsXaaa_should_return_strength_equals_to_minus_10()
        {
            string password = "AAsBBsXaaa";
            int requiredStrength = -10;
            int res = Program.CalculateStrengthByOnlyLetters(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_aaaaa_should_return_strength_equals_to_minus_5()
        {
            string password = "aaaaa";
            int requiredStrength = -5;
            int res = Program.CalculateStrengthByOnlyLetters(password);
            Assert.AreEqual(requiredStrength, res);
        }
    }

    [TestClass]
    public class CalculateStrengthByOnlyDigitsTest
    {
        [TestMethod]
        public void password_absc123_should_return_strength_equals_to_minus_0()
        {
            string password = "absc123";
            int requiredStrength = 0;
            int res = Program.CalculateStrengthByOnlyDigits(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_123456_should_return_strength_equals_to_minus_6()
        {
            string password = "123456";
            int requiredStrength = -6;
            int res = Program.CalculateStrengthByOnlyDigits(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_aaaaa_should_return_strength_equals_to_0()
        {
            string password = "aaaaa";
            int requiredStrength = 0;
            int res = Program.CalculateStrengthByOnlyDigits(password);
            Assert.AreEqual(requiredStrength, res);
        }
    }

    [TestClass]
    public class CalculateStrengthByRepeatingSymbolsTest
    {
        [TestMethod]
        public void password_aaaaa_should_return_strength_equals_to_minus_5()
        {
            string password = "aaaaa";
            int requiredStrength = -5;
            int res = Program.CalculateStrengthByRepeatingSymbols(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_a12aa22bbabssfc_should_return_strength_equals_to_minus_12()
        {
            string password = "a12aa22bbabssfc";
            int requiredStrength = -12;
            int res = Program.CalculateStrengthByRepeatingSymbols(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_123a34a1123_should_return_strength_equals_to_minus_10()
        {
            string password = "123a34a1123";
            int requiredStrength = -10;
            int res = Program.CalculateStrengthByRepeatingSymbols(password);
            Assert.AreEqual(requiredStrength, res);
        }
        
        [TestMethod]
        public void password_12349_should_return_strength_equals_to_0()
        {
            string password = "12349";
            int requiredStrength = 0;
            int res = Program.CalculateStrengthByRepeatingSymbols(password);
            Assert.AreEqual(requiredStrength, res);
        }
    }

    [TestClass]
    public class CalculateStrengthTest
    {
        [TestMethod]
        public void password_12349_should_return_strength_equals_to_42()
        {
            string password = "123456";
            int requiredStrength = 42;
            int res = Program.CalculateStrength(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_qwerty123_should_return_strength_equals_to_54()
        {
            string password = "qwerty123";
            int requiredStrength = 54;
            int res = Program.CalculateStrength(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_A_should_return_strength_equals_to_3()
        {
            string password = "A";
            int requiredStrength = 3;
            int res = Program.CalculateStrength(password);
            Assert.AreEqual(requiredStrength, res);
        }

        [TestMethod]
        public void password_sss_should_return_strength_equals_to_8()
        {
            string password = "ssss";
            int requiredStrength = 8;
            int res = Program.CalculateStrength(password);
            Assert.AreEqual(requiredStrength, res);
        }
    }
}
