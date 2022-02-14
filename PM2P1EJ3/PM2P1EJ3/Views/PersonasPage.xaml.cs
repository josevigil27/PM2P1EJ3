using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM2P1EJ3.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P1EJ3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonasPage : ContentPage
    {
        public PersonasPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var pagina = new Views.PageCrearPersonas();
            await Navigation.PushAsync(pagina);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListaPersonas.ItemsSource = await App.BaseDatos.listapersonas();
        }

        private async void ListaPersonas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Personas item = (Models.Personas)e.Item;
            var newpage = new Views.PageUpdatePersonas();
            newpage.BindingContext = item;
            await Navigation.PushAsync(newpage);
        }
    }
}