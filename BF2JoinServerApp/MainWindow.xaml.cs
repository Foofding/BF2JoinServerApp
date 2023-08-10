﻿using BF2JoinServerApp.Models;
using BF2JoinServerApp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BF2JoinServerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameService _gameService = new GameService();
        private ProfileService _profileService = new ProfileService();
        private List<string> _launchArgs = new List<string> { " +modPath mods/bf2all64" };
        private Dictionary<string, Profile> _profileFiles;
        private KeyValuePair<string, Profile> _selectedProfile; // ex: [0001, Profile]


        public MainWindow()
        {
            // Assigning variables
            _profileFiles = _profileService.GetFoldersAndProfiles();
            _selectedProfile = _profileFiles.FirstOrDefault();

            InitializeComponent();

            ProfileListView.ItemsSource = _profileService.GetFoldersAndProfiles();
            ProfileListView.HorizontalAlignment = HorizontalAlignment.Left;
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the Rename button click here
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the Copy button click here
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the Delete button click here
        }

        private void HostButton_Click(object sender, RoutedEventArgs e)
        {

            GameConnectorService gameConnector = new GameConnectorService();
            Task.Factory.StartNew(() => { gameConnector.HostGame(); });

            //"+modPath mods/bf2all64"
            gameConnector.LaunchGame(_gameService.GetExecutablePath(), _gameService.GetDirectoryPath(), _launchArgs);
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            GameConnectorService gameConnector = new GameConnectorService();
            bool hostFound = gameConnector.GetHostIP();

            if (!hostFound)
            {
                MessageBox.Show("Could not find host! \n\n 1. Check your firewall settings; Either make an exception for BF2JoinServerApp.exe or turn firewall off entirely. \n\n 2. Make sure no other host has pressed the \"Host\" button. If they did, make them restart the app to close port.");
                //return;
            }

            // Commiting SelectProfile before launching game
            _profileService.SelectProfile(_selectedProfile.Key);

            // Specifiying host's ip in launch args
            _launchArgs.Add("+joinServer " + gameConnector.HostIP);
            gameConnector.LaunchGame(_gameService.GetExecutablePath(), _gameService.GetDirectoryPath(), _launchArgs);

        }

        private void ProfileListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Check if an item was selected
            if (ProfileListView.SelectedItem != null)
            {
                // Update _selectedProfile
                _selectedProfile = (KeyValuePair<string, Profile>)ProfileListView.SelectedItem;
            }
        }
    }
}

