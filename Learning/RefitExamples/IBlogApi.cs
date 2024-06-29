using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Learning.Models;


namespace Learning.RefitExamples
{
	public interface IBlogApi
	{
		[Get("/api/blog")]
		Task<List<BlogModel>> GetBlogs();

        [Get("/api/blog/{id}")]
        Task<BlogModel> GetBlog(int id);

        [Post("/api/blog")]
        Task<string> CreateBlogs(BlogModel blog);

        [Put("/api/blog/{id}")]
        Task<string> UpdateBlog(int id,BlogModel blog);

        [Delete("/api/blog/{id}")]
        Task<string> DeleteBlogs(int id);
    }
}
