using BF2JoinServerApp.Data;
using BF2JoinServerApp.Services;
using System.Windows;

namespace BF2JoinServerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameRepository _gameRepository;
        private ProfileService _profileService;

        public MainWindow()
        {
            _gameRepository = new GameRepository();
            _profileService = new ProfileService();

            if (!_gameRepository.CheckInstallation())
            {

            }

            InitializeComponent();

            ProfileListView.ItemsSource = _profileService.GetTestProfiles();
            ProfileListView.HorizontalAlignment = HorizontalAlignment.Left;
        }

        private void HostButton_Click(object sender, RoutedEventArgs e)
        {
            GameConnectorService gameConnector = new GameConnectorService();
            gameConnector.HostGame();
            //"+modPath mods/bf2all64"
            gameConnector.LaunchGame(_gameRepository.GetExecutablePath(), _gameRepository.GetDirectoryPath(), " +modPath mods/bf2all64 +joinServer 192.168.0.116 +playerName COPYTEST1");
        }
    }
}

