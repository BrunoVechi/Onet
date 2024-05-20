using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Onet.Interfaces;

namespace Onet.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IDialogService _dialogService;
        private readonly IKeyboardService _keyboardService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? password;

        public LoginViewModel()
        {
            _dialogService = DependencyService.Get<IDialogService>();
            _keyboardService = DependencyService.Get<IKeyboardService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        [RelayCommand]
        private async Task RegisterAsync()
        {
            await _keyboardService.HideKeyboardAsync();
            await _navigationService.ReplaceModal(new Register());
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            await _keyboardService.HideKeyboardAsync();

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                return;

            var user = await App.UserRepository.GetUserAsync(Email);

            if (user == null || user.Password != Password)
            {
                await _dialogService.ShowAlertAsync("Alert", "Incorrect Email or Password!", "Ok");
                return;
            }

            await SecureStorage.SetAsync("username", user.Name!);
            await SecureStorage.SetAsync("userId", user.Id.ToString());

            Application.Current!.MainPage = new AppFlyout();
        }
    }
}
