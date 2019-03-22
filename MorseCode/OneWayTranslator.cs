using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode
{
    interface IOneWayTranslator
    {
        IList<string> TranslateFile(string file);

        string TranslateLine(string line);
    }
}
