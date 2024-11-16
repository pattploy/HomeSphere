namespace _1111;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        this.BackgroundImageSource = "loginn.png";
    }
    private void OnLoginClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Home());
    }
}
