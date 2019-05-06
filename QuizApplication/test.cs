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
    public partial class test : Form
    {
        public static int score = 0;
        int i, qid ,C=0;
        string correctop;

        public test()
        {
            InitializeComponent();
        }
        returnclass rc = new returnclass();
        private void test_Load(object sender, EventArgs e)
        {
            label3.Text = score.ToString();
            i = Convert.ToInt32(rc.scalarRetrun("select min(q_id) from questions where q_fk_ex="+ Studentlogin.exam_id));
            label1.Text = rc.scalarRetrun("select q_title from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
            radioButton1.Text = rc.scalarRetrun("select q_opa from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
            radioButton2.Text = rc.scalarRetrun("select q_opb from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
            radioButton3.Text = rc.scalarRetrun("select q_opc from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
            radioButton4.Text = rc.scalarRetrun("select q_opd from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
            correctop = rc.scalarRetrun("select q_opcorrect from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
        }
        string s, selectvalue;
        private void button1_Click(object sender, EventArgs e)
        {
           C++;
            if(radioButton1.Checked==true)
            {
                selectvalue = radioButton1.Text;
            }
            else if(radioButton2.Checked==true)
            {
                selectvalue = radioButton2.Text;
            }
            else if(radioButton3.Checked==true)
            {
                selectvalue = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                selectvalue = radioButton4.Text;
            }
            else
            {
                MessageBox.Show("please select one optiion");
            }
            if (selectvalue.Equals(correctop)) 
            {
                score++;
                label3.Text = score.ToString();
            }

            s = rc.scalarRetrun("select min(q_id) from questions where q_id>" + i +" and q_fk_ex=" + Studentlogin.exam_id);
           if (s.Equals(""))
           {
               MessageBox.Show("quiz over");
               button1.Enabled = false;
           }
           else
           {


               i = Convert.ToInt32(s);
              
               label1.Text = rc.scalarRetrun("select q_title from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
               radioButton1.Text = rc.scalarRetrun("select q_opa from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
               radioButton2.Text = rc.scalarRetrun("select q_opb from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
               radioButton3.Text = rc.scalarRetrun("select q_opc from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
               radioButton4.Text = rc.scalarRetrun("select q_opd from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
               correctop = rc.scalarRetrun("select q_opcorrect from questions where q_id=" + i + " and q_fk_ex=" + Studentlogin.exam_id);
           }
           radiobtn();
           string lastquestion = rc.scalarRetrun("select max(q_id) from questions where q_fk_ex="+Studentlogin.exam_id );

            if(lastquestion.Equals(i.ToString()))
            {
                float PER=(score/C+0)*100;
                insertclass IC = new insertclass();
                IC.insert_score(score.ToString(),Studentlogin.studentid,Studentlogin.exam_id,PER.ToString());
                this.Enabled = false;
                messageform mf = new messageform();
                mf.Show();
            }
        }
        public void radiobtn()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            
        }
    }
}
