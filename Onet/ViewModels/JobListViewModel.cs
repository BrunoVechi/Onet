using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Onet.Models;
using System.Collections.ObjectModel;

namespace Onet.ViewModels
{
    public partial class JobListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Job> jobs;

        [ObservableProperty]
        private Job? selectedJob;

        public JobListViewModel()
        {
            Jobs = [];
            LoadJobs();
        }

        private async void LoadJobs()
        {
            var jobsFromRepo = await App.JobRepository.GetJobsAsync(1);
            foreach (var job in jobsFromRepo)
                Jobs.Add(job);
        }

        [RelayCommand]
        private static async Task NavigateToJobDetailsAsync(Job selectedJob)
        {
            if (selectedJob != null)
                await Application.Current!.MainPage!.Navigation.PushModalAsync(new JobDetails(selectedJob));
        }
    }
}
