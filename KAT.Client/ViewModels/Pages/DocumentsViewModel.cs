using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using KAT.Client.Ninject;
using KAT.Client.Utilities;
using KAT.Client.Utilities.Messenger;
using KAT.IServices;
using KAT.Models.Document;
using Ninject;

namespace KAT.Client.ViewModels.Pages
{
    public class DocumentsViewModel : INotifyPropertyChanged
    {
        private string regNumber;
        private string fullName;
        private List<Document> documents;
        private Document searchDocument;
        private Document selectedDocument;
        private Document insertedDocument;
        private Document updatedDocument;
        private ICommand insertDocumentCommand;
        private ICommand deleteDocumentCommand;
        private ICommand updateDocumentCommand;
        private ICommand getDocumentsCommand;
        private ICommand openEditorCommand;
        private readonly IDocumentsService documentsService;

        public DocumentsViewModel()
        {
            documentsService = NinjectConfig.Kernel.Get<IDocumentsService>();
            Documents = documentsService.GetDocuments(new Document());
            InsertDocumentCommand = new RelayCommand(InsertDocument);
            GetDocumentsCommand = new RelayCommand(GetDocuments);
            UpdateDocumentCommand = new RelayCommand(UpdateDocument);
            DeleteDocumentCommand = new RelayCommand(DeleteDocument);
            OpenEditorCommand = new RelayCommand(OpenEditor);
            SearchDocument = InsertedDocument = UpdatedDocument = new Document();
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

        public List<Document> Documents
        {
            get
            {
                return documents.Where( d =>
                    (RegNumSearch == string.Empty || d.RegNumber.Contains(RegNumSearch))
                    && (FullNameSearch == string.Empty || d.Driver.FullName.Contains(FullNameSearch))).ToList();
            }
            set
            {
                documents = value;
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

        public Document InsertedDocument
        {
            get { return insertedDocument; }
            set
            {
                insertedDocument = value;
                NotifyPropertyChanged();
            }
        }

        public Document UpdatedDocument
        {
            get { return updatedDocument; }
            set
            {
                updatedDocument = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region CommandMethods

        private void GetDocuments(object obj)
        {
            Documents = documentsService.GetDocuments(SearchDocument);
        }

        private void InsertDocument(object obj)
        {
            if (InsertedDocument != new Document())
            {
                InsertedDocument.Id = documentsService.InsertDocument(InsertedDocument);
                if (InsertedDocument.Id > 0)
                {
                    Documents.Add(InsertedDocument);
                    Messenger.ShowMessage("Успешен запис", MessageType.Success);
                }
                else
                {
                    Messenger.ShowMessage("Неуспешен запис!", MessageType.Error);
                }

                InsertedDocument = new Document();
            }
            else
            {
                Messenger.ShowMessage("Липсва документ!", MessageType.Error);
            }
        }

        private void UpdateDocument(object obj)
        {
            if (UpdatedDocument != new Document())
            {
                if (documentsService.UpdateDocument(UpdatedDocument))
                {
                    var updatedDoc = Documents.Find(d => d.Id == UpdatedDocument.Id);
                    PropertyCopy.Copy(UpdatedDocument, updatedDoc);
                    Messenger.ShowMessage("Успешна редакция", MessageType.Success);
                }
                else
                {
                    Messenger.ShowMessage("Грешка при редакция на документа!", MessageType.Error);
                }

                UpdatedDocument = new Document();
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
