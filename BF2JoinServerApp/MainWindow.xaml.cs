using System;
using System.Windows;

namespace BF2JoinServerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;


        public MainWindow()
        {
            _game = new Game();

            if (!_game.Exists)
            {

            }

            InitializeComponent();

            ProfileListView.ItemsSource = _game.GetTestProfiles();
            ProfileListView.HorizontalAlignment = HorizontalAlignment.Left;
        }

        private void HostButton_Click(object sender, RoutedEventArgs e)
        {
            GameConnectorService gameConnector = new GameConnectorService();
            gameConnector.HostGame();
           
            gameConnector.LaunchGame(_game.ExecutablePath, _game.DirectoryPath, " +modPath mods/bf2all64 +joinServer 192.168.0.116 +playerName COPYTEST1");

        }

        private void JoinButton_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GameConnectorService gameConnector = new GameConnectorService();
           
            gameConnector.HostIP = gameConnector.JoinGame();

            gameConnector.LaunchGame(_game.ExecutablePath, _game.DirectoryPath, $" +modPath mods/bf2all64 +joinServer {gameConnector.HostIP} +playerName COPYTEST1");
        }
    }
}

