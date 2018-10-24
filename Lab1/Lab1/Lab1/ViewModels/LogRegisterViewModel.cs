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

        #region Commands

        public ICommand InsertLogCommand { get; private set; }

        #endregion

        #region private Methods

        private void initCommands()
        {
            InsertLogCommand = new Command(InsertLog);
        }

        private void InsertLog(object obj)
        {
            try
            {

            }
            catch (Exception ex)
            {
                
            }
            
        }

        private void initClass()
        {

        }
        #endregion
    }
}
