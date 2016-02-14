using MorseCodeMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MorseCodeMVC.Controllers
{
    public class TranslatorController : Controller
    {
        // GET: Translator
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ResultModel resultModel)
        {
            resultModel.result = string.Empty;
            if (ModelState.IsValid)
            {
                var file = resultModel.file;
                Dictionary<string, char> morseCode = new Dictionary<string, char>()
                {
                    ////Letters
                    {".-", 'a'},
                    {"-...", 'b'},
                    {"-.-.", 'c'},
                    {"-..", 'd'},
                    {".", 'e'},
                    {"..-.", 'f'},
                    {"--.", 'g'},
                    {"....", 'h'},
                    {"..", 'i'},
                    {".---", 'j'},
                    {"-.-", 'k'},
                    {".-..", 'l'},
                    {"--", 'm'},
                    {"-.", 'n'},
                    {"---", 'o'},
                    {".--.", 'p'},
                    {"--.-", 'q'},
                    {".-.", 'r'},
                    {"...", 's'},
                    {"-", 't'},
                    {"..-", 'u'},
                    {"...-", 'v'},
                    {".--", 'w'},
                    {"-..-", 'x'},
                    {"-.--", 'y'},
                    {"--..", 'z'},
                    {" ", ' '},

                    ////Numbers
                    {"-----", '0'},
                    {".----", '1'},
                    {"..----", '2'},
                    {"...--", '3'},
                    {"....-", '4'},
                    {".....", '5'},
                    {"-....", '6'},
                    {"--...", '7'},
                    {"---..", '8'},
                    {"----.", '9'},
                };

                string result = new StreamReader(file.InputStream).ReadToEnd();

                var sb = new StringBuilder();
                sb.Append(result);

                ////Removes breaks and blank lines

                string str = sb.Replace("||||", "|| ||")
                               .Replace("\r\n", "||")
                               .ToString();

                char morseResult;

                ////Splits the string into an array based on the pipe breaks.
                string[] entryArray = Regex.Split(str, @"\|\|");
                sb.Clear();

                ////Rebuilds the string into deliverable format.
                foreach (var entry in entryArray)
                {
                    if (morseCode.TryGetValue(entry, out morseResult))
                    {
                        sb.Append(morseResult);
                    }
                    else
                    {
                        sb.Append("\n");
                    }
                }

                string finalResult = sb.ToString();
                resultModel.result = finalResult;
                return View(resultModel);
            }
            else
            {
                return View();
            }
        }
    }
}