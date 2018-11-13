using Lab1.Models;
using Lab1.Utils;
using Lab1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab1.ViewModels
{
    public class LogRegisterViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Singleton
        private static LogRegisterViewModel instance;
        private LogRegisterViewModel()
        {
            initCommands();
            initClass();
        }

        public static LogRegisterViewModel GetInstance(bool refresh = false)
        {
            if (instance == null || refresh)
            {
                instance = new LogRegisterViewModel();
            }
            return instance;
        }
        #endregion

        #region Properties
        public EnumToolbar Parameter1 => EnumToolbar.Option1;
        public EnumToolbar Parameter2 => EnumToolbar.Option2;

        private string _message;

        public string Message
        {
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
            get => _message;
        }

        private bool _isBusy;

        public bool IsBusy
        {
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }

            get => _isBusy;
        }

        #endregion

        #region Commands

        public ICommand InsertLogCommand { get; private set; }

        public ICommand PressToolbarItemsCommands { get; private set; }

        public ICommand TapLabelCommand { get; private set; }
        

        #endregion

        #region private Methods

        private void initCommands()
        {
            InsertLogCommand = new Command(InsertLog);
            PressToolbarItemsCommands = new Command<EnumToolbar>(PressToolbarItems);
            TapLabelCommand = new Command(TapLabel);
        }

        private void TapLabel()
        {
            ((NavigationPage)(App.Current.MainPage)).PopAsync(true);
        }

        private void PressToolbarItems(EnumToolbar obj)
        {
            MessageHelper.Toast(obj.ToString());
        }

        private async void InsertLog(object obj)
        {
            try
            {
                IsBusy = true;
                LogRequest req = await LogRequest.InsertLogAsync(Message);

                if (!req.IsSuccessful)
                {
                    IsBusy = false;
                    MessageHelper.ControlError(req.Errors);
                    return;
                }

                Message = string.Empty;
                IsBusy = false;

                await ((NavigationPage)(App.Current.MainPage)).PushAsync(new ResultPage());
            }
            catch (Exception ex)
            {
                MessageHelper.ControlError(ex);
            }
            
        }

        private void initClass()
        {
            //Message = "Hola";
        }
        #endregion
    }

    public enum EnumToolbar
    {
        Option1 = 1,
        Option2 = 2,
    }
}
