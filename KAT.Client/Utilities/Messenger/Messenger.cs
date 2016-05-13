using KAT.Client.Views;

namespace KAT.Client.Utilities.Messenger
{
    public static class Messenger
    {
        public static void ShowMessage(string message, MessageType messageType)
        {
            var messageWindow = new MessageWindow(message, messageType);
            messageWindow.Show();
        }
    }
}
