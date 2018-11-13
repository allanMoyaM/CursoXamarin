using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab1.ViewModels
{
    public class MenuViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Instances
        private ObservableCollection<ItemMenuModel> itemMenuModels;

        public ObservableCollection<ItemMenuModel> lstItemsMenu
        {
            get => itemMenuModels;
            set
            {
                if (itemMenuModels != value) {
                    itemMenuModels = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region
        public ICommand GoToViewCommand { get; private set; }
        #endregion

        public MenuViewModel()
        {
            initCommands();
            initClass();
        }

        private void initClass()
        {
            lstItemsMenu = new ObservableCollection<ItemMenuModel>()
            {
                new ItemMenuModel(){Title = "Ejemplo lista", Detail = "Utilizando DataTemplate", ClassName="ListEntryView"}
            };
        }

        private void initCommands()
        {
            GoToViewCommand = new Command<string>(GoToView);
        }

        private void GoToView(string className)
        {
            var type = Type.GetType($"Lab1.Views.{className}");
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync((Page)Activator.CreateInstance(type));
        }
    }

}
