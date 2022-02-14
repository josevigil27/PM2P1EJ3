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
    public partial class PageUpdatePersonas : ContentPage
    {
        public PageUpdatePersonas()
        {
            InitializeComponent();
        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id.Text)) {

                Personas persona = new Personas()
                {
                    Id = Convert.ToInt32(id.Text),
                    Nombre = nombre.Text,
                    Apellido = apellido.Text,
                    Edad = Convert.ToInt32(edad.Text),
                    Correo = correo.Text,
                    Direccion = direccion.Text
                };

                var resultado = await App.BaseDatos.GuardarPersona(persona);

                if (resultado != 0)
                {
                    await DisplayAlert("Aviso", "Persona Actualizada con Exito!!!", "Ok");
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
                }

                await Navigation.PopAsync();

            }
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var persona = await App.BaseDatos.ObtenerPersona(Convert.ToInt32(id.Text));

            if (persona != null)
            {
                await App.BaseDatos.BorrarPersonas(persona);
                await DisplayAlert("Aviso", "Persona Eliminada con Exito!!!", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
            }

            await Navigation.PopAsync();
        }
    }
}