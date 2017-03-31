namespace Hed_Extract
{
    partial class HedExtract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HedExtract));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFromFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicpstreamspToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractWadToFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildWadFromFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datapToolStripMenuItem,
            this.musicpstreamspToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // datapToolStripMenuItem
            // 
            this.datapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractToFolderToolStripMenuItem,
            this.createFromFolderToolStripMenuItem});
            this.datapToolStripMenuItem.Name = "datapToolStripMenuItem";
            this.datapToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.datapToolStripMenuItem.Text = "datap";
            // 
            // extractToFolderToolStripMenuItem
            // 
            this.extractToFolderToolStripMenuItem.Name = "extractToFolderToolStripMenuItem";
            this.extractToFolderToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.extractToFolderToolStripMenuItem.Text = "Extract Wad to Folder";
            this.extractToFolderToolStripMenuItem.Click += new System.EventHandler(this.setDataModeAndExtractToolStripMenuItem_Click);
            // 
            // createFromFolderToolStripMenuItem
            // 
            this.createFromFolderToolStripMenuItem.Name = "createFromFolderToolStripMenuItem";
            this.createFromFolderToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.createFromFolderToolStripMenuItem.Text = "Create Wad from Folder";
            this.createFromFolderToolStripMenuItem.Click += new System.EventHandler(this.setDataModeAndBuildToolStripMenuItem_Click);
            // 
            // musicpstreamspToolStripMenuItem
            // 
            this.musicpstreamspToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractWadToFolderToolStripMenuItem,
            this.buildWadFromFolderToolStripMenuItem});
            this.musicpstreamspToolStripMenuItem.Enabled = false;
            this.musicpstreamspToolStripMenuItem.Name = "musicpstreamspToolStripMenuItem";
            this.musicpstreamspToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.musicpstreamspToolStripMenuItem.Text = "musicp/streamsp";
            // 
            // extractWadToFolderToolStripMenuItem
            // 
            this.extractWadToFolderToolStripMenuItem.Enabled = false;
            this.extractWadToFolderToolStripMenuItem.Name = "extractWadToFolderToolStripMenuItem";
            this.extractWadToFolderToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.extractWadToFolderToolStripMenuItem.Text = "Extract Wad to Folder";
            this.extractWadToFolderToolStripMenuItem.Click += new System.EventHandler(this.setMusicStreamModeAndExtractToolStripMenuItem_Click);
            // 
            // buildWadFromFolderToolStripMenuItem
            // 
            this.buildWadFromFolderToolStripMenuItem.Enabled = false;
            this.buildWadFromFolderToolStripMenuItem.Name = "buildWadFromFolderToolStripMenuItem";
            this.buildWadFromFolderToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.buildWadFromFolderToolStripMenuItem.Text = "Create Wad from Folder";
            this.buildWadFromFolderToolStripMenuItem.Click += new System.EventHandler(this.setMusicStreamModeAndBuildToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 36);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 23);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // HedExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 75);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HedExtract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hed Extract ver. 2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractToFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFromFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicpstreamspToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractWadToFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildWadFromFolderToolStripMenuItem;
    }
}

