using Onet.ViewModels;

namespace Onet
{
    public partial class JobList : ContentPage
    {
        public JobList()
        {
            InitializeComponent();
            BindingContext = new JobListViewModel();
        }
    }
}
