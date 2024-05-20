using Onet.ViewModels;

namespace Onet;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel();
    }
}
