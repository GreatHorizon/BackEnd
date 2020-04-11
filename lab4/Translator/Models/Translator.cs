using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.Models
{
    public class Translator
    {
        public static string GetTranslation(string wordForSearch, string dictionaryFileName)
        {
            string line, result = System.String.Empty;
            string[] wordAndTranslation;
            StreamReader dictionaryFile = new StreamReader(dictionaryFileName);
            
            while ((line = dictionaryFile.ReadLine()) != null)
            {
                wordAndTranslation = line.Split(" ");

                if (wordAndTranslation[1] == wordForSearch)
                {
                    result = wordAndTranslation[0];
                    break;
                }

                if (wordAndTranslation[0] == wordForSearch)
                {
                    result = wordAndTranslation[1];
                    break;
                }
            }

            dictionaryFile.Close();
            return result;
        }
    }
}
