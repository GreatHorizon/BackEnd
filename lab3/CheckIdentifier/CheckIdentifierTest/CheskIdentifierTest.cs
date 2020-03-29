using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIdentifier;

namespace CheckIdentifierTest
{
    [TestClass]
    public class CheckInputTest
    {
        [TestMethod]
        public void check_too_few_arguments()
        {
            string[] args = new string[]{};

            bool res = Program.CheckInput(args);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void check_too_many_arguments()
        {
            string[] args = new string[] {"asdsd", "asds"};

            bool res = Program.CheckInput(args);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void correct_argument_count()
        {
            string[] args = new string[] { "asdsd"};

            bool res = Program.CheckInput(args);
            Assert.AreEqual(true, res);
        }
    }

    [TestClass]
    public class IsLetterTest
    {
        [TestMethod]
        public void check_upper_case_symbols()
        {
            bool res = Program.IsLetter('Z');
            Assert.AreEqual(true, res);

            res = Program.IsLetter('A');
            Assert.AreEqual(true, res);

            res = Program.IsLetter('G');
            Assert.AreEqual(true, res);

            res = Program.IsLetter('@');
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void check_lower_case_symbols()
        {
            bool res = Program.IsLetter('z');
            Assert.AreEqual(true, res);

            res = Program.IsLetter('a');
            Assert.AreEqual(true, res);

            res = Program.IsLetter('f');
            Assert.AreEqual(true, res);

        }

        [TestMethod]
        public void check_non_letter_symbols()
        {
            bool res = Program.IsLetter('?');
            Assert.AreEqual(false, res);

            res = Program.IsLetter('/');
            Assert.AreEqual(false, res);

            res = Program.IsLetter('3');
            Assert.AreEqual(false, res);

            res = Program.IsLetter('}');
            Assert.AreEqual(false, res);

            res = Program.IsLetter(' ');
            Assert.AreEqual(false, res);
        }
    }

    [TestClass]
    public class CheckIdentifierTest
    {
        [TestMethod]
        public void first_symbol_is_digit()
        {
            string identifier = "12asd";
            bool res = Program.CheckIdentifier(identifier);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void empty_line()
        {
            string identifier = "";
            bool res = Program.CheckIdentifier(identifier);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void one_incorrect_symbol()
        {
            string identifier = "}";
            bool res = Program.CheckIdentifier(identifier);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void incorrect_symbol_with_letters()
        {
            string identifier = "aa*";
            bool res = Program.CheckIdentifier(identifier);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void correct_identifier_with_letters()
        {
            string identifier = "aaAXZ";
            bool res = Program.CheckIdentifier(identifier);
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void correct_identifier_with_digits()
        {
            string identifier = "a2a9A1XZ";
            bool res = Program.CheckIdentifier(identifier);
            Assert.AreEqual(true, res);
        }
    }
}
