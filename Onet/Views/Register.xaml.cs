using Mobile.Models;

namespace Onet;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
    }

    private async void OnBtnRegisterClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password.Text))
            return;

        var user = new User
        {
            Name = Name.Text,
            Email = Email.Text,
            Password = Password.Text
        };

        if (await App.UserRepository.SaveUserAsync(user))
        {
            var userInDb = await App.UserRepository.GetUserAsync(user.Email);

            await SecureStorage.SetAsync("username", userInDb.Name!);
            await SecureStorage.SetAsync("userId", userInDb.Id.ToString());
            
            await Navigation.PopModalAsync();
        }
        else
            await DisplayAlert("Alert", "Unable to register!", "Ok");
    }

    private async void OnBtnLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Login());
        Navigation.RemovePage(Navigation.ModalStack.First(m => m is Register));
    }
}
