using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraBlanks;

namespace RemoveExtraBlanksTest
{
    [TestClass]
    public class CheckInputTest
    {
        [TestMethod]
        public void check_too_few_arguments()
        {
            string[] args = new string[] { "input.txt" };

            bool res = Program.CheckArguments(args);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void check_too_many_arguments()
        {
            string[] args = new string[] { "output", "txt", "input.txt" };

            bool res = Program.CheckArguments(args);
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void correct_argument_count()
        {
            string[] args = new string[] { "input.txt", "output.txt" };

            bool res = Program.CheckArguments(args);
            Assert.AreEqual(true, res);
        }
    }

    [TestClass]
    public class RemoveExtraBlanksTest
    {
        [TestMethod]
        public void remove_tabs_at_the_border()
        {
            string line = "\tstring\t";
            line = Program.RemoveExtraBlanks(line);
            string required = "string";
            Assert.AreEqual(required, line);  
        }

        [TestMethod]
        public void remove_spaces_at_the_border()
        {
            string line = "  string   ";
            line = Program.RemoveExtraBlanks(line);
            string required = "string";
            Assert.AreEqual(required, line);
        }

        [TestMethod]
        public void remove_tabs_between_words()
        {
            string line = "string\t\t\tstring";
            line = Program.RemoveExtraBlanks(line);
            string required = "string\tstring";
            Assert.AreEqual(required, line);
        }

        [TestMethod]
        public void remove_spaces_between_words()
        {
            string line = "string      string";
            line = Program.RemoveExtraBlanks(line);
            string required = "string string";
            Assert.AreEqual(required, line);
        }

        [TestMethod]
        public void remove_spaces_and_tabs()
        {
            string line = "  string\t     string\t\t string  ";
            line = Program.RemoveExtraBlanks(line);
            string required = "string string string";
            Assert.AreEqual(required, line);
        }

    }
}

