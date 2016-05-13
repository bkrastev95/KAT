using System.Windows.Media;
using KAT.Client.Utilities.Messenger;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace KAT.Client.Views
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : MetroWindow
    {
        public MessageWindow(string message, MessageType messageType)
        {
            InitializeComponent();
            MessageHolder.Text = message;
            Topmost = true;
            switch (messageType)
            {
                    case MessageType.Success:
                    ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Green"),
                                    ThemeManager.GetAppTheme("BaseLight"));
                    Border.BorderBrush = Brushes.Green;
                    break;
                    case MessageType.Warning:
                    ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Yellow"),
                                    ThemeManager.GetAppTheme("BaseLight"));
                    Border.BorderBrush = Brushes.Yellow;
                    break;
                    case MessageType.Info:
                    ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Blue"),
                                    ThemeManager.GetAppTheme("BaseLight"));
                    Border.BorderBrush = Brushes.Blue;
                    break;
                    case MessageType.Error:
                    ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Red"),
                                    ThemeManager.GetAppTheme("BaseLight"));
                    Border.BorderBrush = Brushes.Red;
                    break;
            }
        }
    }
}
