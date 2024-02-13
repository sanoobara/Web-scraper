// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

namespace webscraper;
public class Data
{
    public List<Product> products { get; set; }
}


public class Product
{
    public int id { get; set; }

    public int salePriceU { get; set; }

}

public class Root
{

    public Data data { get; set; }
}






