using System.Collections.Generic;
using System.ComponentModel;
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
        private ICommand getDriversCommand;
        private ICommand insertDriverCommand;
        private ICommand updateDriverCommand;
        private ICommand deleteDriverCommand;
        private ICommand openEditorCommand;
        private List<Driver> drivers;
        private Driver selectedDriver;
        private Driver updatedDriver;
        private Driver insertedDriver;
        private string searchEgn;
        private string searchFullName;
        private readonly IDriversService driversService;

        public DriversViewModel()
        {
            driversService = NinjectConfig.Kernel.Get<IDriversService>();
            Drivers = driversService.GetDrivers();

            GetDriversCommand = new RelayCommand(GetDrivers);
            InsertDriverCommand = new RelayCommand(InsertDriver);
            UpdateDriverCommand = new RelayCommand(UpdateDriver);
            DeleteDriverCommand = new RelayCommand(DeleteDriver);
            OpenEditorCommand = new RelayCommand(OpenEditor);

            SearchEgn = SearchFullName = string.Empty;
        }

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        // Commands
        public ICommand GetDriversCommand
        {
            get { return getDriversCommand; }
            set
            {
                getDriversCommand = value;
                NotifyPropertyChanged();
            }
        }

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
        public List<Driver> Drivers
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

        private void GetDrivers(object obj)
        {
            
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
