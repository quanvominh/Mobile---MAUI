using System;
using System.Collections.ObjectModel;
using PrismStarbucksApp.Models;

namespace PrismStarbucksApp.Services
{
    public class ProductService
    {
        public ObservableCollection<Product> GetProducts()
        {
            return new ObservableCollection<Product>
            {
                new Product()
                {
                    ProductId=1010,
                    ProductType="Coffee",
                    ProductName="Chocolate Frappuccino",
                    ProductImgUrl="chocolate_frappuccino.png",
                    ProductImgBackground=Color.FromHex("#F3F1ED"),
                    ProductIsFav=true,
                    ProductPrice=20.00,
                    ProductBasePrice=20.00,
                    ProductSizeType="Tall",
                    ProductDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam at mi vitae augue feugiat scelerisque in a eros."
                },
                new Product()
                {
                    ProductId=1011,
                    ProductType="Tea",
                    ProductName="Tea Frappuccino",
                    ProductImgUrl="tea_frappuccino.png",
                    ProductImgBackground= Color.FromHex("#F5F9E0"),
                    ProductIsFav=false,
                    ProductPrice=30.00,
                    ProductBasePrice=30.00,
                    ProductSizeType="Tall",
                    ProductDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam at mi vitae augue feugiat scelerisque in a eros."
                }
            };
        }
    }
}

