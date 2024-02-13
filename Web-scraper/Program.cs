using webscraper;

DBWorker dBWorker = new DBWorker("DataSource=Database\\NewBD.db");
var p = dBWorker.GetIds();


/*Process proc = new Process();
proc = Process.GetCurrentProcess();
Console.WriteLine($"{proc.PrivateMemorySize64 / (1024 * 1024)}MB");
Console.WriteLine(p.Count);
Console.WriteLine(p.Capacity);

*/
Worker worker = new Worker(p);

/*while (true)
{
    worker.Work();
}*/

worker.Work2();
