using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using _1111.Models;
using _1111.Services;
using PropertyChanged;

namespace _1111.ViewModels;

[AddINotifyPropertyChangedInterface]
public partial class UserViewModel
    {
    FirestoreService _firestoreService;

    public ObservableCollection<UserModel> Users { get; set; } = [];
    public UserModel CurrentUser { get; set; }

    public ICommand All { get; set; }
    public ICommand WaitingCommand { get; set; }
    public ICommand ConfirmCommand { get; set; }

    public UserViewModel(FirestoreService firestoreService)
    {
        this._firestoreService = firestoreService;
        this.Refresh();
        All = new Command(async () =>
        {
            CurrentUser = new UserModel();
            await this.Refresh();
        }
        );
        WaitingCommand = new Command(async () =>
        {
            await this.Refresh();
        });
        ConfirmCommand = new Command(async () =>
        {
            await this.Refresh();
        });

    }

    public async Task GetAll()
    {
        Users = [];
        var items = await _firestoreService.GetAllUser();
        foreach (var item in items)
        {
            Users.Add(item);
        }
    }

    private async Task Refresh()
    {
        CurrentUser = new UserModel();
        await this.GetAll();
    }

}

