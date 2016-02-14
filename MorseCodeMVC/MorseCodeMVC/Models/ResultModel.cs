using MorseCodeMVC.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MorseCodeMVC.Models
{
    public class ResultModel
    {
        public string result { get; set; }

        [ValidateFile(ErrorMessage = "Please submit a valid '.txt' file")]
        public HttpPostedFileBase file { get; set; }
    }
}