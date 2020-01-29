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
    public partial class MisDietas : ContentPage
    {
        private ResFull _res = new ResFull();
        List<Dieta> dietaList = new List<Dieta>();
        public MisDietas()
        {
            InitializeComponent();
            ContextDietaLista.RefreshCommand = new Command(() =>
            {
                RefrescarDatos();
                ContextDietaLista.IsRefreshing = false;
            });
        }
        protected override void OnAppearing()
        {
            RefrescarDatos();
            base.OnAppearing();
        }

        async public void RefrescarDatos()
        {
            ContextDietaLista.ItemsSource = null;
            dietaList = await _res.Get<List<Dieta>>("app-mis-dietas/" + Settings.IsIdIn);
            ContextDietaLista.ItemsSource = dietaList;
        }
    }
}