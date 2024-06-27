using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Models;
using Dapper;
using System.Reflection;
using System.Reflection.Metadata;

namespace Learning.DapperExamples
{
    public class DapperExamples
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".\\MSSQLSERVER2019",
            InitialCatalog = "Blog",
            UserID = "sa",
            Password = "sasa"
        };
        public void Read()
        {
            string query = @"select [BlogId]
                                    ,[BlogTitle]
                                    ,[BlogAuthor]
                                    ,[BlogContent]
                                    from [dbo].[Blog]";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> list = db.Query<BlogModel>(query).ToList();

            Console.WriteLine("Read Data.....");
            foreach (BlogModel item in list)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            Console.WriteLine(".......................................................");
        }

        public void Edit(int id)
        {
            string query = @"select [BlogId]
                                    ,[BlogTitle]
                                    ,[BlogAuthor]
                                    ,[BlogContent]
                                    from [dbo].[Blog] where BlogId = @BlogId";
            BlogModel blog = new BlogModel()
            {
                BlogId = id
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, blog).FirstOrDefault();
            if (item == null)
            {
                Console.WriteLine("No data found.....");
                return;
            }
            Console.WriteLine("Edit Data.....");
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine(".......................................................");
        }

        public void Create(int id, string title, string author, string content)
        {
            string query = @"insert into [dbo].[Blog] 
                                     ([BlogId]
                                    ,[BlogTitle]
                                    ,[BlogAuthor]
                                    ,[BlogContent])
                                    values (@BlogId,@BlogTitle,@BlogAuthor,@BlogContent)";
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            Console.WriteLine("Create Data.............");
            string message = result > 0 ? "Saving success...." : "Saveing Fail...........";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            string query = @"update  [dbo].[Blog] 
                                     set [BlogTitle] = @BlogTitle,[BlogAuthor] = @BlogAuthor,[BlogContent] = @BlogContent where BlogId = @BlogId";
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            Console.WriteLine("Update Data.............");
            string message = result > 0 ? "Updating success...." : "Updating Fail...........";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            string query = @"delete from [dbo].[Blog] where BlogId = @BlogId";
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            Console.WriteLine("Delete Data.............");
            string message = result > 0 ? "Delete success...." : "Delete Fail...........";
            Console.WriteLine(message);
        }
    }
}
