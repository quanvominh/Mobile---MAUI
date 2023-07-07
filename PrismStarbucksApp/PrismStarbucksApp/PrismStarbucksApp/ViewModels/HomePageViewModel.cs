using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Navigation;
using PrismStarbucksApp.Interfaces;
using PrismStarbucksApp.Models;
using PrismStarbucksApp.Services;
using PrismStarbucksApp.ViewModels.Commons;
using PrismStarbucksApp.Views;
using static System.Net.Mime.MediaTypeNames;

namespace PrismStarbucksApp.ViewModels
{
    public class HomePageViewModel : BaseViewModels
    {
        public HomePageViewModel(ProductService productService, INavigationService navigationService, ISqLiteService sqLiteService) : base(navigationService: navigationService, sqLiteService: sqLiteService)
        {
            if (productService != null) _productService = productService;

            DetailsCommand = new Command<Product>(OnDetailsCommandExecuted);
            ProductFavCommand = new Command<Product>(OnProductFavCommandExecuted);
        }

        #region Props

        private ProductService _productService;
        private string _categorySelectedValue;
        public string CategorySelectedValue
        {
            get => _categorySelectedValue;
            set => SetProperty(ref _categorySelectedValue, value);
        }


        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        #endregion

        public override void Initialize(INavigationParameters parameters)
        {
            CategorySelectedValue = "All";
            // load from local DB - currently we are using ImageSource locally -- show empty
            //var data = SqLiteService.GetList<Product>(prod => prod.ProductId != -1);
            //if (data.Count() == 0)
            //{
            //    var prods = _productService.GetProducts();
            //    var res = SqLiteService.InsertAll(prods);
            //    data = SqLiteService.GetList<Product>(prod => prod.ProductId != -1);
            //}
            Products = new ObservableCollection<Product>(_productService.GetProducts());
        }

        #region DetailCommand

        public ICommand DetailsCommand { get; }

        private async void OnDetailsCommandExecuted(Product selectedProduct)
        {
            var param = new NavigationParameters
            {
                { "selectedProd", selectedProduct },
            };
            await Navigation.NavigateAsync(name: nameof(DetailsPage), parameters: param);
        }

        #endregion

        #region ProductFavCommand

        public ICommand ProductFavCommand { get; }

        private void OnProductFavCommandExecuted(Product selectedProduct)
        {
            selectedProduct.ProductFav();
        }

        #endregion

    }
}

