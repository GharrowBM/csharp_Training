using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }
        private Notebook _selectedNotebook;
        public Notebook SelectedNotebook
        {
            get { return _selectedNotebook; }
            set
            {
                _selectedNotebook = value;
                OnPropertyChanged("SelectedNotebook");
                GetNotes();
            }
        }

        public NewNoteCommand NewNoteCommand { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public NotesVM()
        {
            NewNoteCommand = new NewNoteCommand(this);
            NewNotebookCommand = new NewNotebookCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            GetNotebooks();
        }

        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New notebook",

            };

            DatabaseHelper.Insert(newNotebook);
            GetNotebooks();
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = "New note",

            };

            DatabaseHelper.Insert(newNote);
            GetNotes();
        }

        private void GetNotebooks()
        {
            var notebooks = DatabaseHelper.Read<Notebook>();

            Notebooks.Clear();
            foreach (Notebook notebook in notebooks) Notebooks.Add(notebook);
        }

        private void GetNotes()
        {
            if (SelectedNotebook != null)
            {
                var notes = DatabaseHelper.Read<Note>().Where(x => x.NotebookId == SelectedNotebook.Id).ToList();

                Notes.Clear();
                foreach (Note note in notes) Notes.Add(note);
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
