﻿using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class DeleteCommand : ICommand
    {
        public NotesVM VM { get; set; }
        public event EventHandler? CanExecuteChanged;

        public DeleteCommand(NotesVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Notebook notebook = parameter as Notebook;
            
            VM.Delete(notebook);

        }
    }
}
