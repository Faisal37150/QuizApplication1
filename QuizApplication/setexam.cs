using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuizApplication
{
    public partial class setexam : Form
    {
        public setexam()
        {
            InitializeComponent();
        }

        private void setexam_Load(object sender, EventArgs e)
        {
            string q = "select * from student_record"; 
            viewclass vc = new viewclass(q);
            
            dataGridView1.DataSource = vc.showrecord();
            SqlDataAdapter dadpter = new SqlDataAdapter(" select distinct std_batchcode from student_record", "Data Source=DESKTOP-J88O62V\\FAISALAMIN;Initial Catalog=quizapp;Integrated Security=True");
            DataSet dset = new DataSet();
            dadpter.Fill(dset);
            comboBox1.DataSource = dset.Tables[0];
            comboBox1.DisplayMember = "std_batchcode";
            comboBox1.ValueMember = "std_batchcode";




            SqlDataAdapter dadpter2 = new SqlDataAdapter(" select * from exams", "Data Source=DESKTOP-J88O62V\\FAISALAMIN;Initial Catalog=quizapp;Integrated Security=True");
            DataSet dset2 = new DataSet();
            dadpter2.Fill(dset2);
            comboBox2.DataSource = dset2.Tables[0];
            comboBox2.DisplayMember = "exam_name";
            comboBox2.ValueMember = "ex_id";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "select * from student_record where std_id not in (select stu_id_fk from set_exam) and std_batchcode='"+comboBox1.SelectedValue.ToString()+"'";
            viewclass vc = new viewclass(q);

            dataGridView1.DataSource = vc.showrecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertclass ic = new insertclass();
            ic.insert_setexam(System.DateTime.Now.ToShortDateString(), textBox1.Text, comboBox2.SelectedValue.ToString());
            string q = "select * from set_exam";
            viewclass vc = new viewclass(q);

            dataGridView2.DataSource = vc.showrecord();
            q = "select * from student_record where std_id not in (select stu_id_fk from set_exam) and std_batchcode='" + comboBox1.SelectedValue.ToString() + "'";
            viewclass vc2 = new viewclass(q);

            dataGridView1.DataSource = vc2.showrecord();
        
        }
    }
}
