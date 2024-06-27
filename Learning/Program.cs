
using Learning.AdoDotNetExamples;
using Learning.DapperExamples;
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
Console.ReadKey();
    