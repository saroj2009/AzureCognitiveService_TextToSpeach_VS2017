using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextToSpeechApp.BusinessLayer
{
    public class AppSettingValues
    {
        IConfiguration _iconfiguration;
        public AppSettingValues(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
    }
}
