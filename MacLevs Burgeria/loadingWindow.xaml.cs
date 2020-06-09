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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MacLevs_Burgeria
{
    public partial class loadingWindow : Window
    {
        private DispatcherTimer timer = null;
        public loadingWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 120);
            timer.Start();
        }
        private void timerTick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            loadingPanelPart.Width += rnd.Next(rnd.Next(5, 20), rnd.Next(20, 50));
            if (loadingPanelPart.Width >= 600)
            {
                timer.Stop();
                //MainWindow mainWin = new MainWindow();
                //mainWin.Show();
                this.Hide();
                this.Close();
            }
        }
    }
}
