using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TranslatorTest
{
    [TestClass]
    public class GetTranslation_test
    {
        const string  path = "../../../../Translator/dictionary.txt";
        [TestMethod]
        public void if_word_is_not_in_dictionary_should_return_empty_string()
        {
            string result = Translator.Models.Translator.GetTranslation("star", path);
            Assert.AreEqual(result, System.String.Empty);
        }

        [TestMethod]
        public void if_word_is_in_dictionary_should_return_translation()
        {
            string result = Translator.Models.Translator.GetTranslation("dog", path);
            Assert.AreEqual(result, "собака");
        }

        [TestMethod]
        public void if_russian_word_should_return_english_translation()
        {
            string result = Translator.Models.Translator.GetTranslation("кот", path);
            Assert.AreEqual(result, "cat");
        }

        [TestMethod]
        public void if_english_word_should_return_russian_translation()
        {
            string result = Translator.Models.Translator.GetTranslation("cat", path);
            Assert.AreEqual("кот", result);
        }
    }
}
