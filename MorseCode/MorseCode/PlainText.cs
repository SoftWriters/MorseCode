using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MorseCode.MorseCode
{
    public class PlainText
    {
        [Display(Name="Plain Text")]
        public string Plaintext { get; set; }
    }
}
