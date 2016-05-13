using System.ComponentModel;
using System.Runtime.CompilerServices;
using KAT.Client.Ninject;
using KAT.IServices;
using Ninject;

namespace KAT.Client.ViewModels.Pages
{
    public class DriversViewModel : INotifyPropertyChanged
    {
        private readonly INomenclatureService nomenclatureService;

        public DriversViewModel()
        {
            nomenclatureService = NinjectConfig.Kernel.Get<INomenclatureService>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }
    }
}
