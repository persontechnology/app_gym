using app_gym.Helpers;
using app_gym.modelos;
using app_gym.vistaModelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Device = Xamarin.Forms.Device;

namespace app_gym.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacebookProfilePage : ContentPage
    {
        private ResFull _res = new ResFull();

        private string ClientId = "132250634542928";

        [Obsolete]
        public FacebookProfilePage()
        {
            InitializeComponent();

            var apiRequest =
                "https://www.facebook.com/dialog/oauth?client_id="
                + ClientId
                + "&display=popup&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html";

            var webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;
            
            Content = webView;
            

        }

        [Obsolete]
        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {

            var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (accessToken != "")
            {
                var vm = BindingContext as FacebookViewModel;
                await vm.SetFacebookUserProfileAsync(accessToken);
                Content = MainStackLayout;

                var usuario = await _res.Get<Usuario>("login-app-facebook/"+Settings.IsEmailIn+"/"+Settings.IsUserdIn);
                if (usuario.email != null)
                {
                    Settings.IsEmailIn = usuario.email;
                    Settings.IsPerfilIn = usuario.perfil;
                    Settings.IsUserdIn = usuario.name;
                    Settings.IsIdIn = usuario.id;
                    Settings.IsLoggedIn = true;
                    Application.Current.MainPage = new NavigationPage(new Inicio());
                    await Navigation.PushAsync(new Inicio());
                    await DisplayAlert("MENSAJE", "Bienvenido "+Settings.IsEmailIn, "OK");
                }
                else
                {
                    Settings.IsEmailIn = "";
                    Settings.IsPerfilIn = "";
                    Settings.IsUserdIn = "";
                    Settings.IsIdIn = 0;
                    Settings.IsLoggedIn = false;
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                    await Navigation.PushAsync(new Login());

                    await DisplayAlert("MENSAJE", "No se puede autenticar con facebook", "OK");
                }


            }
        }

      

        [Obsolete]
        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                {
                    at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in="));

                return accessToken;
            }

            return string.Empty;
        }
    }
}