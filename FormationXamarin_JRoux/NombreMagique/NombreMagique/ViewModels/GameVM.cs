using System.ComponentModel;
using System.Runtime.CompilerServices;
using NombreMagique.Annotations;

namespace NombreMagique.ViewModels
{
    public class GameVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}