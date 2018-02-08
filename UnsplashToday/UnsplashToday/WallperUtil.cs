using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace UnsplashToday
{
    class WallperUtil
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(
            int uAction,
            int uParam,
            string lpvParam,
            int fuWinIni
        );

        public void setWallper(string wallper_filename)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                wallper_filename,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}
