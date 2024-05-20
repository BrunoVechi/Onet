using Onet.ViewModels;

namespace Onet;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}
