using SQLite;

namespace PrismStarbucksApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string ProductImgUrl { get; set; }
        [Ignore]
        public Color ProductImgBackground { get; set; }
        public double ProductBasePrice { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public bool ProductIsFav { get; set; }

        public void ProductFav()
        {
            ProductIsFav = !ProductIsFav;
        }

        public string ProductSizeType
        {
            //get
            //{
            //    return ProductSizeType;
            //}
            set
            {
                if (value.Equals("Grande"))
                    ProductPrice = ProductBasePrice + 20.00;
                else if (value.Equals("Venti"))
                    ProductPrice = ProductBasePrice + 50.00;
                else
                    ProductPrice = ProductBasePrice;
            }
        }
    }

    public class ProductSize
    {
        public string ProductSizeImgUrl { get; set; }

        public string ProductSizeName { get; set; }
    }
}
