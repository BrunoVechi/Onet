using Onet.Interfaces;

namespace Onet.Services
{
    public class DialogService : IDialogService
    {
        public async Task<bool> ShowAlertAsync(string title, string message, string buttonText, string cancelButtonText = "")
        {
            if (cancelButtonText != "")
                return await Application.Current!.MainPage!.DisplayAlert(title, message, buttonText, cancelButtonText);

            await Application.Current!.MainPage!.DisplayAlert(title, message, buttonText);
            return true;
        }
    }
}
