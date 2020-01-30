using app_gym.Helpers;
using app_gym.vistaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_gym.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
        }
        async private void MisAsistencias(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MisAsistencias());
        }

        async private void MisDietas(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MisDietas());
        }

        async private void MisMensualidades(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MisMensualidades());
        }
        async private void MisRutinas(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MisRutinas());
        }
        async private void Catalogos(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Catalogos());
        }

        async private void ReservasRutinas(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ReservasRutinas());
        }

        async private void Salir(object sender, EventArgs e)
        {
            Settings.IsEmailIn = "";
            Settings.IsPerfilIn = "";
            Settings.IsUserdIn = "";
            Settings.IsIdIn = 0;
            Settings.IsLoggedIn = false;
            Application.Current.MainPage = new NavigationPage(new MainPage());
            await Navigation.PushAsync(new Login());

        }

         async private void Reportes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Reportes());
        }
    }
}