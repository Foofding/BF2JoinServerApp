using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace BF2JoinServerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ProfileListView.ItemsSource = Profile.GetProfiles();
        }

        private void HostButton_Click(object sender, RoutedEventArgs e)
        {

            GameConnector gameConnector = new GameConnector();
            gameConnector.HostGame();
            //"+modPath mods/bf2all64"
            gameConnector.LaunchGame("C:\\Program Files (x86)\\EA Games\\Battlefield 2\\BF2.exe", "C:\\Program Files (x86)\\EA Games\\Battlefield 2", "+modPath mods/bf2all64");

        }
    }

   

    public class Profile
    {
        public Profile(string name, int playTime)
        {
            this.Name = name;
            this.PlayTime = playTime;
        }

        public string Name { get; set; }
        public int PlayTime { get; set; }

        public static List<Profile> GetProfiles()
        {

            return new List<Profile>
            {
                new Profile("JoeBiden", 120),
                new Profile("BiggoNiggo", 120),
                new Profile("WonkasFirstChoice", 120),
                new Profile("ButtholeSurfer", 120),
                new Profile("Shed5", 120),
                new Profile("Shed6", 120),
                new Profile("Shed7", 120),
            };
        }
    }
}

