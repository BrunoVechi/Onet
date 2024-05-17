using Onet.Repository;

namespace Onet
{
    public partial class App : Application
    {
        private static UserRepository? _userRepository;
        private static JobRepository? _jobRepository;

        public static UserRepository UserRepository
        {
            get
            {
                _userRepository ??= new UserRepository();
                return _userRepository;
            }
        }
        public static JobRepository JobRepository
        {
            get
            {
                _jobRepository ??= new JobRepository();
                return _jobRepository;
            }
        }

        public App()
        {
            InitializeComponent();
            Current!.UserAppTheme = AppTheme.Light;
            MainPage = new AppFlyout();
        }
    }
}
