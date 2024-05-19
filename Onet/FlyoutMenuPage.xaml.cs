using Onet.Models;

namespace Onet;

public partial class FlyoutMenuPage : ContentPage
{
    public FlyoutMenuPage()
    {
        InitializeComponent();
    }

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;

        ((FlyoutPage)Parent).IsPresented = false;

        var selectedText = e.CurrentSelection[0] as string;

        if (selectedText == "Create Task") Navigation.PushModalAsync(
            new JobDetails(
                new Job
                {
                    Creation = DateTime.Now,
                    Started = DateTime.Now,
                    Finished = DateTime.Now
                }));

        if (selectedText == "Exit")
        {
            SecureStorage.RemoveAll();

            Navigation.PushModalAsync(new Login());
        }

        collectionView.SelectedItem = null;
    }
}