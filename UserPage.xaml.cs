using _1111.Services;
using _1111.ViewModels;

namespace _1111;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
        this.BackgroundImageSource = "pupu.png";
        var firestoreService = new FirestoreService();
        BindingContext = new UserViewModel(firestoreService);
    }
}