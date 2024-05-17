namespace Onet;

public partial class AppFlyout : FlyoutPage
{
    public AppFlyout()
    {
        if (SecureStorage.GetAsync("userId").Result == null)
            Navigation.PushModalAsync(new Login());

        InitializeComponent();

        IsPresentedChanged += FlyoutMenuPageIsPresentedChanged!;
    }

    private void FlyoutMenuPageIsPresentedChanged(object sender, EventArgs e)
    {
        if (IsPresented)
        {
            OnAppearing();
        }
        else
        {
            OnDisappearing();
            IsGestureEnabled = true;
            IsGestureEnabled = false;
        }
    }
}
