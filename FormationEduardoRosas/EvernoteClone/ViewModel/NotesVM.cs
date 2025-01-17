﻿using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EvernoteClone.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }
        private Notebook _selectedNotebook;
        private Visibility _isVisible;
        private Note _selectedNote;
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

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set 
            { 
                _selectedNote = value;
                OnPropertyChanged("SelectedNote");
                SelectedNoteChanged.Invoke(this, new EventArgs());
            }
        }


        public Visibility IsVisible
        {
            get { return _isVisible; }
            set 
            { 
                _isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }


        public NewNoteCommand NewNoteCommand { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }
        public EditCommand EditCommand { get; set; }
        public EndEditingCommand EndEditingCommand { get; set; }
        public DeleteCommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler SelectedNoteChanged;
        public NotesVM()
        {
            NewNoteCommand = new NewNoteCommand(this);
            NewNotebookCommand = new NewNotebookCommand(this);
            EditCommand = new EditCommand(this);
            EndEditingCommand = new EndEditingCommand(this);
            DeleteCommand = new DeleteCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();
            IsVisible = Visibility.Collapsed;

            GetNotebooks();
        }

        public async void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "Notebook",
                UserId = App.UserId

            };

            await DatabaseHelper.Insert(newNotebook);
            GetNotebooks();
        }

        public async void CreateNote(string notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = "New note",

            };

            await DatabaseHelper.Insert(newNote);
            GetNotes();
        }

        public async void GetNotebooks()
        {
            var notebooks = (await DatabaseHelper.Read<Notebook>()).Where(n => n.UserId == App.UserId).ToList();

            Notebooks.Clear();
            foreach (Notebook notebook in notebooks) Notebooks.Add(notebook);
        }

        private async void GetNotes()
        {
            if (SelectedNotebook != null)
            {
                var notes = (await DatabaseHelper.Read<Note>()).Where(x => x.NotebookId == SelectedNotebook.Id).ToList();

                Notes.Clear();
                foreach (Note note in notes) Notes.Add(note);
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public async void Delete(Notebook notebook)
        {
            await DatabaseHelper.Delete(notebook);

            GetNotebooks();
        }

        public void StartEditing()
        {
            IsVisible = Visibility.Visible;
        }

        public async void StopEditing(Notebook notebook)
        {
            IsVisible = Visibility.Collapsed;
            await DatabaseHelper.Update(notebook);

            GetNotebooks();
        }
    }
}
