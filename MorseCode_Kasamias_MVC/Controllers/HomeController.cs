using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MorseCode_Kasamias.Models;
using System.Web;
using System.Collections.Specialized;
using System.Web.WebPages;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace MorseCode_Kasamias.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            MorseCodeModel model = new MorseCodeModel();
          
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormFile file)
        {
            MorseCodeModel model = new MorseCodeModel();
            List<string> text = new List<string>();


            if (file.Length > 0 && file != null)
            {
                
                text = model.ReadFileAndSave(file);
                model.ConvertedText = text;
            }


            

             // tempdata -- redirect back to index


             return RedirectToAction("Translation", model); 
        }




        public IActionResult Translation(MorseCodeModel model)
        {


            return View(model);
        }

        
         public IActionResult About()
        {
            return View();
        }

  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
