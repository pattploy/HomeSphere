using _1111.ServicesR;
using _1111.ViewModelsR;

namespace _1111;

public partial class UserRPage : ContentPage
{
	public UserRPage()
	{
		InitializeComponent();
        var firestoreServiceR = new FirestoreServiceR();
        BindingContext = new UserViewModelR(firestoreServiceR);
    }

    
}