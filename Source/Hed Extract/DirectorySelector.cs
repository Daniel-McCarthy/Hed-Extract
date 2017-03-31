using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hed_Extract
{
    public partial class DirectorySelector : Form
    {
        public string returnDirectory { get; set; }

        public DirectorySelector()
        {
            InitializeComponent();
        }

        public void addDirectory(string directory)
        {
            directoryListBox.Items.Add(directory);
        }

        public void addDirectories(string[] directories)
        {
            foreach(string directory in directories)
            {
                directoryListBox.Items.Add(directory);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            returnDirectory = directoryListBox.SelectedItem.ToString();
            this.Close();
        }
    }
}
