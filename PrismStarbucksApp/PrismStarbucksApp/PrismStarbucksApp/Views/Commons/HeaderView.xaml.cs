using System.Windows.Input;

namespace PrismStarbucksApp.Views.Commons;

public partial class HeaderView : ContentView
{
    public HeaderView()
    {
        InitializeComponent();
    }

    #region HambugerCommand

    /// <summary>
    /// HambugerCommand
    /// </summary>
    public ICommand HambugerCommand
    {
        get => (ICommand)GetValue(HambugerCommandProperty);
        set => SetValue(HambugerCommandProperty, value);
    }

    public static readonly BindableProperty HambugerCommandProperty =
        BindableProperty.Create(
            propertyName: nameof(HambugerCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(HeaderView),
            defaultValue: default(ICommand)/*,
            propertyChanged: OnHambugerCommandPropertyChanged*/);

    private static void OnHambugerCommandPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        ((HeaderView)bindable).icHambuger.GestureRecognizers.Add
            (new TapGestureRecognizer()
            {
                Command = (ICommand)newvalue,
                NumberOfTapsRequired = 1
            });

    }

    public static readonly BindableProperty HambugerCommandParameterProperty =
            BindableProperty.Create(nameof(HambugerCommandParameter),
                typeof(object),
                typeof(HeaderView),
                null,
                BindingMode.TwoWay);

    public object HambugerCommandParameter
    {
        get => GetValue(HambugerCommandParameterProperty);
        set => SetValue(HambugerCommandParameterProperty, value);
    }

    #endregion

    private void HambugerTapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }

    private void HambugerTapped(System.Object sender, System.EventArgs e)
    {
        HambugerCommand?.Execute(null);
    }

    #region IconHambuger

    public ImageSource IconHambuger
    {
        get => (ImageSource)GetValue(HambugerCommandProperty);
        set => SetValue(HambugerCommandProperty, value);
    }

    public static readonly BindableProperty IconHambugerProperty =
        BindableProperty.Create(
            propertyName: nameof(IconHambuger),
            returnType: typeof(ImageSource),
            declaringType: typeof(HeaderView),
            defaultValue: default(ImageSource),
            propertyChanged: OnIconHambugerPropertyChanged);

    private static void OnIconHambugerPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        ((HeaderView)bindable).imgHambuger.Source = (ImageSource)newvalue;
    }

    #endregion
}

