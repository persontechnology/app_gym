using app_gym.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace app_gym.modelos
{
   public class Reporte
    {
       public string url { get; set; } = ResFull.urlbase + "app-reportes/"+Settings.IsIdIn;
    }
}
