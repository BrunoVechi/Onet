using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mobile.Models;
using Onet.Interfaces;

namespace Onet.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IDialogService _dialogService;
        private readonly IKeyboardService _keyboardService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? password;

        public RegisterViewModel()
        {
            _dialogService = DependencyService.Get<IDialogService>();
            _keyboardService = DependencyService.Get<IKeyboardService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        [RelayCommand]
        private async Task RegisterAsync()
        {
            await _keyboardService.HideKeyboardAsync();

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                return;

            var user = new User
            {
                Name = Name,
                Email = Email,
                Password = Password
            };

            if (await App.UserRepository.SaveUserAsync(user))
            {
                var userInDb = await App.UserRepository.GetUserAsync(user.Email);

                await SecureStorage.SetAsync("username", userInDb.Name!);
                await SecureStorage.SetAsync("userId", userInDb.Id.ToString());

                Application.Current!.MainPage = new AppFlyout();               
            }

            else            
                await _dialogService.ShowAlertAsync("Alert", "Unable to register!", "Ok");
            
        }

        [RelayCommand]
        private async Task NavigateToLoginAsync()
        {
            await _navigationService.ReplaceModal(new Login());
        }
    }
}
