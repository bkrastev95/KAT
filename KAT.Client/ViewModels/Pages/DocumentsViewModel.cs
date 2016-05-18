using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using KAT.Client.Ninject;
using KAT.Client.Utilities;
using KAT.Client.Utilities.Messenger;
using KAT.Client.Views;
using KAT.IServices;
using KAT.Models.Document;
using KAT.Models.Driver;
using KAT.Models.Nomenclature;
using KAT.Models.Policeman;
using KAT.Models.Violation;
using Ninject;

namespace KAT.Client.ViewModels.Pages
{
    public class DocumentsViewModel : INotifyPropertyChanged
    {
        private string regNumber;
        private string fullName;
        private ObservableCollection<Document> documents;
        private List<Policeman> policemen;
        private List<Violation> violations;
        private ObservableCollection<Violation> chosenViolations;
        private List<Driver> drivers;
        private List<Nomenclature> docTypes;
        private Document searchDocument;
        private Document selectedDocument;
        private Document upsertedDocument;
        private Violation selectedViolation;
        private Violation violationToAdd;
        private ICommand insertDocumentCommand;
        private ICommand deleteDocumentCommand;
        private ICommand updateDocumentCommand;
        private ICommand getDocumentsCommand;
        private ICommand openEditorCommand;
        private ICommand addViolationToDocument;
        private ICommand removeViolationFromDocument;
        private readonly IDocumentsService documentsService;
        private readonly IDriversService driversService;
        private readonly INomenclatureService nomenclatureService;

        public DocumentsViewModel()
        {
            documentsService = NinjectConfig.Kernel.Get<IDocumentsService>();
            driversService = NinjectConfig.Kernel.Get<IDriversService>();
            nomenclatureService = NinjectConfig.Kernel.Get<INomenclatureService>();

            InsertDocumentCommand = new RelayCommand(InsertDocument);
            GetDocumentsCommand = new RelayCommand(GetDocuments);
            UpdateDocumentCommand = new RelayCommand(UpdateDocument);
            DeleteDocumentCommand = new RelayCommand(DeleteDocument);
            OpenEditorCommand = new RelayCommand(OpenEditor);
            AddViolationToDocumentCommand = new RelayCommand(AddViolationToDocument);
            RemoveViolationFromDocumentCommand = new RelayCommand(RemoveViolationFromDocument);

            Documents = new ObservableCollection<Document>(documentsService.GetDocuments(new Document()));
            DocTypes = nomenclatureService.GetDocTypes();
            SearchDocument = new Document();
            UpsertedDocument = new Document();
            RegNumSearch = FullNameSearch = string.Empty;
        }
        
        #region Properties

        public string RegNumSearch
        {
            get { return regNumber; }
            set
            {
                regNumber = value;
                NotifyPropertyChanged();
            }
        }

        public string FullNameSearch
        {
            get { return fullName; }
            set
            {
                fullName = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand InsertDocumentCommand
        {
            get { return insertDocumentCommand; }
            set
            {
                insertDocumentCommand = value;
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

        public ICommand DeleteDocumentCommand
        {
            get { return deleteDocumentCommand; }
            set
            {
                deleteDocumentCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand UpdateDocumentCommand
        {
            get { return updateDocumentCommand; }
            set
            {
                updateDocumentCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand GetDocumentsCommand
        {
            get { return getDocumentsCommand; }
            set
            {
                getDocumentsCommand = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand AddViolationToDocumentCommand
        {
            get { return addViolationToDocument; }
            set
            {
                addViolationToDocument = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand RemoveViolationFromDocumentCommand
        {
            get { return removeViolationFromDocument; }
            set
            {
                removeViolationFromDocument = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Document> Documents
        {
            get
            {
                /* OLD:
                 * 
                 * .Where( d =>
                    (RegNumSearch == string.Empty || d.RegNumber.Contains(RegNumSearch))
                    && (FullNameSearch == string.Empty || d.Driver.FullName.Contains(FullNameSearch)))
                 */
                return new ObservableCollection<Document>(documents.ToList());
            }
            set
            {
                documents = value;
                NotifyPropertyChanged();
            }
        }

        public List<Policeman> Policemen
        {
            get { return policemen; }
            set
            {
                policemen = value;
                NotifyPropertyChanged();
            }
        }

        public List<Driver> Drivers
        {
            get { return drivers; }
            set
            {
                drivers = value;
                NotifyPropertyChanged();
            }
        }

        public List<Nomenclature> DocTypes
        {
            get { return docTypes; }
            set
            {
                docTypes = value;
                NotifyPropertyChanged();
            }
        }
        
        public List<Violation> Violations
        {
            get { return violations; }
            set
            {
                violations = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Violation> ChosenViolations
        {
            get { return chosenViolations; }
            set
            {
                chosenViolations = value;
                NotifyPropertyChanged();
            }
        }


        public Document SearchDocument
        {
            get { return searchDocument; }
            set
            {
                searchDocument = value;
                NotifyPropertyChanged();
            }
        }

        public Document UpsertedDocument
        {
            get { return upsertedDocument; }
            set
            {
                upsertedDocument = value;
                NotifyPropertyChanged();
            }
        }

        public Document SelectedDocument
        {
            get { return selectedDocument; }
            set
            {
                selectedDocument = value;
                NotifyPropertyChanged();
            }
        }

        public Violation SelectedViolation
        {
            get { return selectedViolation; }
            set
            {
                selectedViolation = value;
                NotifyPropertyChanged();
            }
        }

        public Violation ViolationToAdd
        {
            get { return violationToAdd; }
            set
            {
                violationToAdd = value;
                NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region CommandMethods

        private void GetDocuments(object obj)
        {
            Documents = new ObservableCollection<Document>(documentsService.GetDocuments(new Document
            {
                RegNumber = RegNumSearch,
                Driver = ComposeSearchName()
            }));
        }

        private void InsertDocument(object obj)
        {
            if (UpsertedDocument != new Document())
            {
                UpsertedDocument.Violations = ChosenViolations.ToList();

                // Generate regNumber
                if (string.IsNullOrEmpty(UpsertedDocument.RegNumber))
                {
                    if (Documents.Any())
                    {
                        UpsertedDocument.RegNumber =
                            string.Format("{0} - {1}", Documents.FirstOrDefault(d => d.Id == Documents.Select(doc => doc.Id).Max()).Id, DateTime.Today.Date);
                    }
                }

                UpsertedDocument.Id = documentsService.InsertDocument(UpsertedDocument);
                if (UpsertedDocument.Id > 0)
                {
                    Documents.Add(UpsertedDocument);
                    Messenger.ShowMessage("Успешен запис", MessageType.Success);
                }
                else
                {
                    Messenger.ShowMessage("Неуспешен запис!", MessageType.Error);
                }

                ResetDocumentOnUpsert();
            }
            else
            {
                Messenger.ShowMessage("Липсва документ!", MessageType.Error);
            }
        }

        private void UpdateDocument(object obj)
        {
            if (UpsertedDocument != new Document())
            {
                UpsertedDocument.Violations = ChosenViolations.ToList();
                if (documentsService.UpdateDocument(UpsertedDocument))
                {
                    var existingRecord = Documents.FirstOrDefault(d => d.Id == UpsertedDocument.Id);
                    PropertyCopy.Copy(UpsertedDocument, existingRecord);
                    //Documents.Remove(existingRecord);
                    //Documents.Add(UpsertedDocument);
                    
                    Messenger.ShowMessage("Успешна редакция", MessageType.Success);
                }
                else
                {
                    Messenger.ShowMessage("Грешка при редакция на документа!", MessageType.Error);
                }

                ResetDocumentOnUpsert();
            }
            else
            {
                Messenger.ShowMessage("Грешка при редакция на документа!", MessageType.Error);
            }
        }

        private void DeleteDocument(object obj)
        {
            if (SelectedDocument != null)
            {
                if (documentsService.DeleteDocument(SelectedDocument.Id))
                {
                    Documents.Remove(Documents.FirstOrDefault(d => d.Id == SelectedDocument.Id));
                    Messenger.ShowMessage("Документа е изтрит успешно!", MessageType.Error);
                }
                else
                {
                    Messenger.ShowMessage("Грешка при изтриване!", MessageType.Error);
                }
            }
            else
            {
                Messenger.ShowMessage("Не е избран документ!", MessageType.Error);
            }
        }

        private void OpenEditor(object obj)
        {
            var action = obj.ToString();
            InitializeDocumentForUpsert(action);

            
            var editor = new EditorWindow(action, this);
            editor.Show();
        }

        private void AddViolationToDocument(object obj)
        {
            if (ChosenViolations == null)
            {
                ChosenViolations = new ObservableCollection<Violation>();
            }

            if (!ChosenViolations.Contains(ViolationToAdd))
            {
                ChosenViolations.Add(ViolationToAdd);                
            }
        }

        private void RemoveViolationFromDocument(object obj)
        {
            if (ChosenViolations == null)
            {
                ChosenViolations = new ObservableCollection<Violation>();
            }

            ChosenViolations.Remove(SelectedViolation);
        }

        #endregion

        #region Helpers

        private void InitializeDocumentForUpsert(string action)
        {
            // Initialize dropdowns
            Drivers = driversService.GetDrivers();
            Policemen = nomenclatureService.GetPolicemen();
            Violations = nomenclatureService.GetViolations();
            ChosenViolations = new ObservableCollection<Violation>();

            if (action != "Insert")
            {
                PropertyCopy.Copy(SelectedDocument, UpsertedDocument);
            }

            // Init violations
            if (UpsertedDocument.Violations != null)
            {
                UpsertedDocument.Violations.ForEach(v => ChosenViolations.Add(v));
            }

            // Init date
            if (UpsertedDocument.Date == new DateTime())
            {
                UpsertedDocument.Date = DateTime.Now;
            }
        }

        private void ResetDocumentOnUpsert()
        {
            UpsertedDocument = new Document();
            ChosenViolations = new ObservableCollection<Violation>();
        }

        private Driver ComposeSearchName()
        {
            var driver = new Driver();
            var names = FullNameSearch.Split(' ');
            if (names.Length == 1)
            {
                driver.FirstName = names.FirstOrDefault();
            }
            else if (names.Length == 2)
            {
                driver.FirstName = names.FirstOrDefault();
                driver.LastName = names.LastOrDefault();
            }
            else
            {
                driver.FirstName = names.FirstOrDefault();
                driver.LastName = names.LastOrDefault();
                driver.SecondName = string.Join(" ", names.Except(new List<string> { names.First(), names.Last() }).ToList());
            }

            return driver;
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
