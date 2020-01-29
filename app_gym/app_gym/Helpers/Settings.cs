using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
namespace app_gym.Helpers
{
    class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        //login
        private const string IsLoggedInTokenKey = "isloggedid_key";
        private static readonly bool IsLoggedInTokenDefault = false;

        //id
        private const string IsIdInTokenKey = "isid_key";
        private static readonly int IsIdInTokenDefault = 0;


        //email
        private const string IsEmailInTokenKey = "isemail_key";
        private static readonly string IsEmalInTokenDefault = string.Empty;

        //nombre y apellido --User
        private const string IsUserInTokenKey = "isuser_key";
        private static readonly string IsUserInTokenDefault = string.Empty;

        //perfil
        private const string IsPerfilInTokenKey = "isperfil_key";
        private static readonly string IsPerfilInTokenDefault = string.Empty;

        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        //está logeado
        public static bool IsLoggedIn
        {
            get { return AppSettings.GetValueOrDefault(IsLoggedInTokenKey, IsLoggedInTokenDefault); }
            set { AppSettings.AddOrUpdateValue(IsLoggedInTokenKey, value); }
        }

        //id
        public static int IsIdIn
        {
            get { return AppSettings.GetValueOrDefault(IsIdInTokenKey, IsIdInTokenDefault); }
            set { AppSettings.AddOrUpdateValue(IsIdInTokenKey, value); }
        }

        //email
        public static string IsEmailIn
        {
            get { return AppSettings.GetValueOrDefault(IsEmailInTokenKey, IsEmalInTokenDefault); }
            set { AppSettings.AddOrUpdateValue(IsEmailInTokenKey, value); }
        }

        //emial apelido- User
        public static string IsUserdIn
        {
            get { return AppSettings.GetValueOrDefault(IsUserInTokenKey, IsUserInTokenDefault); }
            set { AppSettings.AddOrUpdateValue(IsUserInTokenKey, value); }
        }

        public static string IsPerfilIn
        {
            get { return AppSettings.GetValueOrDefault(IsPerfilInTokenKey, IsPerfilInTokenDefault); }
            set { AppSettings.AddOrUpdateValue(IsPerfilInTokenKey, value); }
        }
    }

}
