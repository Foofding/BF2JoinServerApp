using BF2JoinServerApp.Data;
using BF2JoinServerApp.Models;
using BF2JoinServerApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace BF2JoinServerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameRepository _gameRepository;
        private ProfileService _profileService;
        private List<string> _launchArgs;
        private Profile _firstProfile;
        private Profile _selectedProfile;
        private List<Profile> _profiles;

        public MainWindow()
        {
            _gameRepository = new GameRepository();
            _profileService = new ProfileService();
            _launchArgs = new List<string> { " +modPath mods/bf2all64" };
            _profiles = _profileService.GetProfiles();



            if (!_gameRepository.CheckInstallation())
            {
                // TODO: ERROR prompt needs to appear if BF2 directory isn't found
            }


            InitializeComponent();
            ProfileListView.ItemsSource = _profiles;
            ProfileListView.HorizontalAlignment = HorizontalAlignment.Left;
            _firstProfile = _profiles.FirstOrDefault();
            ProfileListView.SelectedItem = _firstProfile;

           



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
            Task.Factory.StartNew(() => { gameConnector.HostGame(); });

            //"+modPath mods/bf2all64"
            gameConnector.LaunchGame(_gameRepository.GetExecutablePath(), _gameRepository.GetDirectoryPath(), _launchArgs);
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            GameConnectorService gameConnector = new GameConnectorService();
            bool hostFound = gameConnector.GetHostIP();

            if (!hostFound)              
            {
                MessageBox.Show("Could not find host! \n\n 1. Check your firewall settings; Either make an exception for BF2JoinServerApp.exe or turn firewall off entirely. \n\n 2. Make sure no other host has pressed the \"Host\" button. If they did, make them restart the app to close port.");
                return;
            }

            _launchArgs.Add("+joinServer " + gameConnector.HostIP);
            gameConnector.LaunchGame(_gameRepository.GetExecutablePath(), _gameRepository.GetDirectoryPath(), _launchArgs);

        }

        private void ProfileListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Check if an item was selected
            if (ProfileListView.SelectedItem != null && ProfileListView.SelectedItem != _firstProfile)
            {
                _selectedProfile = (Profile)ProfileListView.SelectedItem;
                _profileService.SelectProfile(_firstProfile.FolderPath, _selectedProfile.FolderPath);
              
            }
        }
    }
}

