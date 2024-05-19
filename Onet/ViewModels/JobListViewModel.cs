using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using Onet.Interfaces;
using Onet.Models;
using System.Collections.ObjectModel;

namespace Onet.ViewModels
{
    public partial class JobListViewModel : ObservableObject
    {
        [ObservableProperty]
        private int userId;

        [ObservableProperty]
        private Job? selectedJob;

        [ObservableProperty]
        private ObservableCollection<Job> jobs = [];        

        [RelayCommand]
        public void LoadUserId()
        {
            _ = int.TryParse(SecureStorage.GetAsync("userId").Result, out int id);
            UserId = id;
        }

        [RelayCommand]
        private static async Task NavigateToJobDetailsAsync(Job selectedJob)
        {
            if (selectedJob != null)
                await Application.Current!.MainPage!.Navigation.PushModalAsync(new JobDetails(selectedJob));
        }

        [RelayCommand]
        public async Task OnAppearing()
        {
            LoadUserId();

            var jobsFromRepo = await App.JobRepository.GetJobsAsync(UserId);
            foreach (var job in jobsFromRepo)
                Jobs.Add(job);
        }
    }
}
