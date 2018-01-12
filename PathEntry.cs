using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetrelProjectIndexer
{
    public partial class PathEntry : Form
    {
        public string path;
        public PathEntry()
        {
            InitializeComponent();
        }

        public PathEntry(string path)
        {
            InitializeComponent();
            textBox1.Text = path;

        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {

            addFolderDialog.ShowNewFolderButton = false;
            if (System.IO.Directory.Exists(textBox1.Text))
            {
                addFolderDialog.SelectedPath = textBox1.Text;
            }
            else
            {
                addFolderDialog.SelectedPath = @"\\NFS\petrel_repository";
            }
            DialogResult result = addFolderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                
                
                    textBox1.Text = addFolderDialog.SelectedPath;
                

            }
            //    listBox1.Items.Add(addFolderDialog.SelectedPath);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            path = textBox1.Text;
            if (!System.IO.Directory.Exists(path))
            {
                MessageBox.Show("Directory " + path + "does not exist !");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
