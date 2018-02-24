using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SpotlightDesktop
{
    public class RegistryHelpers
    {
        public static RegistryKey GetRegistryKey(RegistryHive registryHive, string keyPath)
        {
            RegistryKey localMachineRegistry
                = RegistryKey.OpenBaseKey(registryHive,
                                          Environment.Is64BitOperatingSystem
                                              ? RegistryView.Registry64
                                              : RegistryView.Registry32);

            return string.IsNullOrEmpty(keyPath)
                ? localMachineRegistry
                : localMachineRegistry.OpenSubKey(keyPath);
        }
    }
}
