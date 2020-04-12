using MyNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.Data.interfaces
{
    public interface INotesRepository
    {
        IEnumerable<Note> GetAll();
        public void AddNote(string text);

    }
}
