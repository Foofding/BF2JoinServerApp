using BF2JoinServerApp.Data;
using BF2JoinServerApp.Models;
using BF2JoinServerApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;


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

            ProfileListView.ItemsSource = _profileFiles;
            ProfileListView.HorizontalAlignment = HorizontalAlignment.Left;
            ProfileListView.PreviewMouseRightButtonDown += ListView_PreviewMouseRightButtonDown;
        }
        private void ListView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

            if (item != null)
            {

                _selectedProfile = (KeyValuePair<string, Profile>)item.Content;

                item.IsSelected = true;                
                // Create a new context menu for this item
                ContextMenu itemContextMenu = new ContextMenu();

                // Add menu items for this item
                MenuItem renameMenuItem = new MenuItem();
                renameMenuItem.Header = "Rename";
                renameMenuItem.Click += (s, args) => { /* Handle edit action */ };
                itemContextMenu.Items.Add(renameMenuItem);

                MenuItem CopyMenuItem = new MenuItem();
                CopyMenuItem.Header = "Copy";
                CopyMenuItem.Click +=  (s, args) =>
                {
                   _profileService.CopyProfile(_selectedProfile.Key);
                   _profileFiles = _profileService.GetFoldersAndProfiles();                   
                   ProfileListView.Items.Refresh();
                };

                itemContextMenu.Items.Add(CopyMenuItem);

                MenuItem deleteMenuItem = new MenuItem();
                deleteMenuItem.Header = "Delete";
                deleteMenuItem.Click += (s, args) =>
                    {
                        _profileService.DeleteProfile(_selectedProfile.Key);
                        ProfileListView.Items.Refresh();
                    };

                itemContextMenu.Items.Add(deleteMenuItem);

                // Set the context menu for this item
                item.ContextMenu = itemContextMenu;

                // Open the context menu
                itemContextMenu.IsOpen = true;
            }

        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T ancestor)
                {
                    return ancestor;
                }
                current = VisualTreeHelper.GetParent(current);
            } while (current != null);
            return null;
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

