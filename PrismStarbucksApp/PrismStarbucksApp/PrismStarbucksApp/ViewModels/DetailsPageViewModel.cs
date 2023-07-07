
using System;
using PrismStarbucksApp.Models;
using PrismStarbucksApp.ViewModels.Commons;

namespace PrismStarbucksApp.ViewModels
{
    public class DetailsPageViewModel : BaseViewModels
    {
        public DetailsPageViewModel(INavigationService navigationService) : base(navigationService: navigationService)
        {
        }

        #region Props

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        #endregion

        #region Naviagtion

        public override void OnNavigatedNewTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("selectedProd"))
            {
                SelectedProduct = (Product)parameters["selectedProd"];
            }
        }

        public override void OnNavigatedBackTo(INavigationParameters parameters)
        {
            base.OnNavigatedBackTo(parameters);
        }

        #endregion
    }
}

