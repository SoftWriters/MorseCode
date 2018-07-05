using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MorseCodeLib;

/// <summary>
/// Simple ASPX for testing the MorseCodeLib Class Library and the MorseCodeTranslator Class.
/// Asks for test Morse Code file to be uploaded and translated.
/// Morse Code must be line seperated with |||| and letter seperated with ||
/// </summary>
namespace MorseCodeTest
{
    public partial class MorseCodeTranslatorTest : System.Web.UI.Page
    {
        MorseCodeTranslator translator = new MorseCodeTranslator();

        /// <summary>
        /// Event listener for the btnTranslate click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTranslate_Click(object sender, EventArgs e)
        {
            if (fileUploader.HasFile)
                try
                {
                    string path = Server.MapPath("MyTests\\");
                    string fileLocation = path + fileUploader.FileName;

                    fileUploader.SaveAs(fileLocation);                  //Save uploaded files to a location that can be referenced and read

                    lblResult.Text = translator.TranslateInput(fileLocation).ToString();
                    lblResult.Style["color"] = "black";                 //Resetting in case there was an error. Would likely do this in JS
                }
                catch (Exception ex)
                {
                    lblResult.Text = "ERROR: " + ex.Message.ToString();
                    lblResult.Style["color"] = "red";
                }
            else
            {
                lblResult.Text = "You have not specified a file.";
                lblResult.Style["color"] = "red";                       //Indicate an error has occured
            }

        }
    }
}