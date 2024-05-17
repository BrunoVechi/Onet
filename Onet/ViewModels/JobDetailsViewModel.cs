using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Onet.Models;

namespace Onet.ViewModels
{
    public partial class JobDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private int userId;

        [ObservableProperty]
        private Job selectedJob;

        public JobDetailsViewModel(Job job)
        {
            SelectedJob = job;
            LoadUserIdAsync();
        }

        [RelayCommand]
        public void LoadUserIdAsync()
        {
            _ = int.TryParse(SecureStorage.GetAsync("userId").Result, out int id);
            UserId = id;
        }

        [RelayCommand]
        public async Task AddJobAsync()
        {
            var newJob = new Job
            {
                UserId = UserId,
                Title = "New Task",
                Description = "Description",
                Status = 0,
                Creation = DateTime.Now
            };

            await App.JobRepository.SaveJobAsync(newJob);
        }

        [RelayCommand]
        public async Task UpdateJobAsync()
        {
            await App.JobRepository.SaveJobAsync(SelectedJob);
        }

        [RelayCommand]
        public async Task DeleteJobAsync()
        {
            await App.JobRepository.DeleteJobAsync(SelectedJob);
        }
    }
}
