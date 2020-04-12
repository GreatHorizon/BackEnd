using Microsoft.AspNetCore.Mvc;
using MyNotes.Data.interfaces;
using MyNotes.Data.Repositorites;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyNotes.Controllers
{

    public class NotesController : Controller
    {
        private INotesRepository _notesRepository;
        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
            NotesRepository.SetPath("Storage/notes.txt");
        }   

        [Route("/note/add")]
        [HttpPost]
        public async Task<StatusCodeResult> AddNote()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string noteStr = await new StreamReader(Request.Body, Encoding.GetEncoding(1251)).ReadToEndAsync();

            if (string.IsNullOrEmpty(noteStr))
            {
                return BadRequest();
            }

            _notesRepository.AddNote(noteStr);
            return Ok();
        }

        [Route("/note/list")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var allNotesJSON = JsonConvert.SerializeObject(_notesRepository.GetAll(), Formatting.Indented);
            return Content(allNotesJSON);
        }
    }
}