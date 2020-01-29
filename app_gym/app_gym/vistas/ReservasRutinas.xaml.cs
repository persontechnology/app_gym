using app_gym.Helpers;
using app_gym.modelos;
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
    public partial class ReservasRutinas : ContentPage
    {
        private ResFull _res = new ResFull();
        List<Rutina> rutinaList = new List<Rutina>();
        public ReservasRutinas()
        {
            InitializeComponent();
            ContextRutinaLista.RefreshCommand = new Command(() =>
            {
                RefrescarDatos();
                ContextRutinaLista.IsRefreshing = false;
            });
        }

        protected override void OnAppearing()
        {
            RefrescarDatos();
            base.OnAppearing();
        }

        async public void RefrescarDatos()
        {
            ContextRutinaLista.ItemsSource = null;
            rutinaList = await _res.Get<List<Rutina>>("app-mis-rutinas-disponibles/" + Settings.IsIdIn);
            ContextRutinaLista.ItemsSource = rutinaList;
        }

        async private void ReservarRutina(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var rutina = await _res.Get<Rutina>("app-mis-rutinas-reservar/" + mi.CommandParameter + "/" + Settings.IsIdIn);
            if (rutina.nombre != null)
            {
                rutinaList.Remove(rutina);
                RefrescarDatos();
                await DisplayAlert("Reservado", "Rutina reservado exitosamente", "OK");
            }
            else
            {
                await DisplayAlert("Eliminado", "No se puede reservar rutina, vuelva intentar", "OK");
            }

        }
    }
}