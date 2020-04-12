using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.Models
{
    public class Note
    {
        public string Data { get; set; }
        public Note(string text)
        {
            this.Data = text;
        }
    }
}
