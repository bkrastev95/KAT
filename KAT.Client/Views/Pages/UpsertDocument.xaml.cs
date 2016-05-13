using System.Windows.Controls;
using KAT.Models.Document;

namespace KAT.Client.Views.Pages
{
    /// <summary>
    /// Interaction logic for UpsertDocument.xaml
    /// </summary>
    public partial class UpsertDocument : Page
    {
        public UpsertDocument(Document document)
        {
            InitializeComponent();
            DataContext = document;
        }
    }
}
