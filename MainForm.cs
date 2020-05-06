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

namespace GradeBook
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Create instance of DataEntryForm
            DataEntryForm entryForm = new DataEntryForm();
            entryForm.ShowDialog();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            //Create instance of DisplayForm
            DisplayForm displayForm = new DisplayForm();
            displayForm.ShowDialog();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //Create instance of SearchForm
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            File.Delete("student.txt");
        }
    }
}
