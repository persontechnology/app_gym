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
    public partial class MisMensualidades : ContentPage
    {
        private ResFull _res = new ResFull();
        List<Mensualidad> mensualidadList = new List<Mensualidad>();
        public MisMensualidades()
        {
            InitializeComponent();
            ContextMensualidadLista.RefreshCommand = new Command(() =>
            {
                RefrescarDatos();
                ContextMensualidadLista.IsRefreshing = false;
            });
        }

        protected override void OnAppearing()
        {
            RefrescarDatos();
            base.OnAppearing();
        }

        async public void RefrescarDatos()
        {
            ContextMensualidadLista.ItemsSource = null;
            mensualidadList = await _res.Get<List<Mensualidad>>("app-mis-pagos/" + Settings.IsIdIn);
            ContextMensualidadLista.ItemsSource = mensualidadList;
        }
    }
}