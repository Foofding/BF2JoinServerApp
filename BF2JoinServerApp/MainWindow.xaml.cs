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
            
            HostList.ItemsSource=LocalHosts.GetLocalHosts();
        }

    }

    public class LocalHosts
    {
        public static List<LocalHost> GetLocalHosts()
        {

            return new List<LocalHost>
            {
                new LocalHost("Shed1", "192.168.1.90", false),
                new LocalHost("Shed2", "192.168.1.91", false),
                new LocalHost("Shed3", "192.168.1.92", false),
                new LocalHost("Shed4", "192.168.1.93", false),
                new LocalHost("TobyLaptop", "192.168.1.94", false),
                new LocalHost("DH37C2P", "192.168.1.95", false),
                new LocalHost("Bunghole", "192.168.1.96", false),
                new LocalHost("Shed5", "192.168.1.97", false)
            };
        }
    }

    public class LocalHost
    {
        public LocalHost(string name, string iPAddress, bool isActive)
        {
            this.Name = name;
            this.IPAddress = iPAddress;
            this.IsActive = isActive;
        }

        public string Name { get; set; }    
        public string IPAddress { get; set; }
        public bool IsActive { get; set; }

    }
}

