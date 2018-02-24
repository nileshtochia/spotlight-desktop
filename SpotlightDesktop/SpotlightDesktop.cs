using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace SpotlightDesktop
{
    public class SpotlightDesktop
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, String pvParam, UInt32 fWinIni);
        private static UInt32 SPI_SETDESKWALLPAPER = 20;
        private static UInt32 SPIF_UPDATEINIFILE = 0x1;

        public string GetCurrentSpotlightWallpaperPath()
        {
            var userCreativeAssetsKey = RegistryHelpers.GetRegistryKey(
                RegistryHive.LocalMachine, 
                string.Format(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Creative\{0}", 
                WindowsIdentity.GetCurrent().User.ToString()));
            var creativeAssetKey = userCreativeAssetsKey.OpenSubKey(userCreativeAssetsKey.GetSubKeyNames().Max(c => long.Parse(c)).ToString());

            if (creativeAssetKey != null)
            {
                return creativeAssetKey.GetValue("landscapeImage").ToString();
            }
            return null;
        }

        public void SetWallaper(string path)
        {
            if (path != null)
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE);
        }
    }
}
