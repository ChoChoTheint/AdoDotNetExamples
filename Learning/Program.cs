
using Learning.AdoDotNetExamples;
using Learning.DapperExamples;
using Learning.EFCoreExamples;
using System.Data.SqlClient;

// AdoDotNetExamples adoDotNetExamples = new AdoDotNetExamples();
//adoDotNetExamples.Read();
//adoDotNetExamples.Edit(1);
//adoDotNetExamples.Create("1",100,"1",1);
//adoDotNetExamples.Update("1", 100, "1");
//adoDotNetExamples.Delete("1");


DapperExamples dapperExamples = new DapperExamples();
//dapperExamples.Edit(2);
//dapperExamples.Create(4,"Testing 4", "Testing 4", "Testing 4");
//dapperExamples.Update(4, "Testing 4 update", "Testing 4 update", "Testing 4 update");
dapperExamples.Read();
//dapperExamples.Delete(2);

//EFCoreExamples eFCoreExamples = new EFCoreExamples();
//eFCoreExamples.Read();
//eFCoreExamples.Edit(3);
//eFCoreExamples.Create(5, "Testing 5", "Testing 5", "Testing 5");
//eFCoreExamples.Update(5, "Testing 5 ", "Testing 5 ", "Testing 5 ");
//eFCoreExamples.Delete(5);

//HttpClientExamples httpClientExamples = new HttpClientExamples();
//await httpClientExamples.Run();
//Console.ReadKey();


//namespace Learning.HttpClientExamples
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            HttpClientExamples examples = new HttpClientExamples();
//            await examples.Run();
//        }
//    }
//}
