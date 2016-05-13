using System;
using System.Windows.Controls;
using KAT.Client.Views.Pages;
using KAT.Models.Document;
using MahApps.Metro.Controls;

namespace KAT.Client.Views
{
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : MetroWindow
    {
        public EditorWindow(string action, Document document)
        {
            InitializeComponent();
            Title = action;
            EditorFrame.Navigate(new UpsertDocument(document));
        }
    }
}
