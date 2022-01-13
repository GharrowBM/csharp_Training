using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FirstApp.Annotations;
using FirstApp.ViewModels.Commands;
using FirstApp.Views;

namespace FirstApp.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        private MenuPage _page;
        
        public OpenCountPageCommand OpenCountPageCommand { get; set; }
        public OpenTabsPageCommand OpenTabsPageCommand { get; set; }
        public OpenListPageCommand OpenListPageCommand { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public MenuViewModel(MenuPage page)
        {
            _page = page;

            OpenCountPageCommand = new OpenCountPageCommand(this);
            OpenTabsPageCommand = new OpenTabsPageCommand(this);
            OpenListPageCommand = new OpenListPageCommand(this);
        }

        public MenuViewModel()
        {
            
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OpenCountPage()
        {
            _page.Navigation.PushAsync(new CountPage());
        }

        public void OpenTabsPage()
        {
            _page.Navigation.PushAsync(new TabsPage());
        }

        public void OpenListPage()
        {
            _page.Navigation.PushAsync(new ListPage());
        }
    }
}