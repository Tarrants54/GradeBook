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
    public partial class DisplayForm : Form
    {
        //List for all Students
        List<Student> allStudent = new List<Student>();
        public DisplayForm()
        {
            InitializeComponent();
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {


            try
            {
                using (StreamReader sr = new StreamReader("student.txt"))
                {
                    string id;
                    while ((id = sr.ReadLine()) != null)
                    {
                        string name = sr.ReadLine();
                        int score = int.Parse((sr.ReadLine()));
                        //Create student
                        Student s = new Student(id, name, score);
                        //Add to list
                        allStudent.Add(s);
                        //Add to listBox
                        allStudentListBox.Items.Add(s);
                    }


                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No Students have been entered yet!");
                Close();
            }
        }
        

        private void closeButton(object sender, EventArgs e)
        {
            Close();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Print a header
            e.Graphics.DrawString("Grade Report",
                new Font("Courier New", 24, FontStyle.Bold),
                Brushes.Black, 200, 100);
            //Print Date and time
            e.Graphics.DrawString(DateTime.Now.ToString(),
                new Font("Courier New", 10, FontStyle.Italic),
                Brushes.Black, 240, 150);
            // Print each student in a loop
            int x = 100, y = 200;
            foreach (Student s in allStudent)
            {
                e.Graphics.DrawString(s.ToString(),
                    new Font("Courier New", 10, FontStyle.Regular),
                    Brushes.Black, x, y);
                y += 15;
            }
        }
    }
}
