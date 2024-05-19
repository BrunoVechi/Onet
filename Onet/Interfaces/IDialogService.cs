namespace Onet.Interfaces
{
    public interface IDialogService
    {
        Task<bool> ShowAlertAsync(string title, string message, string buttonText, string cancelButtonText = "");
    }
}
