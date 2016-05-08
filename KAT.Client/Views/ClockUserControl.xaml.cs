using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KAT.Client.Views
{
    /// <summary>
    /// Interaction logic for ClockUserControl.xaml
    /// </summary>
    public partial class ClockUserControl : UserControl
    {
        Timer timer = new Timer(1000);

        public ClockUserControl()
        {
            InitializeComponent();
            //MDCalendar mdCalendar = new MDCalendar();
            //var date = DateTime.Now;
            //var time = TimeZone.CurrentTimeZone;
            //var difference = time.GetUtcOffset(date);
            //uint currentTime = mdCalendar.Time() + (uint)difference.TotalSeconds;
            //persianCalendar.Content = mdCalendar.Date("Y/m/D  W", currentTime, true);
            //christianityCalendar.Content = mdCalendar.Date("P Z/e/d", currentTime, false);

            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                SecondHand.Angle = DateTime.Now.Second * 6;
                MinuteHand.Angle = DateTime.Now.Minute * 6;
                HourHand.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);
            }));
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // this.DragMove();
        }
    }
}
