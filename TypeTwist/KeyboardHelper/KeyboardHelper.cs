using System;
using System.Runtime.InteropServices;

namespace TypeTwist.Helpers
{
    public static class KeyboardHelper
    {
        // WinAPI fonksiyonları
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool LoadKeyboardLayout(string pwszKLID, uint Flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr ActivateKeyboardLayout(IntPtr hkl, uint Flags);

        private const uint KLF_ACTIVATE = 0x00000001;

        public static void SwitchKeyboardLayout(string layout)
        {
            // Layout kodu (örneğin, "00000409" İngilizce ABD)
            string layoutCode = layout switch
            {
                "EN" => "00000409", // İngilizce ABD
                "FR" => "0000040C", // Fransızca
                // Diğer diller ekleyin
                _ => "00000409"
            };

            LoadKeyboardLayout(layoutCode, 0);
            ActivateKeyboardLayout(IntPtr.Zero, KLF_ACTIVATE);
        }
    }
}
