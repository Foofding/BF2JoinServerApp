using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace BF2JoinServerApp
{
    /// <summary>
    /// Interaction logic for RenameProfileWindow.xaml
    /// </summary>
    public partial class RenameProfileWindow : Window
    {
        private string _currentProfileName { get; set; }

        public string NewProfileName { get; set; }

        public RenameProfileWindow(string currentProfileName = "")
        {
            this._currentProfileName = currentProfileName;
            InitializeComponent();
            ProfileNameTextBox.Text = _currentProfileName;
            NewProfileName = _currentProfileName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.Write("CANCEL CLICKED!");
            Close();
        }


    }
}
