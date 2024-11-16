namespace _1111;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
        this.BackgroundImageSource = "homee.png";
    }
    private void OnRepairClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Repair());
    }
    private void OnParcelClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UserPage());
    }
}