using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNotes.Data.Repositorites;
using MyNotes.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyNotesTest
{
    [TestClass]
    public class AddNoteTest
    {
        NotesRepository notesRepository = new NotesRepository();
        static string notesFilePath = "../../../TestData/notes.txt";

        [TestMethod]
        public void one_note_adding_should_add_one_note_to_file()
        {
            File.WriteAllText(AddNoteTest.notesFilePath, string.Empty);
            string note = "stay there";
            NotesRepository.SetPath(AddNoteTest.notesFilePath);
            notesRepository.AddNote(note);

            StreamReader inputFile = new StreamReader(notesFilePath, false);

            Assert.AreEqual(inputFile.ReadLine(), note);
            inputFile.Close();
        }
    }

    [TestClass]
    public class GetAllTest
    {
        NotesRepository notesRepository = new NotesRepository();
        static string notesFilePath = "../../../TestData/notes.txt";

        [TestMethod]
        public void adding_note_in_russian_should_return_list_of_note_in_russian()
        {
            File.WriteAllText(GetAllTest.notesFilePath, string.Empty);
            notesRepository.AddNote("собаки и кошки");

            string[] requiredList = {"собаки и кошки"};
            string[] originalList = notesRepository.GetAll().Select(note => note.Data).ToArray();
            CollectionAssert.AreEqual(originalList, requiredList);
        }

        [TestMethod]
        public void adding_two_words_should_return_list_of_notes()
        {
            File.WriteAllText(GetAllTest.notesFilePath, string.Empty);
            NotesRepository.SetPath(GetAllTest.notesFilePath);
            notesRepository.AddNote("cats");
            notesRepository.AddNote("dogs");

            string[] requiredList = { "cats", "dogs" };
            string[] originalList = notesRepository.GetAll().Select(note => note.Data).ToArray();
            CollectionAssert.AreEqual(originalList, requiredList);
        }
    }
}
