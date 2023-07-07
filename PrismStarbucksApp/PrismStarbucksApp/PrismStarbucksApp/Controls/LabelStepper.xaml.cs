namespace Session02.Controls;

public partial class LabelStepper : ContentView
{
    private int count;
	public LabelStepper()
	{
		InitializeComponent();
	}

    private void Substract_Clicked(System.Object sender, System.EventArgs e)
    {
        if (count <= 0) return;
        countLabel.Text = Convert.ToString(--count);
    }

    private void Add_Clicked(System.Object sender, System.EventArgs e)
    {
        countLabel.Text = Convert.ToString(++count);
    }
}
