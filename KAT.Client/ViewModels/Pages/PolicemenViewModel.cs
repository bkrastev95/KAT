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
using KAT.Client.Utilities.Messenger;
using KAT.Client.Views;
using KAT.Client.Views.Pages;
using KAT.IServices;
using KAT.Models.Nomenclature;
using KAT.Models.Policeman;
using Ninject;

namespace KAT.Client.ViewModels.Pages
{
    public class PolicemenViewModel : INotifyPropertyChanged
    {
        private ICommand getPolicemanCommand;
        private ICommand insertPolicemanCommand;
        private ICommand updatePolicemanCommand;
        private ICommand deletePolicemanCommand;
        private ICommand searchPolicemanCommand;
        private ICommand openEditorCommand;
        private ObservableCollection<Policeman> policemen;
        private List<Nomenclature> ranks;
        private Policeman selectedPoliceman;
        private Policeman upsertedPoliceman;
        private string searchRegNumber;
        private string searchFullName;
        private readonly INomenclatureService nomenclatureService;

        public PolicemenViewModel()
        {
            nomenclatureService = NinjectConfig.Kernel.Get<INomenclatureService>();
            Policemen = new ObservableCollection<Policeman>(nomenclatureService.GetPolicemen());
            Ranks = new List<Nomenclature>
            {
                new Nomenclature
                {
                    Code = "Офицер",
                    Id = 1
                },
                new Nomenclature
                {
                    Code = "Сержант",
                    Id = 2
                }
            };

            GetPolicemanCommand = new RelayCommand(GetPoliceman);
            InsertPolicemanCommand = new RelayCommand(InsertPoliceman);
            UpdatePolicemanCommand = new RelayCommand(UpdatePoliceman);
            DeletePolicemanCommand = new RelayCommand(DeletePoliceman);
            OpenEditorCommand = new RelayCommand(OpenEditor);

            SearchRegNumber = string.Empty;
            SearchFullName = string.Empty;
        }

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        // Commands
        public ICommand GetPolicemanCommand
        {
            get { return getPolicemanCommand; }
            set
            {
                getPolicemanCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand InsertPolicemanCommand
        {
            get { return insertPolicemanCommand; }
            set
            {
                insertPolicemanCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand UpdatePolicemanCommand
        {
            get { return updatePolicemanCommand; }
            set
            {
                updatePolicemanCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand DeletePolicemanCommand
        {
            get { return deletePolicemanCommand; }
            set
            {
                deletePolicemanCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SearchPolicemanCommand
        {
            get { return searchPolicemanCommand; }
            set
            {
                searchPolicemanCommand = value;
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
        public ObservableCollection<Policeman> Policemen
        {
            get { return policemen; }
            set
            {
                policemen = value;
                NotifyPropertyChanged();
            }
        }

        public List<Nomenclature> Ranks
        {
            get { return ranks; }
            set
            {
                ranks = value;
                NotifyPropertyChanged();
            }
        }

        public Policeman SelectedPoliceman
        {
            get { return selectedPoliceman; }
            set
            {
                selectedPoliceman = value;
                NotifyPropertyChanged();
            }
        }

        public Policeman UpsertedPoliceman
        {
            get { return upsertedPoliceman; }
            set
            {
                upsertedPoliceman = value;
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

        private void GetPoliceman(object obj)
        {
            
        }

        private void InsertPoliceman(object obj)
        {

        }

        private void UpdatePoliceman(object obj)
        {
            if (UpsertedPoliceman != null && !UpsertedPoliceman.Equals(new Policeman()))
            {
                if (nomenclatureService.UpdatePoliceman(UpsertedPoliceman))
                {
                    var existingRecord = Policemen.FirstOrDefault(p => p.Id == UpsertedPoliceman.Id);
                    Policemen.Remove(existingRecord);
                    Policemen.Add(UpsertedPoliceman);
                    // PropertyCopy.Copy(UpsertedPoliceman, Policemen.ToList().FirstOrDefault(d => d.Id == UpsertedPoliceman.Id));
                    Messenger.ShowMessage("Успешна редакция", MessageType.Success);
                }
                else
                {
                    Messenger.ShowMessage("Грешка при редакция на служител!", MessageType.Error);
                }
            }
            else
            {
                Messenger.ShowMessage("Грешка при редакция на служител!", MessageType.Error);
            }
        }

        private void DeletePoliceman(object obj)
        {

        }

        private void OpenEditor(object obj)
        {
            var action = obj.ToString();
            InitializePolicemanUpsert(action);
            var editor = new EditorWindow(action, this);
            editor.Show();
        }

        #endregion

        private void InitializePolicemanUpsert(string action)
        {
            Ranks = nomenclatureService.GetRanks();

            if (UpsertedPoliceman == null)
            {
                UpsertedPoliceman = new Policeman();
            }

            if (action != "Insert")
            {
                PropertyCopy.Copy(SelectedPoliceman, UpsertedPoliceman);
            }
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
