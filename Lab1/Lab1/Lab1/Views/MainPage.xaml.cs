using Lab1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab1.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = LogRegisterViewModel.GetInstance(true);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        async void Button_ChangeColor_Clicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            Device.BeginInvokeOnMainThread(() =>
            {
                lblWelcome.TextColor = Color.Red;
            });
            
        }
    }
}
