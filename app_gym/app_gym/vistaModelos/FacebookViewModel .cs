﻿using app_gym.Helpers;
using app_gym.modelos;
using app_gym.servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace app_gym.vistaModelos
{
    public class FacebookViewModel : INotifyPropertyChanged
    {
        private FacebookProfile _facebookProfile;

        public FacebookProfile FacebookProfile
        {
            get { return _facebookProfile; }
            set
            {
                _facebookProfile = value;
                OnPropertyChanged();
            }
        }

        public async Task SetFacebookUserProfileAsync(string accessToken)
        {
            var facebookServices = new FacebookServices();

            var face=FacebookProfile = await facebookServices.GetFacebookProfileAsync(accessToken);
            Settings.IsEmailIn = face.email;
            Settings.IsUserdIn = face.FirstName + " " + face.LastName;


        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
