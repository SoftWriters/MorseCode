using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MorseCode.MorseCode;
using System.IO;

namespace MorseCode.Controllers
{
    public class MorseCodeController : Controller
    {
        private readonly AppSettings _appSettings;

        public MorseCodeController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        // GET: MorseCode
        public ActionResult Index()
        {
            return View();
        }

        // GET: MorseCode/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //Get Alphabet
        public ActionResult ViewAlphabet()
        {
            //Get Configuration
            var alphabet = new MorseCodeModel().MorseCodeAlphabet;
            return View(alphabet);
        }

        public ActionResult CreateJSonFile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View(new FileUpload());
        }

        [HttpPost]
        public IActionResult UploadFile(FileUpload model)
        {
            var file = model.MorseCodeFile;

            //Move the file to a string
            StreamReader reader = new StreamReader(file.OpenReadStream());

            MorseCodeFile fileParser = new MorseCodeFile();
            model.MorseCode = fileParser.ConvertToPlainText(reader);

            return View(model);
        }

        // GET: MorseCode/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateFile(IFormCollection forms)
        {
            MorseCode.MorseCodeFile fileCreator = new MorseCode.MorseCodeFile();
            fileCreator.Save(forms["Plaintext"]);
            
            return RedirectToAction("CreateJSonFile");
        }

        // POST: MorseCode/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MorseCode/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MorseCode/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MorseCode/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MorseCode/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}