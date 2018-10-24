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
    }
}
