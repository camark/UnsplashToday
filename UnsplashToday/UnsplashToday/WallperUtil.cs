using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace UnsplashToday
{
    class WallperUtil
    {
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(
        int uAction,
        int uParam,
        string lpvParam,
        int fuWinIni
        );

        public void setWallper(string wallper_filename)
        {
            SystemParametersInfo(20, 1, wallper_filename, 1);
        }
    }
}
