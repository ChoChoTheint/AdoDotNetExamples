using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Learning.Models;


namespace Learning.RefitExamples
{
	public class RefitExample
	{
		private readonly string refitApi =  RestService.For<IBlogApi>(https://localhost:7026);
		public async Task Run()
		{
			//await Read();
			await Edit(1);
			await Edit(2);
		}
		private async Task Read()
		{
			var lst = await refitApi.GetBlogs();
            foreach (BlogModel item in lst)
			{
				Console.WriteLine(item.BlogId);
				Console.WriteLine(item.BlogTitle);
				Console.WriteLine(item.BlogAuthor);
				Console.WriteLine(item.BlogContent);
			}
		}
		private async Task Edit(int id)
		{
			try
			{
				var item = await.refitApi.GetBlog(id);
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
			catch (Exception)
			{
                Console.WriteLine(Exception);
            }
		}
		private async Task Create(string title,string author,string content)
		{
			BlogModel blog = new BlogModel()
			{
				BlogTitle = title,
				BlogAuthor = author,
				BlogContent = content
			};
			try
			{
				var item = await refitApi.CreateBlog(id);
			}
			catch (Refit.ApiException ex)
			{
				Console.WriteLine(ex.Content);
			}
			catch (Exception ex)
			{ 
				Console.WirteLine(ex.ToString());
			}
		}
		private async Task Update(int id,string title,string author,string content)
		{
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            try
            {
                string message = await refitApi.UpdateBlog(id, blog);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
			{ 
                Console.WirteLine(ex.ToString());
            }
        }
		private async Task Delete(int id)
		{
			try
			{
				string message = await refitApi.DeleteBlog(id);
				Console.WriteLine(message);
			}
			catch (Refit.ApiException ex)
			{
                Console.WriteLine(ex.Content);
            }
			catch(Exception ex)
			{
                Console.WriteLine(ex.ToString());
            }
		}
	}
}
