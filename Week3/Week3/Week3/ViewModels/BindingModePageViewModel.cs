using System;
using Week3.Utils;

namespace Week3.ViewModels
{
    public class BindingModePageViewModel : BindableBase, IPageLifecycleAware
    {
        public BindingModePageViewModel()
        {
        }

        public void OnAppearing()
        {
            var a = 1;
        }

        public void OnDisappearing()
        {
        }



        #region Props

        private float _hue;
        public float Hue
        {
            get => _hue;
            set
            {
                SetProperty(ref _hue, value);
                Color = Color.FromHsla(value, _saturation, _luminosity);
            }
        }

        private float _saturation;
        public float Saturation
        {
            get => _saturation;
            set
            {
                SetProperty(ref _saturation, value);
                Color = Color.FromHsla(_hue, value, _luminosity);
            }
        }

        private float _luminosity;
        public float Luminosity
        {
            get => _luminosity;
            set
            {
                SetProperty(ref _luminosity, value);
                Color = Color.FromHsla(_hue, _saturation, value);
            }
        }

        private Color _color;
        public Color Color
        {
            get => _color;
            set
            {
                SetProperty(ref _color, value);

                _hue = _color.GetHue();
                _saturation = _color.GetSaturation();
                _luminosity = _color.GetLuminosity();

                Name = NamedColor.GetNearestColorName(_color);
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _data = "Default";
        public string Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }


        #endregion
    }
}

