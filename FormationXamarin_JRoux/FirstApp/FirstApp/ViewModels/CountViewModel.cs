using System.ComponentModel;
using System.Runtime.CompilerServices;
using FirstApp.Annotations;
using FirstApp.ViewModels.Commands;

namespace FirstApp.ViewModels
{
    public class CountViewModel : INotifyPropertyChanged
    {
        private int _count;

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged("Count");
            }
        }
        
        public CountIncrementCommand CountIncrementCommand { get; set; }
        public CountDecrementCommand CountDecrementCommand { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public CountViewModel()
        {
            Count = 12;

            CountIncrementCommand = new CountIncrementCommand(this);
            CountDecrementCommand = new CountDecrementCommand(this);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void IncrementCount()
        {
            Count++;
        }
        
        public void DecrementCount()
        {
            Count--;
        }
    }
}