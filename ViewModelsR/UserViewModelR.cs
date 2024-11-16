using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using _1111.ModelsR;
using _1111.ServicesR;
using PropertyChanged;


namespace _1111.ViewModelsR;

[AddINotifyPropertyChangedInterface]
public partial class UserViewModelR
{
    FirestoreServiceR _firestoreServiceR;

    public ObservableCollection<UserModelR> UserRs { get; set; } = [];
    public UserModelR CurrentUserR { get; set; }

    public ICommand Save { get; set; }

    public UserViewModelR(FirestoreServiceR firestoreServiceR)
    {
        this._firestoreServiceR = firestoreServiceR;
        this.Refresh();
        Save = new Command(async () =>
        {
            await this.Saves();
            await this.Refresh();
        });
    }
    public async Task GetAll()
    {
        UserRs = [];
        var items = await _firestoreServiceR.GetAllUserR();
        foreach (var item in items)
        {
            UserRs.Add(item);
        }
    }

    public async Task Saves()
    {
        if (string.IsNullOrEmpty(CurrentUserR.RoomNo))
        {
            await _firestoreServiceR.InsertUserR(this.CurrentUserR);
        }
        else
        {
            await _firestoreServiceR.UpdateUserR(this.CurrentUserR);
        }
    }

    private async Task Refresh()
    {
        CurrentUserR = new UserModelR();
        await this.GetAll();
    }

}
