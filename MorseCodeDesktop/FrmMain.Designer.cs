namespace MorseCodeDesktop 
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileText = new System.Windows.Forms.TextBox();
            this.MyMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlainTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMorseCodeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileText
            // 
            this.FileText.Location = new System.Drawing.Point(12, 27);
            this.FileText.Multiline = true;
            this.FileText.Name = "FileText";
            this.FileText.Size = new System.Drawing.Size(521, 274);
            this.FileText.TabIndex = 0;
            this.FileText.TextChanged += new System.EventHandler(this.FileText_TextChanged);
            // 
            // MyMenu
            // 
            this.MyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu});
            this.MyMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MyMenu.Location = new System.Drawing.Point(0, 0);
            this.MyMenu.Name = "MyMenu";
            this.MyMenu.Size = new System.Drawing.Size(545, 24);
            this.MyMenu.TabIndex = 1;
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPlainTextToolStripMenuItem,
            this.openMorseCodeFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // openPlainTextToolStripMenuItem
            // 
            this.openPlainTextToolStripMenuItem.Name = "openPlainTextToolStripMenuItem";
            this.openPlainTextToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openPlainTextToolStripMenuItem.Text = "Open &Plain Text File";
            this.openPlainTextToolStripMenuItem.Click += new System.EventHandler(this.openPlainTextToolStripMenuItem_Click);
            // 
            // openMorseCodeFileToolStripMenuItem
            // 
            this.openMorseCodeFileToolStripMenuItem.Name = "openMorseCodeFileToolStripMenuItem";
            this.openMorseCodeFileToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openMorseCodeFileToolStripMenuItem.Text = "Open &Morse Code File";
            this.openMorseCodeFileToolStripMenuItem.Click += new System.EventHandler(this.openMorseCodeFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveFileToolStripMenuItem.Text = "&Save File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            this.openFileDialog.FilterIndex = 0;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            this.saveFileDialog.Title = "Save File";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 313);
            this.Controls.Add(this.FileText);
            this.Controls.Add(this.MyMenu);
            this.MainMenuStrip = this.MyMenu;
            this.Name = "MainForm";
            this.Text = "Morse Code Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.MyMenu.ResumeLayout(false);
            this.MyMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileText;
        private System.Windows.Forms.MenuStrip MyMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem openPlainTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem openMorseCodeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

