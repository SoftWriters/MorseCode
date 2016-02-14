using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MorseCodeMVC.Controllers
{
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }

            if (file.ContentLength > 1 * 1024 * 1024)
            {
                return false;
            }

            try
            {
                var fileExtension = System.IO.Path.GetExtension(file.FileName);
                return (fileExtension == ".txt");
               
            }
            catch { }
            return false;
        }
    }
}