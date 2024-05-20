namespace Onet.Interfaces
{
    public interface INavigationService
    {
        Task PopModalAsync();
        Task PushModalAsync(ContentPage page);
        Task ReplaceModal(ContentPage page);
    }
}
