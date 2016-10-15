using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotlightDesktop;

namespace SpotlightDesktop
{
    class Program
    {
        static void Main(string[] args)
        {
            var spotlightDesktop = new SpotlightDesktop();
            var spotlightImagePath = spotlightDesktop.GetCurrentSpotlightWallpaperPath();
            spotlightDesktop.SetWallaper(spotlightImagePath);
        }
    }
}
