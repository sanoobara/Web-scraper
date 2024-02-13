using System.Diagnostics;
using WildParser;

Requst requst = new Requst(1000000, 1002000);

Stopwatch sw = Stopwatch.StartNew();

sw.Start();
                        


var l = requst.SendRequestToWB().Result;

sw.Stop();
Console.WriteLine($"{sw.ElapsedMilliseconds}");
Console.WriteLine(l.Count);


foreach (var item in l)
{
    Newtonsoft.Json.JsonValidatingReader jsonValidatingReader = new Newtonsoft.Json.JsonValidatingReader()
}




