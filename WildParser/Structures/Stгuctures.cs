namespace WildParser.Structures
{



    public class Data
    {
        public List<Product> products { get; set; }
    }



    public class Product
    {
        public int id { get; set; }
        public int root { get; set; }
        public int kindId { get; set; }
        public string brand { get; set; }
        public int brandId { get; set; }
        public int siteBrandId { get; set; }

        public int subjectId { get; set; }
        public int subjectParentId { get; set; }
        public string name { get; set; }
        public string supplier { get; set; }
        public int supplierId { get; set; }
        public double supplierRating { get; set; }
        public int supplierFlags { get; set; }
        public int priceU { get; set; }
        public int salePriceU { get; set; }
        public int logisticsCost { get; set; }
        public int sale { get; set; }
        public int returnCost { get; set; }
        public bool diffPrice { get; set; }
        public int saleConditions { get; set; }
        public int pics { get; set; }
        public int rating { get; set; }
        public double reviewRating { get; set; }
        public int feedbacks { get; set; }
        public int volume { get; set; }
        public int viewFlags { get; set; }
        public List<int> promotions { get; set; }
        public List<Size> sizes { get; set; }
        public int time1 { get; set; }
        public int time2 { get; set; }
        public int wh { get; set; }
        public int dtype { get; set; }
    }

    public class Root
    {

        public Data data { get; set; }
    }

    public class Size
    {
        public string name { get; set; }
        public string origName { get; set; }
        public int rank { get; set; }
        public int optionId { get; set; }
        public int returnCost { get; set; }
        public List<Stock> stocks { get; set; }
        public int time1 { get; set; }
        public int time2 { get; set; }
        public int wh { get; set; }
        public int dtype { get; set; }
        public string sign { get; set; }
        public string payload { get; set; }
    }

    public class Stock
    {
        public int wh { get; set; }
        public int dtype { get; set; }
        public int qty { get; set; }
        public int priority { get; set; }
        public int time1 { get; set; }
        public int time2 { get; set; }
    }






}
