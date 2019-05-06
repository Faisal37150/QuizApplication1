using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace QuizApplication
{
    public partial class Form2 : Form
    {
        Thread the;
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            the = new Thread(openquesform);
            the.SetApartmentState(ApartmentState.STA);
            the.Start();


        }

        private void openquesform(object obj)
        {
            Application.Run(new AddQuestion());
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            the = new Thread(opensetexam);
            the.SetApartmentState(ApartmentState.STA);
            the.Start();

        }

        private void opensetexam(object obj)
        {
            Application.Run(new setexam());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            the = new Thread(opnestdform);
            the.SetApartmentState(ApartmentState.STA);
            the.Start();


        }

        private void opnestdform(object obj)
        {
            Application.Run(new AddStudent());
        }
    }
}
