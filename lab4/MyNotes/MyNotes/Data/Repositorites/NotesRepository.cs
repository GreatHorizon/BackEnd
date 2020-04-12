using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNotes.Data.interfaces;
using MyNotes.Models;
using System.IO;

namespace MyNotes.Data.Repositorites
{
    public class NotesRepository : INotesRepository
    {
        private static string notesFileName;
        public static void SetPath(string path)
        {
            notesFileName = path;
        }

        public IEnumerable<Note> GetAll()
        {
            string line;
            List<Note> notesList = new List<Note>();
            using (StreamReader notesFile = new StreamReader(notesFileName))
            {           
                while ((line = notesFile.ReadLine()) != null)
                {
                    Note note = new Note(line);
                    notesList.Add(note);
                }
            };

            return notesList;
        }

        public void AddNote(string text)
        {
            using (StreamWriter notesFile = new StreamWriter(notesFileName, true))
            {
                notesFile.WriteLine(text);
            };
        }
    }
}

