using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Onet.Interfaces;
using Onet.Models;
using System.Collections.ObjectModel;

namespace Onet.ViewModels
{
    public partial class JobListViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private int userId;

        [ObservableProperty]
        private Job? selectedJob;

        [ObservableProperty]
        private ObservableCollection<Job> jobs = [];

        public JobListViewModel()
        {
            _navigationService = DependencyService.Get<INavigationService>();
        }

        [RelayCommand]
        public void LoadUserId()
        {
            _ = int.TryParse(SecureStorage.GetAsync("userId").Result, out int id);
            UserId = id;
        }

        [RelayCommand]
        private async Task NavigateToJobDetailsAsync(Job selectedJob)
        {
            if (selectedJob != null)
                await _navigationService.PushModalAsync(new JobDetails(selectedJob));
        }

        [RelayCommand]
        public async Task OnAppearing()
        {
            LoadUserId();
            Jobs.Clear();

            var jobsFromRepo = await App.JobRepository.GetJobsAsync(UserId);
            foreach (var job in jobsFromRepo)
                Jobs.Add(job);
        }
    }
}
