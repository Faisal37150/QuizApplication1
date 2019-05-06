using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApplication
{
    public partial class messageform : Form
    {
        public messageform()
        {
            InitializeComponent();
        }

        private void messageform_Load(object sender, EventArgs e)
        {
            label3.Text = test.score.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
