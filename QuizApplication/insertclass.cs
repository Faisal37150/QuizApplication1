using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuizApplication
{
    class insertclass
    {
        private string connstring = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;

        public string insert_srecord(questions q)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("[insert_questions]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@q_title", SqlDbType.NVarChar).Value = q.q_title;
                cmd.Parameters.Add("@q_opa", SqlDbType.NVarChar, 200).Value = q.q_opa;
                cmd.Parameters.Add("@q_opb", SqlDbType.NVarChar, 200).Value = q.q_opb;
                cmd.Parameters.Add("@q_opc", SqlDbType.NVarChar, 200).Value = q.q_opc;
                cmd.Parameters.Add("@q_opd", SqlDbType.NVarChar, 200).Value = q.q_opd;
                cmd.Parameters.Add("@q_opcorrect", SqlDbType.NVarChar, 200).Value = q.q_opcorrect;
                cmd.Parameters.Add("@q_addeddate", SqlDbType.NVarChar, 200).Value = q.q_addeddate;
                cmd.Parameters.Add("@q_fk_ad", SqlDbType.Int).Value = q.q_fk_ad;
                cmd.Parameters.Add("@q_fk_ex", SqlDbType.Int).Value = q.q_fk_ex;
                
                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "data successfully inserted!";

            }
            catch (Exception)
            {


                msg = "data is not successfully inserted!";

            }


            finally
            {
                conn.Close();
            }



            return msg;




        } //method end......................







        public string insert_setexam(string date,string stid, string exid)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("[Insert_set_Exam]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@set_exam_date", SqlDbType.NVarChar).Value = date;
                cmd.Parameters.Add("@stu_id_fk", SqlDbType.Int).Value = stid;
                cmd.Parameters.Add("@exam_id_fk", SqlDbType.Int).Value = exid;
          

                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "data successfully inserted!";

            }
            catch (Exception)
            {


                msg = "data is not successfully inserted!";

            }


            finally
            {
                conn.Close();
            }



            return msg;




        } //method end......................





        public string insert_score(string score, string stid, string exid, string per)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("[insert_score]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@score", SqlDbType.Int).Value = score;
                cmd.Parameters.Add("@percentage", SqlDbType.Float).Value = per;
                cmd.Parameters.Add("@std_fk_id", SqlDbType.Int).Value = stid;
                cmd.Parameters.Add("@exam_fk_id", SqlDbType.Int).Value = exid;
                

                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "Score successfully inserted!";

            }
            catch (Exception)
            {


                msg = "Score is not successfully inserted!";

            }


            finally
            {
                conn.Close();
            }



            return msg;




        } //method end......................

        public string insert_student (string std_name, string std_password, string std_batchcode, string std_ad_id)
        {
            string msg = " ";

            SqlConnection conn = new SqlConnection(connstring);
            msg = std_name + " " + std_password + " " + std_ad_id + " " + std_batchcode;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.student_record (std_name,std_batchcode,std_password,std_ad_id) VALUES (@std_name, @std_batchcode, @std_password, @std_ad_id)", conn);
                //SqlCommand cmd = new SqlCommand("INSERT INTO dbo.student_record (std_name,std_batchcode,std_password,std_ad_id) VALUES (" +std_name + ", " + std_batchcode +", "+ std_password+ ", " + std_ad_id + ")", conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add ("@std_name" , SqlDbType.NVarChar, 200).Value = std_name;
                cmd.Parameters.Add ("@std_batchcode" , SqlDbType.NVarChar, 200).Value = std_batchcode;
                cmd.Parameters.Add ("@std_password" , SqlDbType.NVarChar, 200).Value = std_password;
                cmd.Parameters.Add ("@std_ad_id" , SqlDbType.Int, 200).Value = std_ad_id;
                conn.Open();
                cmd.ExecuteNonQuery();

                msg += "Student add Sucessfully";
            

            }
            catch(Exception e)
            {
                msg += "Student not Add" + e.Message;

            }
            finally
            {
                conn.Close();

            }
           return msg;

        }
 
    }
}


