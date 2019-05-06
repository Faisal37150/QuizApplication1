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
using System.Threading;
namespace QuizApplication
{
    public partial class Studentlogin : Form
    {
       

        public static string exam_id,studentid;
        public Studentlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string user = textBox1.Text;
            string password = textBox2.Text;
            string userdb, passworddb;
            
            returnclass rc = new returnclass();
            userdb = rc.scalarRetrun("select count(std_id) from student_record where std_id="+textBox1.Text);


            if (userdb.Equals("0"))
            {
                MessageBox.Show("Invalid user name!");
            }
            else
            {
                passworddb = rc.scalarRetrun("select std_password from student_record where std_id="+ textBox1.Text);

                if (passworddb.Equals(password))
                {

                    string val = rc.scalarRetrun("select count(std_id) from student_record where std_id=(select stu_id_fk from set_exam where stu_id_fk="+textBox1.Text+" and exam_id_fk="+comboBox1.SelectedValue.ToString()+")");

                    if (val.Equals("0"))
                    {
                        MessageBox.Show("No Such Exam Set!");
                    }
                    else
                    {
                        studentid = textBox1.Text;
                        exam_id = comboBox1.SelectedValue.ToString();
                        test t = new test();
                        t.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Password!");
                }


            }

          


        }

     

        private void Studentlogin_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dadpter2 = new SqlDataAdapter(" select * from exams", "Data Source=DESKTOP-J88O62V\\FAISALAMIN;Initial Catalog=quizapp;Integrated Security=True");
            DataSet dset2 = new DataSet();
            dadpter2.Fill(dset2);
            comboBox1.DataSource = dset2.Tables[0];
            comboBox1.DisplayMember = "exam_name";
            comboBox1.ValueMember = "ex_id";
        }

        
    }
}
