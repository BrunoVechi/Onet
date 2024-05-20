using Onet.Interfaces;

namespace Onet.Services
{
    public class NavigationService : INavigationService
    {
        public Task PopModalAsync() => Application.Current!.MainPage!.Navigation.PopModalAsync();

        public Task PushModalAsync(ContentPage page) => Application.Current!.MainPage!.Navigation.PushModalAsync(page);

        public async Task ReplaceModal(ContentPage page)
        {
            var closeTask = Application.Current!.MainPage!.Navigation.PopModalAsync();
            var openTask = Application.Current!.MainPage!.Navigation.PushModalAsync(page, false);

            await Task.WhenAll(closeTask, openTask);
        }
    }
}
