using Onet.Interfaces;

namespace Onet.Services
{
    public class NavigationService : INavigationService
    {
        public Task PopModalAsync() => Application.Current!.MainPage!.Navigation.PopModalAsync();
    }
}
