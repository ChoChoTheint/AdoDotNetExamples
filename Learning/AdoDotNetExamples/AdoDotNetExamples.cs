using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.AdoDotNetExamples
{
    public class AdoDotNetExamples
    {
        public void Read()
        {
            Console.WriteLine("Hello, World!");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".\\MSSQLSERVER2019";
            sqlConnectionStringBuilder.InitialCatalog = "SMS";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";
            string connectionString = sqlConnectionStringBuilder.ToString();
            Console.WriteLine("connnection => " + connectionString);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   
                    connection.Open();
                    string query = @"select [Id]
                                    ,[Name]
                                    ,[Email]
                                    ,[Address]
                                    from [dbo].[Teacher]";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    connection.Close();
                    foreach (DataRow dr in dt.Rows)
                    { 
                        Console.WriteLine("Id is " + dr["Id"]);
                        Console.WriteLine("Name is " + dr["Name"]);
                        Console.WriteLine( "Email is "+ dr["Email"]);
                        Console.WriteLine("Address is " + dr["Address"]);
                        Console.WriteLine("------------------- " );

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.ReadKey();

        }
   
        public void Edit(int id)
        {
            Console.WriteLine("Hello, World!");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".\\MSSQLSERVER2019";
            sqlConnectionStringBuilder.InitialCatalog = "SMS";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";
            string connectionString = sqlConnectionStringBuilder.ToString();
            Console.WriteLine("connnection => " + connectionString);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   
                    connection.Open();
                    string query = @"select [Id]
                                    ,[Name]
                                    ,[Email]
                                    ,[Address]
                                    from [dbo].[Teacher] where Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id",id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    connection.Close();

                    if (dt.Rows.Count == 0)
                    {
                        Console.WriteLine("No data Found");
                        return;
                    }

                    DataRow dr = dt.Rows[0];
                    Console.WriteLine("Id is " + dr["Id"]);
                    Console.WriteLine("Name is " + dr["Name"]);
                    Console.WriteLine("Email is " + dr["Email"]);
                    Console.WriteLine("Address is " + dr["Address"]);
                    Console.WriteLine("------------------- ");


                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.ReadKey();

        }
        
        public void Create(string id,int mark, string stuId,int isInAactive)
        {
                Console.WriteLine("Hello, World!");

                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                sqlConnectionStringBuilder.DataSource = ".\\MSSQLSERVER2019";
                sqlConnectionStringBuilder.InitialCatalog = "SMS";
                sqlConnectionStringBuilder.UserID = "sa";
                sqlConnectionStringBuilder.Password = "sasa";
                string connectionString = sqlConnectionStringBuilder.ToString();
                Console.WriteLine("connnection => " + connectionString);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        connection.Open();
                        string query = @"insert into [dbo].[ExamResult]
                                     ([Id]
                                    ,[Mark]
                                    ,[StudentId]
                                    ,[IsInActive])
                                     values (@Id,@Mark,@StudentId,@IsInActive)";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Mark", mark);
                        cmd.Parameters.AddWithValue("@StudentId", stuId);
                        cmd.Parameters.AddWithValue("@IsInActive", isInAactive);
                        int result = cmd.ExecuteNonQuery();
                        connection.Close();

                        string message = result == 0 ? "Saving Failed........" : "Saving successful.................";
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Exception: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }

                Console.ReadKey();

            }

        public void Update(string id, int mark, string stuId)
        {
            Console.WriteLine("Update Date");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".\\MSSQLSERVER2019";
            sqlConnectionStringBuilder.InitialCatalog = "SMS";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";
            string connectionString = sqlConnectionStringBuilder.ToString();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"update  [dbo].[ExamResult]
                                    set [Mark] = @Mark,
                                        [StudentId] = @StudentId
                                    where Id = @Id   
                                    ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Mark", mark);
                    cmd.Parameters.AddWithValue("@StudentId", stuId);
                  //  cmd.Parameters.AddWithValue("@IsInActive", isInAactive);
                    int result = cmd.ExecuteNonQuery();
                    connection.Close();

                    string message = result == 0 ? "Saving Failed........" : "Saving successful.................";
                    Console.WriteLine(message);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.ReadKey();

        }

        public void Delete(string id)
        {
            Console.WriteLine("Delete Data");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".\\MSSQLSERVER2019";
            sqlConnectionStringBuilder.InitialCatalog = "SMS";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";
            string connectionString = sqlConnectionStringBuilder.ToString();
            Console.WriteLine("connnection => " + connectionString);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @" delete from [dbo].[Teacher] where Id = @Id";  
                                
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", id);
                    int result = cmd.ExecuteNonQuery();
                    connection.Close();

                    string message = result == 0 ? "Deleting Failed........" : "Deleting successful.................";
                    Console.WriteLine(message);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.ReadKey();

        }
    }
}
