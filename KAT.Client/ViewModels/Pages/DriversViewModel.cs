using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media.Animation;
using FirstFloor.ModernUI.Presentation;
using KAT.Client.Ninject;
using KAT.IServices;
using KAT.Models.Driver;
using Ninject;

namespace KAT.Client.ViewModels.Pages
{
    public class DriversViewModel : INotifyPropertyChanged
    {
        private ICommand insertDriverCommand;
        private ICommand updateDriverCommand;
        private ICommand deleteDriverCommand;
        private ICommand searchDriverCommand;
        private ICommand openEditorCommand;
        private ObservableCollection<Driver> drivers;
        private Driver selectedDriver;
        private Driver updatedDriver;
        private Driver insertedDriver;
        private string searchEgn;
        private string searchFullName;
        private readonly IDriversService driversService;

        public DriversViewModel()
        {
            driversService = NinjectConfig.Kernel.Get<IDriversService>();
            Drivers = new ObservableCollection<Driver>(driversService.GetDrivers());

            SearchDriverCommand = new RelayCommand(SearchDrivers);
            InsertDriverCommand = new RelayCommand(InsertDriver);
            UpdateDriverCommand = new RelayCommand(UpdateDriver);
            DeleteDriverCommand = new RelayCommand(DeleteDriver);
            OpenEditorCommand = new RelayCommand(OpenEditor);

            SearchEgn = SearchFullName = string.Empty;
        }

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        // Commands
        public ICommand InsertDriverCommand
        {
            get { return insertDriverCommand; }
            set
            {
                insertDriverCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand UpdateDriverCommand
        {
            get { return updateDriverCommand; }
            set
            {
                updateDriverCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand DeleteDriverCommand
        {
            get { return deleteDriverCommand; }
            set
            {
                deleteDriverCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SearchDriverCommand
        {
            get { return searchDriverCommand; }
            set
            {
                searchDriverCommand = value;
                NotifyPropertyChanged();
            }
        }


        public ICommand OpenEditorCommand
        {
            get { return openEditorCommand; }
            set
            {
                openEditorCommand = value;
                NotifyPropertyChanged();
            }
        }

        // Bindings
        public ObservableCollection<Driver> Drivers
        {
            get { return drivers; }
            set
            {
                drivers = value;
                NotifyPropertyChanged();
            }
        }

        public Driver SelectedDriver
        {
            get { return selectedDriver; }
            set
            {
                selectedDriver = value;
                NotifyPropertyChanged();
            }
        }

        public Driver InsertedDriver
        {
            get { return insertedDriver; }
            set
            {
                insertedDriver = value;
                NotifyPropertyChanged();
            }
        }

        public Driver UpdatedDriver
        {
            get { return updatedDriver; }
            set
            {
                updatedDriver = value;
                NotifyPropertyChanged();
            }
        }

        public string SearchEgn
        {
            get { return searchEgn; }
            set
            {
                searchEgn = value;
                NotifyPropertyChanged();
            }
        }

        public string SearchFullName
        {
            get { return searchFullName; }
            set
            {
                searchFullName = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private void SearchDrivers(object obj)
        {
            var result = driversService.GetDrivers().Where(d =>
                (SearchEgn == string.Empty || d.Egn.Contains(SearchEgn))
                && (SearchFullName == string.Empty || d.FullName.Contains(SearchFullName))).ToList();
            Drivers = new ObservableCollection<Driver>();
            result.ForEach(r => Drivers.Add(r));
        }

        private void InsertDriver(object obj)
        {

        }

        private void UpdateDriver(object obj)
        {

        }

        private void DeleteDriver(object obj)
        {

        }

        private void OpenEditor(object obj)
        {

        }

        #endregion

        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }
    }
}
