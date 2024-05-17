﻿namespace Onet;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private async void OnBtnRegisterClicked(object sender, EventArgs e)
    {
        
        await Navigation.PushModalAsync(new Register());
        Navigation.RemovePage(Navigation.ModalStack[0]);
    }

    private async void OnBtnLoginClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password.Text))
            return;

        var user = await App.UserRepository.GetUserAsync(Email.Text);

        if (user == null || user.Password != Password.Text)
        {
            await DisplayAlert("Alert", "Incorrect Email or Password!", "Ok");
            return;
        }

        await SecureStorage.SetAsync("username", user.Name!);
        await SecureStorage.SetAsync("userId", user.Id.ToString());

        await Navigation.PopModalAsync();
    }
}