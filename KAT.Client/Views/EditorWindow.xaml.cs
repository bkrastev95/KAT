using System;
using KAT.Client.ViewModels.Pages;
using KAT.Client.Views.Pages;
using KAT.Models.Car;
using KAT.Models.Document;
using KAT.Models.Driver;
using MahApps.Metro.Controls;

namespace KAT.Client.Views
{
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : MetroWindow
    {
        public EditorWindow(string action, DocumentsViewModel viewModel)
        {
            InitializeComponent();
            Title = action == "Insert" ? "Въвеждане на документ" : "Редакция на документ";
            EditorFrame.Navigate(new UpsertDocument(viewModel, action));
        }

        public EditorWindow(string action, DriversViewModel driver)
        {
            InitializeComponent();
            Title = action == "Insert" ? "Въвеждане на водач" : "Редакция на водач";
            //EditorFrame.Navigate(new UpsertDocument(driver));
        }

        public EditorWindow(string action, CarsViewModel car)
        {
            InitializeComponent();
            Title = action == "Insert" ? "Въвеждане на МПС" : "Редакция на МПС";
            //EditorFrame.Navigate(new UpsertDocument(car));
        }

        public EditorWindow(string action, PolicemenViewModel policemen)
        {
            InitializeComponent();
            Title = action == "Insert" ? "Въвеждане на служител" : "Редакция на служител";
            EditorFrame.Navigate(new UpsertPolicemanPage(policemen, action));
        }
    }
}
