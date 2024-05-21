using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Onet.Enums;
using Onet.Interfaces;
using Onet.Models;
using System.Collections.ObjectModel;

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

        [ObservableProperty]
        private string selectedStatus;

       [ObservableProperty]
        private ObservableCollection<string> enumOptions;

        public JobDetailsViewModel(Job job)
        {
            LoadUserId();
            SelectedJob = job;
            SelectedStatus = SelectedJob.Status.ToString();

            _dialogService = DependencyService.Get<IDialogService>();
            _keyboardService = DependencyService.Get<IKeyboardService>();
            _navigationService = DependencyService.Get<INavigationService>();
            EnumOptions = new ObservableCollection<string>(Enum.GetNames(typeof(EJobStatus)));
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
            SelectedJob.Status = Enum.Parse<EJobStatus>(SelectedStatus);

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
            SelectedJob.Status = Enum.Parse<EJobStatus>(SelectedStatus);

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
