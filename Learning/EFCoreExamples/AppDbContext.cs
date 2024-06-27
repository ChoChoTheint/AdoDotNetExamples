using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Learning.EFCoreExamples
{
    public class AppDbContext :Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".\\MSSQLSERVER2019",
                InitialCatalog = "Blog",
                UserID = "sa",
                Password = "sasa",
                TrustServerCertificate = true
            };
           optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
        }
        public Microsoft.EntityFrameworkCore.DbSet<BlogModel> Blog { get; set; }
    }
}
