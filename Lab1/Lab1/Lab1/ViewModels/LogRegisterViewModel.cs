using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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



        #endregion
    }
}
