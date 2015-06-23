using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MorseCode;

namespace MorseCode
{
    public partial class Form1 : Form
    {
        string stuff;
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Button handler to open flat file containing morse code. 
         * Filters only txt files.
         * */
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"c:\";
            ofd.Filter = "Text Files (*txt)|*.txt";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            this.stuff = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.OpenRead(ofd.FileName);
                using (StreamReader reader = new StreamReader(stream))
                {
                    this.stuff = reader.ReadToEnd();
                }
                stream.Close();
                btnConvert.Enabled = true;
                lblFilePath.Text = ofd.SafeFileName;
            }
        }

        /*
         * Button handler that calls the toEnglish method from the MorseCode class to convert the morse code from the flat file to english text.
         * Uses a method invoker to not block the UI thread in the event of trying to convert a lot of data. 
         * */
        private void btnConvert_Click(object sender, EventArgs e)
        {
            MorseCode mc = new MorseCode();
            MethodInvoker invoker = () => MessageBox.Show(mc.toEnglish(stuff), "Output", MessageBoxButtons.OK, MessageBoxIcon.Information);
            invoker.BeginInvoke(null, null);
        }
    }
}
