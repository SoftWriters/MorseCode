using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MorseCode
{
    public class MorseCodeModel
    {
        public MorseCodeModel()
        {

        }

        public List<MorseCodeLetter> MorseCodeAlphabet
        {
            get
            {
                //Load json file into list
                string json = File.ReadAllText("./MorseCode/MorseCodeAlphabet.json");
                List<MorseCodeLetter> alphabet = JsonConvert.DeserializeObject<List<MorseCodeLetter>>(json);
                return (alphabet);
            }
        }

    }

    //Normal I would add another file for another class. 
    public class MorseCodeLetter
    {

        [JsonProperty("Letter")]
        public string Letter { get; set; }
        [JsonProperty("Code")]
        public string Code { get; set; }
    }
}
