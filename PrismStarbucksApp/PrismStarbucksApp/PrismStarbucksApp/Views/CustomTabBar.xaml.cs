namespace PrismStarbucksApp.Views;

public partial class CustomTabBar : ContentPage
{
    public CustomTabBar()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty SelectedTabIndexProperty = BindableProperty.Create(nameof(SelectedTabIndex), typeof(int), typeof(CustomTabBar), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as CustomTabBar;
        if (newV != null && !(newV is int)) return;
        var oldSelectedIndex = (int)old;
        var newSelectedIndex = (int)newV;
        me?.SelectedTabIndexChanged(oldSelectedIndex, newSelectedIndex);
    });
    private void SelectedTabIndexChanged(int oldTabSelectedIndex, int newTabSelectedIndex) { }
    public int SelectedTabIndex
    {
        get => (int)GetValue(SelectedTabIndexProperty);
        set => SetValue(SelectedTabIndexProperty, value);
    }
    public static readonly BindableProperty ViewContentProperty = BindableProperty.Create(nameof(ViewContent), typeof(View), typeof(CustomTabBar), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as CustomTabBar;
        if (newV != null && !(newV is View)) return;
        var oldViewContent = (View)old;
        var newViewContent = (View)newV;
        me?.ViewContentChanged(oldViewContent, newViewContent);
    });
    private void ViewContentChanged(View oldViewContent, View newViewContent) { }
    public View ViewContent
    {
        get => (View)GetValue(ViewContentProperty);
        set => SetValue(ViewContentProperty, value);
    }
}

