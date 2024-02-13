using Newtonsoft.Json;
using System.Diagnostics;

namespace webscraper
{
    internal class Worker
    {
        Stopwatch stopwatch;
        readonly HttpClient client;
        List<parse_Product> products;


        public Worker(List<parse_Product> products)
        {
            Console.WriteLine("Работа началась");
            stopwatch = new Stopwatch();

            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            client.DefaultRequestHeaders.Add("Accept-Charset", "ISO-8859-1");

            this.products = products;





        }


        public void Work()
        {
            int kik = 5000;
            long tempT = 0;
            string s = "https://card.wb.ru/cards/v1/detail?appType=1&curr=rub&dest=-1257786&spp=29&nm=";
            int count = 0;
            stopwatch.Start();
            Root g = new Root();
            int newCost;

            foreach (var product in this.products)
            {
                count++;

                var responce = client.GetStringAsync(s + product.id).Result;


                g = JsonConvert.DeserializeObject<Root>(responce);

                if (count % kik == 0)
                {


                    if (tempT == 0) { tempT += stopwatch.ElapsedMilliseconds / 1000; }
                    else
                    {
                        tempT += stopwatch.ElapsedMilliseconds / 1000;
                        tempT /= 2;
                    }

                    var a = (products.Count - count) / kik * tempT;
                    TimeSpan lasttime = TimeSpan.FromSeconds(a);

                    //System.Console.WriteLine($"{count / 1000}k\t--\t{stopwatch.ElapsedMilliseconds / 1000}s \t--\t{proc.PrivateMemorySize64 / (1024 * 1024)}MB осталось {lasttime.Days} d {lasttime.Hours} h");






                    Console.WriteLine($"{count / 1000}k\tspeed: {kik / (stopwatch.ElapsedMilliseconds / 1000)} per sec\tremained {products.Count - count} {lasttime.Hours}h {lasttime.Minutes}m");

                    stopwatch.Reset(); //сбросили счётчик
                    stopwatch.Start();
                }

                if (g.data.products.Count() != 0)
                {
                    newCost = g.data.products[0].salePriceU / 100;
                    int difference = (newCost - product.salePriceU) / product.salePriceU * 100;

                    if (difference < -5)
                    {
                        Console.WriteLine(difference);
                        Console.WriteLine($"{product.name} {product.salePriceU}->{newCost} \t");

                        using (StreamWriter writer = new StreamWriter($"{DateTime.Now.ToString("dd.MM.yyyy hh.mm.ss.txt")}"))
                        {
                            writer.Write($"{product.name} {product.salePriceU}->{newCost} \t\n");
                        }

                    }

                }
            }
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds / 1000}s");
            stopwatch.Reset();

        }


        public void Work2()
        {
            HttpClient client2 = new HttpClient();

            client2.DefaultRequestHeaders.Add("Host", "megamarket.ru");
            client2.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:121.0) Gecko/20100101 Firefox/121.0");
            client2.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
            client2.DefaultRequestHeaders.Add("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
            client2.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client2.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client2.DefaultRequestHeaders.Add("Cookie", "spid=1706023850806_ad81590739fbba2ccf53269c52554c7b_0bd6i75ncano2gag; spsc=1706035874691_68c0d73c7f48488300f0d70500ce052d_2dc4c47e5beb4aae25be080fa9d16c8093e7e989cef732b63b8bada59af3d7da; _ym_uid=1706023851310079516; _ym_d=1706023851; _ym_isad=1; device_id=d568cb5d-ba20-11ee-bab7-fa163e5517fc; sbermegamarket_token=9db30ab1-0b20-4524-b48a-da4b807f014d; ecom_token=9db30ab1-0b20-4524-b48a-da4b807f014d; isOldUser=true; adspire_uid=AS.1400689790.1706023852; __tld__=null; ssaid=64724530-ba04-11ee-b0b2-814081056f2…XSJswtV4tTEKz6PW8Q57fyxMBZog6REtv25KQ+jLCvdVjxs3MLlPL/U3CJBAjdxz/NZwmKhTtMR+BEypK00VkvokQR9Ewg7gGoLsxaacQ0QrFRt9Fs7xtb0=; cfidsw-smm=u3swjRdTlI/21HyIMAC4calstlbg5c1vSTNkXpKx/okNgyS3XSJswtV4tTEKz6PW8Q57fyxMBZog6REtv25KQ+jLCvdVjxs3MLlPL/U3CJBAjdxz/NZwmKhTtMR+BEypK00VkvokQR9Ewg7gGoLsxaacQ0QrFRt9Fs7xtb0=; _gid=GA1.2.1164238284.1706023854; tmr_lvid=3d6c316a8f33dcf4e1984d96b11b2364; tmr_lvidTS=1706023854536; flocktory-uuid=a141d87c-77e3-47d4-bc9e-17527951665e-7; tmr_detect=1%7C1706036293583; _ym_visorc=b; _gat=1");
            client2.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client2.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            client2.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            client2.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
            client2.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
            client2.DefaultRequestHeaders.Add("TE", "trailers");

            //            client2.DefaultRequestHeaders.Add("Accept-Charset", "ISO-8859-1");



            var responce = client.GetStringAsync("https://megamarket.ru/").Result;

            using (StreamWriter writer = new StreamWriter("123.html"))
            {
                writer.Write(responce);
            }

        }


    }
}
