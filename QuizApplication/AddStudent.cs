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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            student s = new student();

            s.std_name = textBox2.Text;
            s.std_password = textBox4.Text;
            s.std_batchcode = textBox3.Text;
            s.std_ad_id = textBox5.Text;

            insertclass ics = new insertclass();
            string msg = ics.insert_student(s.std_name, s.std_password, s.std_batchcode, s.std_ad_id);
            MessageBox.Show(msg);



        }


    }
}
