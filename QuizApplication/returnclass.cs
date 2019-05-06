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
    class returnclass
    {
        private string connstring = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;

        public string scalarRetrun(string q)
        {
             string s;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(q, conn);
               s = cmd.ExecuteScalar().ToString();
            }
            catch(Exception)
            {
                s = " ";
            }
            
            conn.Close();
            return s;

        }

    }
}
