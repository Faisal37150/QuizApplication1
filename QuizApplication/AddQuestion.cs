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
    public partial class AddQuestion : Form
    {
        public AddQuestion()
        {
            InitializeComponent();
        }

        private void AddQuestion_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quizappDataSet.exams' table. You can move, or remove it, as needed.
            //this.examsTableAdapter.Fill(this.quizappDataSet.exams);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = comboBox1.SelectedValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            questions q = new questions();
            q.q_title = textBox1.Text;
            q.q_opa = textBox2.Text;
            q.q_opb = textBox3.Text; 
            q.q_opc = textBox4.Text;
            q.q_opd = textBox5.Text;
            q.q_opcorrect = textBox6.Text;
            q.q_addeddate = System.DateTime.Now.ToShortDateString();
            q.q_fk_ad = AdminLogin.fk_ad;
            q.q_fk_ex = comboBox1.SelectedValue.ToString();

            insertclass ic = new insertclass();
           string msg = ic.insert_srecord(q);
           MessageBox.Show(msg);
            
           

        }

        private void AddQuestion_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
        }

        
    }
}
