using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Learning.Models; // Make sure this namespace matches where your BlogModel class is located

namespace Learning.HttpClientExamples
{
    public class HttpClientExamples
    {
        static readonly HttpClient client = new HttpClient();

        public async Task Run()
        {
            await Read();
        }

        private async Task Read()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7026/api/Blog");

            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonStr = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);

                List<BlogModel> list = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr);
                foreach (BlogModel item in list)
                {
                    Console.WriteLine($"ID: {item.BlogId}");
                    Console.WriteLine($"Title: {item.BlogTitle}");
                    Console.WriteLine($"Author: {item.BlogAuthor}");
                    Console.WriteLine($"Content: {item.BlogContent}");
                    Console.WriteLine(new string('-', 20)); // Separator for better readability
                }
            }
            else
            {
                Console.WriteLine("Error: Unable to retrieve data.");
            }
        }
    }
}


//namespace Learning.HttpClientExamples
//{
//    public class HttpClientExamples
//    {
//        public async Task Run()
//        {
//            await Read();
//        }
//        static readonly HttpClient client = new HttpClient();
//        private async Task Read()
//        {
//            //HttpClientExamples clientExamples = new HttpClientExamples();
//            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7026/api/Blog");
//            if (responseMessage.isSuccessStatusCode)
//            {
//                string jsonStr = await responseMessage.Content.ReadAsStringAsync();
//                Console.WriteLine(jsonStr);

//                List<BlogModel> list = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr);
//                foreach (BlogModel item in list)
//                {
//                    Console.WriteLine(item.BlogId);
//                    Console.WriteLine(item.BlogTitle);
//                    Console.WriteLine(item.BlogAuthor);
//                    Console.WriteLine(item.BlogContent);
//                }
//            }
//        }
//    }
//}
