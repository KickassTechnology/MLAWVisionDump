using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;


namespace VisionProjectImport
{
    class Program
    {
        static void Main(string[] args)
        {
            string conn = "Server=mlawdb.cja22lachoyz.us-west-2.rds.amazonaws.com;Database=MLAW_MS;User Id=sa;Password=!sd2the2power!;";
            using (SqlConnection connection2 = new SqlConnection(conn))
            {
                connection2.Open();
                string strQuery = "SELECT Order_Id FROM Orders WHERE Date_Received > '1/1/2017'";
                SqlDataAdapter adapter = new SqlDataAdapter(strQuery, connection2);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string strURL = "http://54.70.45.121/insert_vision_order.aspx?Order_Id=" + dr["Order_Id"].ToString();
                    Console.WriteLine(strURL);
                    WebClient client = new WebClient();
                    string reply = client.DownloadString(strURL);

                    Console.WriteLine(reply);

                }

            }
            
        }
    }
}
