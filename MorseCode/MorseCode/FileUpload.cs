using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MorseCode.MorseCode
{
    public class FileUpload
    {
        [Required]
        [Display(Name = "Select a file:")]
        public IFormFile MorseCodeFile { get; set; }
        [Display(Name = "Translated Text:")]
        public string MorseCode { get; set; }
    }
}
