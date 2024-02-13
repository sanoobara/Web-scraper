namespace WildParser
{
    internal class Requst
    {
        string Http = "https://card.wb.ru/cards/v1/detail?appType=1&curr=rub&dest=-1257786&spp=29&nm=";

        HttpClient httpClient;
        List<string> urls;
        public Requst(int startIndex, int stopInsex)
        {

            this.urls = new List<string>();
            this.httpClient = new HttpClient();

            this.httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:121.0) Gecko/20100101 Firefox/121.0");
            this.httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
            this.httpClient.DefaultRequestHeaders.Add("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
            this.httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            this.httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");

            
            string Http = "https://card.wb.ru/cards/v1/detail?appType=1&curr=rub&dest=-1257786&spp=29&nm=";
            for (int i = startIndex; i < stopInsex; i++)
            {
                this.urls.Add(Http + i.ToString());
            }

        }

        #region
        //public async Task<string> SendRequestToWB(string url)
        //{

        //    return this.httpClient.GetStringAsync($"{Http}{url}").Result;

        //}
        #endregion

        public async Task<List<string>> SendRequestToWB()
        {
            
            List<string> strings1 = new List<string>();
           
            //Start requests for all of them
            var requests = this.urls.Select
                (
                    url => this.httpClient.GetAsync(url)
                ).ToList();

            //Wait for all the requests to finish
            await Task.WhenAll(requests);

            //Get the responses
            var responses = requests.Select
                (
                    task => task.Result
                );

            foreach (var r in responses)
            {
                // Extract the message body
                var s = await r.Content.ReadAsStringAsync();
                strings1.Add(s);
            }
            return strings1;


        }



    }
}
