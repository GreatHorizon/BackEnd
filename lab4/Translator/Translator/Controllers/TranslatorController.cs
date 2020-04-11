using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Translator.Controllers
{
    public class TranslatorController : Controller
    {
        const string dictionaryFileName = "dictionary.txt";
        public ActionResult ProcessInput(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return BadRequest();
            }

            ViewBag.translation = Translator.Models.Translator.GetTranslation(word, dictionaryFileName);
            ViewBag.word = word;

            if (string.IsNullOrEmpty(ViewBag.translation))
            {
                return NotFound();
            }

            return View();
        }
    }
}