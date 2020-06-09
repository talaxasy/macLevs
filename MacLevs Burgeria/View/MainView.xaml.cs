using MacLevs_Burgeria.ViewModel;
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

namespace MacLevs_Burgeria.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            
        }

        //private void dotsBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    #region popupSortPanel
        //    if (!popupSortPanel.IsVisible)
        //    {
        //        popupSortPanel.Visibility = Visibility.Visible;
        //        dotsBtn.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
        //    }
        //    else
        //    {
        //        dotsBtn.Foreground = new SolidColorBrush(Color.FromRgb(118, 119, 121));
        //        popupSortPanel.Visibility = Visibility.Collapsed;
        //    }
        //    #endregion
        //}

        //private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    #region popupSortPanel
        //    if (popupSortPanel.IsVisible && !popupSortPanel.IsMouseOver && !dotsBtn.IsMouseOver)
        //    {
        //        popupSortPanel.Visibility = Visibility.Collapsed;
        //        dotsBtn.Foreground = new SolidColorBrush(Color.FromRgb(118, 119, 121));
        //    }
        //    #endregion
        //}
        //private void UserControl_MouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    #region popupSortPanel
        //    if (popupSortPanel != null && popupSortPanel.IsVisible)
        //    {
        //        dotsBtn.Foreground = new SolidColorBrush(Color.FromRgb(118, 119, 121));
        //        popupSortPanel.Visibility = Visibility.Collapsed;
        //    }
        //    #endregion
        //}
    }
}
