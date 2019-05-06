using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace QuizApplication
{
    public partial class Form1 : Form
    {
        Thread th;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Opennewfrom2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Opennewfrom2(object obj)
        {
            Application.Run(new AdminLogin());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Opennewfrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Opennewfrom(object obj)
        {
           Application.Run(new Studentlogin());
        }
    }
}
