using Onet.Models;
using Onet.ViewModels;

namespace Onet;

public partial class JobDetails : ContentPage
{
    public JobDetails(Job selectedJob)
    {
        InitializeComponent();
        BindingContext = new JobDetailsViewModel(selectedJob);
    }
}
