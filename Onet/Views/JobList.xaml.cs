using Onet.ViewModels;

namespace Onet
{
    public partial class JobList : ContentPage
    {
        private readonly JobListViewModel _viewModel;

        public JobList()
        {
            InitializeComponent();
            BindingContext = new JobListViewModel();
            _viewModel = (BindingContext as JobListViewModel)!;
        }

        protected override async void OnAppearing()
        {
            _ = Collection.SelectedItem == null;

            if (_viewModel != null)
                await _viewModel.OnAppearing();

            base.OnAppearing();
        }
    }
}
