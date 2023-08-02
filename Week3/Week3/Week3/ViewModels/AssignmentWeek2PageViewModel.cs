using System.Collections.ObjectModel;
using System.Windows.Input;
using Week3.Models;

namespace Week3.ViewModels
{
    public class AssignmentWeek2PageViewModel : IPageLifecycleAware, IInitialize
    {
        public AssignmentWeek2PageViewModel()
        {
        }

        public void Initialize(INavigationParameters parameters)
        {
            //Products = new ObservableCollection<Product>
            //{
            //    new Product()
            //    {
            //        ProductId=1010,
            //        ProductType="Coffee",
            //        ProductName="Chocolate Frappuccino",
            //        ProductImgUrl="chocolate_frappuccino.png",
            //        ProductImgBackground=Color.FromHex("#F3F1ED"),
            //        ProductIsFav=true,
            //        ProductPrice=20.00,
            //        ProductBasePrice=20.00,
            //        ProductSizeType="Tall",
            //        ProductDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam at mi vitae augue feugiat scelerisque in a eros."
            //    },
            //    new Product()
            //    {
            //        ProductId=1011,
            //        ProductType="Tea",
            //        ProductName="Tea Frappuccino",
            //        ProductImgUrl="tea_frappuccino.png",
            //        ProductImgBackground= Color.FromArgb("#F5F9E0"),
            //        ProductIsFav=false,
            //        ProductPrice=30.00,
            //        ProductBasePrice=30.00,
            //        ProductSizeType="Tall",
            //        ProductDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam at mi vitae augue feugiat scelerisque in a eros."
            //    }
            //};
        }

        public void OnAppearing()
        {
            
        }

        public void OnDisappearing()
        {
            
        }
    }
}

