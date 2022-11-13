using PM2_P2Tarea2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2_P2Tarea2_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageList : ContentPage
    {
        

        public PageList()
        {
            InitializeComponent();
            if (App.DBaseFirma == null)
            {

            }
        }

        private void listFirmas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
        }

    }
}