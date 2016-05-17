using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KAT.Client.Ninject;
using KAT.Client.Utilities;
using KAT.IServices;
using KAT.Models.Car;
using Ninject;

namespace KAT.Client.ViewModels.Pages
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string searchRegNumber;
        private bool isSelected;
        private ICommand searchCarCommand;
        private ObservableCollection<Car> cars;
        private readonly ICarsService carsService;
        private Car selectedCar;

        public HomeViewModel()
        {
            carsService = NinjectConfig.Kernel.Get<ICarsService>();
            Cars = new ObservableCollection<Car>(carsService.GetCars());
            SearchRegNumber = string.Empty;

            SearchCarCommand = new RelayCommand(SearchCar);
        }

        #region Properties

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
                IsSelected = value != null && value != new Car(); 
                NotifyPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
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

        public ICommand SearchCarCommand
        {
            get { return searchCarCommand; }
            set
            {
                searchCarCommand = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        
        private void SearchCar(object obj)
        {
            var result = carsService.GetCars().Where(c =>
                (SearchRegNumber == string.Empty || c.RegNumber.Contains(SearchRegNumber))).ToList();
            Cars = new ObservableCollection<Car>();
            result.ForEach(r => Cars.Add(r));

        }

        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }

    }
}
