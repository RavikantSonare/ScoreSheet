using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
       
       
        static void Main(string[] args)
        {
            nets ns = new nets();
         
            string connetionString = null;
            SqlConnection connection;
            SqlCommand sqlCmd;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string sql = null;

            connetionString = "Data Source=MWM49\\SQLEXPRESS2014;Initial Catalog=MySqlDataBase;User ID=ravikant;Password=ravikant";
            // sql = "SELECT * FROM [MySqlDataBase].[dbo].[runners]";

            connection = new SqlConnection(connetionString);
            sql = "update runners set [name] = 10201 where [id] =1";
            connection.Open();
            using (SqlCommand thisCommand =
    new SqlCommand("SELECT COUNT(*) FROM runners", connection))
            {
                Console.WriteLine("Number of Employees is: {0}",
                   thisCommand.ExecuteNonQuery());
                var test = thisCommand.ExecuteNonQuery();
            }

            connection.Close(); 
            try
            {

                adapter.UpdateCommand = connection.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;
                connection.Open();
                var id = adapter.UpdateCommand.ExecuteNonQuery();
                Console.WriteLine(id);

            }
            //try
            //{
            //    sqlCnn.Open();
            //    sqlCmd = new SqlCommand(sql, sqlCnn);
            //    adapter.UpdateCommand = sqlCmd;
            //    adapter.Fill(ds);
            //    sqlCnn.Close();
            //    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //    {
            //       Console.WriteLine(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);
            //    }
            //    adapter.Dispose();
            //    sqlCmd.Dispose();
            //    sqlCnn.Close();
            //}
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! " + ex.Message);
            }
            Console.Read();
        }





    }

    class nets : ica
    {
        string ica.add()
        {
            throw new NotImplementedException();
        }
    }

    interface ica
    {
        string add();
    }
   
}
