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
            this.datapToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.extractDataPToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.createDataPToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.musicpstreamspToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.extractMusicpStreamspToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.createMusicpStreamspToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.spidermanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.extractWadToFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.datapToolStripMenuItem1,
            this.musicpstreamspToolStripMenuItem4,
            this.spidermanToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // datapToolStripMenuItem1
            // 
            this.datapToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.datapToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractDataPToolStripMenuItem2,
            this.createDataPToolStripMenuItem3});
            this.datapToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.datapToolStripMenuItem1.Name = "datapToolStripMenuItem1";
            this.datapToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.datapToolStripMenuItem1.Text = "datap";
            // 
            // extractDataPToolStripMenuItem2
            // 
            this.extractDataPToolStripMenuItem2.Name = "extractDataPToolStripMenuItem2";
            this.extractDataPToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
            this.extractDataPToolStripMenuItem2.Text = "Extract Wad to Folder";
            this.extractDataPToolStripMenuItem2.ToolTipText = "Extract THUG2/THP8 Datap Format";
            this.extractDataPToolStripMenuItem2.Click += new System.EventHandler(this.setDataModeAndExtractToolStripMenuItem_Click);
            // 
            // createDataPToolStripMenuItem3
            // 
            this.createDataPToolStripMenuItem3.Name = "createDataPToolStripMenuItem3";
            this.createDataPToolStripMenuItem3.Size = new System.Drawing.Size(200, 22);
            this.createDataPToolStripMenuItem3.Text = "Create Wad from Folder";
            this.createDataPToolStripMenuItem3.ToolTipText = "Create THP8 Datap Format";
            this.createDataPToolStripMenuItem3.Click += new System.EventHandler(this.setDataModeAndBuildToolStripMenuItem_Click);
            // 
            // musicpstreamspToolStripMenuItem4
            // 
            this.musicpstreamspToolStripMenuItem4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.musicpstreamspToolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractMusicpStreamspToolStripMenuItem5,
            this.createMusicpStreamspToolStripMenuItem6});
            this.musicpstreamspToolStripMenuItem4.Name = "musicpstreamspToolStripMenuItem4";
            this.musicpstreamspToolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.musicpstreamspToolStripMenuItem4.Text = "musicp/streamsp";
            // 
            // extractMusicpStreamspToolStripMenuItem5
            // 
            this.extractMusicpStreamspToolStripMenuItem5.Name = "extractMusicpStreamspToolStripMenuItem5";
            this.extractMusicpStreamspToolStripMenuItem5.Size = new System.Drawing.Size(200, 22);
            this.extractMusicpStreamspToolStripMenuItem5.Text = "Extract Wad to Folder";
            this.extractMusicpStreamspToolStripMenuItem5.ToolTipText = "Extract Musicp / Streamsp / THUG2 Datap Format";
            this.extractMusicpStreamspToolStripMenuItem5.Click += new System.EventHandler(this.setMusicStreamModeAndExtractToolStripMenuItem_Click);
            // 
            // createMusicpStreamspToolStripMenuItem6
            // 
            this.createMusicpStreamspToolStripMenuItem6.Enabled = false;
            this.createMusicpStreamspToolStripMenuItem6.Name = "createMusicpStreamspToolStripMenuItem6";
            this.createMusicpStreamspToolStripMenuItem6.Size = new System.Drawing.Size(200, 22);
            this.createMusicpStreamspToolStripMenuItem6.Text = "Create Wad from Folder";
            this.createMusicpStreamspToolStripMenuItem6.ToolTipText = "Create Musicp / Streamsp / THUG2 Datap Format";
            this.createMusicpStreamspToolStripMenuItem6.Click += new System.EventHandler(this.setMusicStreamModeAndBuildToolStripMenuItem_Click);
            // 
            // spidermanToolStripMenuItem
            // 
            this.spidermanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractWadToFolderToolStripMenuItem});
            this.spidermanToolStripMenuItem.Name = "spidermanToolStripMenuItem";
            this.spidermanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spidermanToolStripMenuItem.Text = "Spiderman";
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
            // extractWadToFolderToolStripMenuItem
            // 
            this.extractWadToFolderToolStripMenuItem.Name = "extractWadToFolderToolStripMenuItem";
            this.extractWadToFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.extractWadToFolderToolStripMenuItem.Text = "Extract Wad to Folder";
            this.extractWadToFolderToolStripMenuItem.Click += new System.EventHandler(this.extractSpidermanWadToFolder);
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
            this.Text = "Hed Extract ver. 3";
            this.Load += new System.EventHandler(this.HedExtract_Load);
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
        private System.Windows.Forms.ToolStripMenuItem datapToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem extractDataPToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem createDataPToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem musicpstreamspToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem extractMusicpStreamspToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem createMusicpStreamspToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem spidermanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractWadToFolderToolStripMenuItem;
    }
}

