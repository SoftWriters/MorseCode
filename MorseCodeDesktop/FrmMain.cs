using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MorseCodeDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private MorseCodeClass.MorseCodeFileConverter MyMorseCode = new MorseCodeClass.MorseCodeFileConverter();

        /// <summary>
        /// Indicates if a converted file has been saved.
        /// </summary>
        private bool ChangesSaved = true;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckExit()) Application.Exit();
        }

        private void openMorseCodeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Could check "ChangesSaved" in case user meant to save file, but didn't.  Easy to re-convert, so won't check here.
            // User can also hit "cancel" on File Dialog.

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;

                try
                {
                    string PlainText = MyMorseCode.MorseCodeFile_ToText(FileName);
                    FileText.Text = PlainText;

                    if (PlainText.Contains("?")) MessageBox.Show("File contains invalid Morse Code sequences!\r\nInvalid sequences shown as \"?\"",Application.ProductName );
                }

                catch (Exception Ex)
                {
                    GenericExceptionHandler(Ex);
                }
            }
        }

        private void openPlainTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Could check "ChangesSaved" in case user meant to save file, but didn't.  Easy to re-convert, so won't check here.
            // User can also hit "cancel" on File Dialog.

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;

                try
                {
                    string MorseCode = MyMorseCode.TextFile_ToMorseCode(FileName);

                    FileText.Text = MorseCode;

                    if (MorseCode.Contains("?"))
                    {
                        MessageBox.Show("File contains characters that can't be converted to Morse Code!\r\nInvalid characters shown as \"?\"", Application.ProductName);
                    }

                }

                catch (Exception Ex)
                {
                    GenericExceptionHandler(Ex);
                }

            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Height > 75) FileText.Height = this.Height - 75;
            if (this.Width > 40) FileText.Width = this.Width - 40;
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveResults(saveFileDialog.FileName);

                    ChangesSaved = true;

                    MessageBox.Show("File Saved!");
                }
                catch (Exception Ex)
                {
                    GenericExceptionHandler(Ex);
                }
            }
        }

        /// <summary>
        /// Save converted file results.  Can be plain text or Morse Code
        /// </summary>
        /// <param name="FileName">Full path to save file as</param>
        private void SaveResults(string FileName)
        {
            using (TextWriter SaveFile = new StreamWriter(FileName))
            {
                SaveFile.Write(FileText.Text);
                SaveFile.Close();
            }
        }

        /// <summary>
        /// Common Exception handler
        /// </summary>
        /// <param name="Ex">Exception Object</param>
        private void GenericExceptionHandler(Exception Ex)
        {
            MessageBox.Show(Ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CheckExit();
        }

        /// <summary>
        /// Checks if converted file (if any) has been saved.  If not, prompt user.  
        /// </summary>
        /// <returns>Returns true if OK to exit.  Either because changes saved or user says its OK</returns>
        private bool CheckExit()
        {
            if (!ChangesSaved)
            {
                if (MessageBox.Show("Converted File has not been saved.  Exit anyway?"
                    , Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ChangesSaved = true; // Don't know if we're being called by Form_Closing or by menu option
                    return true;
                }

                else
                    return false;
            }
            else
                return true;
        }

        private void FileText_TextChanged(object sender, EventArgs e)
        {
            ChangesSaved = false; // Indicate some change in contents in case of exiting.
        }

    }
}