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
                // TODO: ERROR prompt needs to appear if BF2 directory isn't found
            }

            InitializeComponent();

            ProfileListView.ItemsSource = _profileService.GetProfiles();
            ProfileListView.HorizontalAlignment = HorizontalAlignment.Left;

            // TODO: Runetime error because Directory.CreateDirectory makes new profile folder read-only
            //_profileService.CopyProfile("0006");

            //_profileService.DeleteProfile("0007");

            //_profileService.CreateProfile("NEW Created PLAYER Test!");

            //_profileService.RenameProfile("0008", "Changed name!");

            //InitializeComponent();
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

