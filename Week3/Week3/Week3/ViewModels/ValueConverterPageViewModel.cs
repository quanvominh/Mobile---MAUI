using System;
namespace Week3.ViewModels
{
    public class ValueConverterPageViewModel : BindableBase
    {
        public ValueConverterPageViewModel()
        {
        }

        private float _data = (float)1.5;
        public float Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }
    }
}

