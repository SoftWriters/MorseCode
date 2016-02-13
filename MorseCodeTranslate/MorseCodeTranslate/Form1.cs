using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorseCodeTranslate
{
    /// <summary>
    /// Main translation logic.
    /// </summary>
    public partial class Form1 : Form
    {
        string fileName = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            txtFileLocation.Text = string.Empty;
        }

        /// <summary>
        /// Main translation.
        /// </summary>
        /// <param name="sender">Object invoked event.</param>
        /// <param name="e">Additional details.</param>
        private void btnTranslate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFileLocation.Text == string.Empty)
                {
                    MessageBox.Show("A File is Required");
                    return;
                }

                var sb = new StringBuilder();

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

                ////Builds the string (txtFileLocation)
                sb.Append(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, txtFileLocation.Text.ToString())));

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
                    else if (entry == string.Empty)
                    {
                        sb.Append("\n\n");
                    }
                    else
                    {
                        throw new Exception("Please enter a valid Code/File\n\nUse '||' between each letter/number and '||||' between each word\n\n");
                    }
                }

                ////Displays the results in the form window
                lblResult.Text = sb.ToString();

                ////Console Output
                Console.WriteLine();
                Console.WriteLine(sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            fileName = string.Empty;
        }

        /// <summary>
        /// Opens dialogue for text file input.
        /// </summary>
        /// <param name="sender">Object invoked event.</param>
        /// <param name="e">Additional details.</param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                txtFileLocation.Text = fileName;
            }
        }

        /// <summary>
        /// Closes translator.
        /// </summary>
        /// <param name="sender">Object invoked event.</param>
        /// <param name="e">Additional details.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
