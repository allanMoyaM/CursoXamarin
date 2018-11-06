using Acr.UserDialogs;
using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Utils
{
    public static class MessageHelper
    {
        public static void ControlError(Exception ex)
        {
            var toastConfig = new ToastConfig(App.Current.Resources["Error"].ToString());
            toastConfig.SetDuration(3000);
            toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(12, 131, 193));

            UserDialogs.Instance.Toast(toastConfig);
        }

        public static void ControlError(List<Error> errors)
        {
            errors?.ForEach(x => UserDialogs.Instance.Toast(x.Message));
        }

        public static void Toast(string v)
        {
            UserDialogs.Instance.Toast(v);
        }
    }
}
