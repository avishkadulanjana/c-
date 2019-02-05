using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fullSQLstatements
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Roll = rollTextBox.Text;
            student.Science = Convert.ToDecimal(scienceTextBox.Text);
            student.English = Convert.ToDecimal(englishTextBox.Text);
            student.Maths = Convert.ToDecimal(mathsTextBox.Text);

            Gateway gateway = new Gateway();
            gateway.Save(student);

            MessageBox.Show("Saved");
            rollTextBox.Text = "";
            scienceTextBox.Text = "";
            englishTextBox.Text = "";
            mathsTextBox.Text = "";
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            Gateway gateway = new Gateway();

            student= gateway.Get(rollTextBox.Text);

            scienceTextBox.Text = student.Science.ToString();
            englishTextBox.Text = student.English.ToString();
            mathsTextBox.Text = student.Maths.ToString();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Roll = rollTextBox.Text;
            student.Science = Convert.ToDecimal(scienceTextBox.Text);
            student.English = Convert.ToDecimal(englishTextBox.Text);
            student.Maths = Convert.ToDecimal(mathsTextBox.Text);

            Gateway gateway = new Gateway();
            gateway.Update(student);

            MessageBox.Show("Update");
            rollTextBox.Text = "";
            scienceTextBox.Text = "";
            englishTextBox.Text = "";
            mathsTextBox.Text = "";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Roll = rollTextBox.Text;

            Gateway gateway = new Gateway();
            gateway.Delete(student);

            MessageBox.Show("Deleted");
        }
    }
}
