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
    public partial class PageCrearPersonas : ContentPage
    {
        public PageCrearPersonas()
        {
            InitializeComponent();
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            var persona = new Personas
            {
                Nombre = nombre.Text,
                Apellido = apellido.Text,
                Edad = Convert.ToInt32(edad.Text),
                Correo = correo.Text,
                Direccion = direccion.Text
            };

            var resultado = await App.BaseDatos.GuardarPersona(persona);

            if (resultado != 0) {
                await DisplayAlert("Aviso", "Persona Ingresada con Exito!!!", "Ok");
            } else {
                await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
            }

            await Navigation.PopAsync();
        }
    }
}