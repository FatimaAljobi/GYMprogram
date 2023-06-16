using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Gmy
{
    class MainClass
    {
        string statement = global::Gmy.Properties.Settings.Default.s;
        public String exeCom(string sql)
        {
            SqlConnection con = new SqlConnection(statement);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.ExecuteNonQuery();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                con.Close();
            }
        }
        public String getData(string query, ref DataSet ds)
        {
            SqlConnection con = new SqlConnection(statement);
            try
            {
                con.Open();
                SqlDataAdapter command = new SqlDataAdapter(query, con);
                command.Fill(ds);
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
