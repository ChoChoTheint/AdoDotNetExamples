using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Learning.EFCoreExamples
{
    public class EFCoreExamples
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> list = db.Blog.ToList();
            foreach (BlogModel item in list)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }
        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blog.FirstOrDefault(item => item.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }

        public void Create(int id,string title,string author,string content) 
        {
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            AppDbContext db = new AppDbContext();
            db.Blog.Add(blog);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving success...." : "Saveing Fail...........";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content) 
        {
            //BlogModel blog = new BlogModel()
            //{
            //    BlogId = id,
            //    BlogTitle = title,
            //    BlogAuthor = author,
            //    BlogContent = content
            //};
            //AppDbContext db = new AppDbContext();
            //db.Blog.Update(blog);
            //int result = db.SaveChanges();
            //string message = result > 0 ? "Updating success...." : "Updating Fail...........";
            //Console.WriteLine(message);

            
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blog.FirstOrDefault(item => item.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating success...." : "Updating Fail...........";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blog.FirstOrDefault(item => item.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            db.Blog.Remove(item);
            int result = db.SaveChanges();  
            string message = result > 0 ? "Deleting success...." : "Deleting Fail...........";
            Console.WriteLine(message);
        }
    }
}
