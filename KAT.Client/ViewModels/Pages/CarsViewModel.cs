using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using KAT.Client.Ninject;
using KAT.Client.Utilities;
using KAT.IServices;
using KAT.Models.Car;
using Ninject;

namespace KAT.Client.ViewModels.Pages
{
    public class CarsViewModel : INotifyPropertyChanged
    {
        private ICommand getCarsCommand;
        private ICommand insertCarCommand;
        private ICommand updateCarCommand;
        private ICommand deleteCarCommand;
        private ICommand searchCarCommand;
        private ICommand openEditorCommand;
        private ObservableCollection<Car> cars;
        private Car selectedCar;
        private Car updatedCar;
        private Car insertedCar;
        private string searchRegNumber;
        private string searchFullName;
        private readonly ICarsService carsService;

        public CarsViewModel()
        {
            carsService = NinjectConfig.Kernel.Get<ICarsService>();
            Cars = new ObservableCollection<Car>(carsService.GetCars());

            GetCarsCommand = new RelayCommand(GetCars);
            InsertCarCommand = new RelayCommand(InsertCar);
            UpdateCarCommand = new RelayCommand(UpdateCar);
            DeleteCarCommand = new RelayCommand(DeleteCar);
            SearchCarCommand = new RelayCommand(SearchCar);
            OpenEditorCommand = new RelayCommand(OpenEditor);

            SearchRegNumber = string.Empty;
            SearchFullName = string.Empty;
        }

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        // Commands
        public ICommand GetCarsCommand
        {
            get { return getCarsCommand; }
            set
            {
                getCarsCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand InsertCarCommand
        {
            get { return insertCarCommand; }
            set
            {
                insertCarCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand UpdateCarCommand
        {
            get { return updateCarCommand; }
            set
            {
                updateCarCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand DeleteCarCommand
        {
            get { return deleteCarCommand; }
            set
            {
                deleteCarCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SearchCarCommand
        {
            get { return searchCarCommand; }
            set
            {
                searchCarCommand = value;
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
        public ObservableCollection<Car> Cars
        {
            get { return cars; }
            set
            {
                cars = value;
                NotifyPropertyChanged();
            }
        }

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                NotifyPropertyChanged();
            }
        }

        public Car InsertedCar
        {
            get { return insertedCar; }
            set
            {
                insertedCar = value;
                NotifyPropertyChanged();
            }
        }

        public Car UpdatedCar
        {
            get { return updatedCar; }
            set
            {
                updatedCar = value;
                NotifyPropertyChanged();
            }
        }

        public string SearchRegNumber
        {
            get { return searchRegNumber; }
            set
            {
                searchRegNumber = value;
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

        private void GetCars(object obj)
        {
            
        }

        private void InsertCar(object obj)
        {

        }

        private void UpdateCar(object obj)
        {

        }

        private void DeleteCar(object obj)
        {

        }

        private void SearchCar(object obj)
        {
            var result = carsService.GetCars().Where(c =>
                (SearchRegNumber == string.Empty || c.RegNumber.Contains(SearchRegNumber))).ToList();
            Cars = new ObservableCollection<Car>();
            result.ForEach(r => Cars.Add(r));

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
