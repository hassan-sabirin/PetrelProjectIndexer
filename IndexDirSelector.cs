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
    
        public delegate void startIndexEventHandler( string[] folder_list, string logDir, string GDBpath, bool append);

    public partial class IndexDirSelector : Form
    {
        public startIndexEventHandler startIndexHandler; 
        //public List<string> folder_list;
        public IndexDirSelector( startIndexEventHandler handler)
        {
            startIndexHandler = handler;
            //folder_list = new List<string>();
            InitializeComponent();
        }

        private void AddFolder_Click(object sender, EventArgs e)
        {
            PathEntry PathAdd = new PathEntry();
            DialogResult result = PathAdd.ShowDialog();
            if (result == DialogResult.OK)
            {

                listBox1.Items.Add(PathAdd.path);

            }
        //    addFolderDialog.ShowNewFolderButton = false;
        //    addFolderDialog.SelectedPath = @"\\nodes.iq9k.petronas.com.my\petrel_data";
        //    DialogResult result = addFolderDialog.ShowDialog();
            
        //    if(result == DialogResult.OK)
        //    listBox1.Items.Add(addFolderDialog.SelectedPath);
        }


        private void DelFolder_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove( listBox1.SelectedItem );
            //folder_list.Remove(listBox1.SelectedItem as string);
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = false;
            saveFileDialog1.Filter = "Geodatabase|*.gdb";
            saveFileDialog1.OverwritePrompt = true;
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.EndsWith(".gdb"))
                    textBox1.Text = saveFileDialog1.FileName + ".gdb";
                else
                    textBox1.Text = saveFileDialog1.FileName;
            }
        }


        private void startIndexButton_Click(object sender, EventArgs e)
        {
            //check gdb path
            string root = System.IO.Path.GetPathRoot(textBox1.Text);
            if (!System.IO.Directory.Exists(root))
            {
                throw new Exception("Directory not found: " + root);
            }


            string[] folder_list = listBox1.Items.Cast<string>().ToArray();
            startIndexHandler(folder_list, textBox2.Text, textBox1.Text, checkBoxAppendGDB.Checked);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void editPathButton_Click(object sender, EventArgs e)
        {

            PathEntry PathAdd = new PathEntry(listBox1.SelectedItem as string);
            PathAdd.Text = "Edit Path";
            DialogResult result = PathAdd.ShowDialog();
            if (result == DialogResult.OK)
            {
                listBox1.Items[listBox1.SelectedIndex] = PathAdd.path;

            }
        }

    }
}
