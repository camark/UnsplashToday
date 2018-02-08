using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnsplashToday
{
    class DirUtil
    {
        public static string getBasePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
