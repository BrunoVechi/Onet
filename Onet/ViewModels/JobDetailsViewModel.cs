using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Onet.Interfaces;
using Onet.Models;

namespace Onet.ViewModels
{
    public partial class JobDetailsViewModel : ObservableObject
    {
        private readonly IDialogService _dialogService;
        private readonly IKeyboardService _keyboardService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private int userId;

        [ObservableProperty]
        private Job selectedJob;

        public JobDetailsViewModel(Job job)
        {
            LoadUserId();
            SelectedJob = job;

            _dialogService = DependencyService.Get<IDialogService>();
            _keyboardService = DependencyService.Get<IKeyboardService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        [RelayCommand]
        public void LoadUserId()
        {
            _ = int.TryParse(SecureStorage.GetAsync("userId").Result, out int id);
            UserId = id;
        }

        [RelayCommand]
        public async Task AddJobAsync()
        {
            SelectedJob.UserId = UserId;
            await _keyboardService.HideKeyboardAsync();

            if (await App.JobRepository.SaveJobAsync(SelectedJob))
            {
                await _dialogService.ShowAlertAsync("Alert", "Created task with success", "Ok");
                await _navigationService.PopModalAsync();
            }
            else
                await _dialogService.ShowAlertAsync("Alert", "Unable to create task", "Ok");
        }

        [RelayCommand]
        public async Task UpdateJobAsync()
        {
            SelectedJob.UserId = UserId;
            await _keyboardService.HideKeyboardAsync();

            if (await App.JobRepository.SaveJobAsync(SelectedJob))
            {
                await _dialogService.ShowAlertAsync("Alert", "Updated task with success", "Ok");
                await _navigationService.PopModalAsync();
            }
            else
                await _dialogService.ShowAlertAsync("Alert", "Unable to update task", "Ok");
        }

        [RelayCommand]
        public async Task DeleteJobAsync()
        {
            await _keyboardService.HideKeyboardAsync();

            if (await _dialogService.ShowAlertAsync("Alert", "Do you really want to delete this task?", "Yes", "No"))
            {
                SelectedJob.UserId = UserId;

                if (await App.JobRepository.DeleteJobAsync(SelectedJob))
                {
                    await _dialogService.ShowAlertAsync("Alert", "Deleted task with success", "Ok");
                    await _navigationService.PopModalAsync();
                }
                else
                    await _dialogService.ShowAlertAsync("Alert", "Unable to delete task", "Ok");
            }
        }
    }
}
