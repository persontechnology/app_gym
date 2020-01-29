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
    public partial class MisRutinas : ContentPage
    {
        private ResFull _res = new ResFull();
        List<Rutina> rutinaList = new List<Rutina>();
        public MisRutinas()
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
            rutinaList = await _res.Get<List<Rutina>>("app-mis-rutinas/" + Settings.IsIdIn);
            ContextRutinaLista.ItemsSource = rutinaList;
        }
    }
}