using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollbackTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=db_studentinfo;Trusted_Connection=True;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("insert into t_user(userName,user_password) values('tjsanshao222dsfds','123')", con, tran))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("insert into t_user values('sdffdf','sdfa')", con, tran))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        tran.Rollback();
                    }
                }
            }

            Console.ReadKey();

        }
    }
}
