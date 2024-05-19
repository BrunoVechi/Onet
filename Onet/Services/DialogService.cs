using Onet.Interfaces;

namespace Onet.Services
{
    public class DialogService : IDialogService
    {
        public Task<bool> ShowAlertAsync(string title, string message, string buttonText, string cancelButtonText = "")
        {
            if (cancelButtonText != "")
                return Application.Current!.MainPage!.DisplayAlert(title, message, buttonText, cancelButtonText);

            Application.Current!.MainPage!.DisplayAlert(title, message, buttonText);
            return Task.FromResult(true);
        }
    }
}
