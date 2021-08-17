using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFileApp
{
    public partial class Form1 : Form
    {
       // private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

        public Form1()
        {
            InitializeComponent();

            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //////var path = "D:\\Adv SQL";
            //////var m = Directory.GetFiles("D:\\Adv SQL");
            //////var ms = Directory.GetDirectories("D:\\Adv SQL");
            //////string[] filePaths = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            ///
            //FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            //DialogResult result = folderDlg.ShowDialog();
            //FolderBrowserDialog folderDlgs = new FolderBrowserDialog();
            //folderDlg.ShowNewFolderButton = true;
            //// Show the FolderBrowserDialog.  
            //DialogResult results = folderDlg.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    textBox1.Text = folderDlg.SelectedPath;
            //    Environment.SpecialFolder root = folderDlg.RootFolder;
            //}
            tree tree = new tree();
            var textBox = new { Text = @"D:\\HOUSE M.D" };
            var directory = new DirectoryInfo(textBox.Text);

            var items =tree.SearchDirectory(directory);

            //you can print it to a console
            foreach (var item in items)
                Console.WriteLine(string.Concat(Enumerable.Repeat('\t', item.Deepth)) + item.Name);

            //or a textbox
            treeView1.Text = string.Join("\n", items.Select(i =>
                string.Concat(Enumerable.Repeat('\t', i.Deepth)) + i.Name));

            //or a table
            for (int i = 0; i < items.Count(); i++)
            {
                //with row = i, and column = items[i].Deepth + 1
            }

            treeView1.BeginUpdate();
            //treeView2.Nodes.Clear();
            string yourParentNode;
            yourParentNode = textBox1.Text.Trim();
            treeView1.Nodes.Add(yourParentNode);
            treeView1.EndUpdate();

            if (treeView1.SelectedNode != null)
            {
                string yourChildNode;
                yourChildNode = textBox1.Text.Trim();
                treeView1.SelectedNode.Nodes.Add(yourChildNode);
                treeView1.ExpandAll();
            }

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
    }
}
