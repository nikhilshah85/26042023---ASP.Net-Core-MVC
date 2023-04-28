namespace shoppingAPP.Models
{
    public class Products
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public double pPrice { get; set; }
        public bool pIsInStock { get; set; }

      static  List<string> productCategories = new List<string>()
        {
            "Electronics","Shoes","Tshirts","Watch","Cold-Drinks","Accessories","Books"
        };

        public List<string> GetProductCategories()
        {
            return productCategories;
        }
        //if not static - this is going into endless loop - product inside product and product product 
       static  private List<Products> pList = new List<Products>()
        {
            new Products() { pId = 1, pName ="Iphone", pCategory="Electronics", pIsInStock=true, pPrice=140000},
            new Products() { pId = 2, pName ="Pepsi", pCategory="Cold-Drink", pIsInStock=true, pPrice=50},
            new Products() { pId = 3, pName ="Appy", pCategory="Cold-Drink", pIsInStock=false, pPrice=90},
            new Products() { pId = 4, pName ="Dell Lattitude", pCategory="Electronics", pIsInStock=true, pPrice=80000},
            new Products() { pId = 5, pName ="Fossil Q", pCategory="Watch", pIsInStock=false, pPrice=35000},
            new Products() { pId = 6, pName ="Apple Watch", pCategory="Watch", pIsInStock=true, pPrice=60000},
            new Products() { pId = 7, pName ="Nike Air", pCategory="Shoes", pIsInStock=true, pPrice=12000},
        };

        public List<Products> GetAllProducts()
        {
            return pList;
        }
    }
}
