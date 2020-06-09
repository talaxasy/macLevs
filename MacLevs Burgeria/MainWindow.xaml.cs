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
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using System.Threading;
using MacLevs_Burgeria.View;
using MacLevs_Burgeria.ViewModel;
using MaterialDesignThemes.Wpf;
using System.Data;
using System.Data.SqlClient;

namespace MacLevs_Burgeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            loadingWindow loadingWin = new loadingWindow();
            loadingWin.Topmost = true;
            loadingWin.Show();
            InitializeComponent();
            DataContext = new MainViewModel();
            HeaderControl.Content = new HeaderView();
        }

        private void flee_MouseDown(object sender, MouseButtonEventArgs e) => this.DragMove();
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => this.Close();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if(AdminPasswordBox.Password == "levyndra")
            {
                ch1_f.Visibility = Visibility.Collapsed;
                DialogHost.CloseDialogCommand.Execute(null, null);
                btnGotoAdminPanel.IsEnabled = false;
                Window1 admPanel = new Window1();
                admPanel.ShowDialog();

            }
            else
            {
                ch1_f.Visibility = Visibility.Visible;
            }
                
        }

        private void dotsBtn_Click(object sender, RoutedEventArgs e)
        {
            #region popupSortPanel
            if (!popupSortPanel.IsVisible)
            {
                popupSortPanel.Visibility = Visibility.Visible;
                dotsBtn.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            }
            else
            {
                dotsBtn.Foreground = new SolidColorBrush(Color.FromRgb(118, 119, 121));
                popupSortPanel.Visibility = Visibility.Collapsed;
            }
            #endregion
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void ListProductBurgers_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
