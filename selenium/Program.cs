using OpenQA.Selenium.Firefox;

class Program
{
    static void Main(string[] args)
    {
        // instantiate a driver instance to control
        // Chrome in headless mode
        var options = new FirefoxOptions();

        options.AddArgument("--disable-gpu");

        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");

        options.AddArguments("--headless"); // comment out for testing
        var driver = new FirefoxDriver(options); ;

        // open the target page in Chrome
        driver.Navigate().GoToUrl("https://market.yandex.ru/product--nakidka-zashchitnaia-pod-detskoe-avtokreslo-comfort-address-s-vysokoi-spinkoi/545460166?sku=100762751885&do-waremd5=Xm6kphifu0JaDZ9psfT4cg&uniqueId=756204");
        //driver.Navigate().GoToUrl("https://market.yandex.ru/");
        //driver.Navigate().GoToUrl("https://www.dns-shop.ru/");
        // extract the source HTML of the page
        // and print it
        var html = driver.PageSource;
        driver.Quit();
        using (StreamWriter sw = new StreamWriter("res.html"))
        {
            sw.Write(html);
        }
        //Console.WriteLine(html);

        // close the browser and release its resources

    }
}