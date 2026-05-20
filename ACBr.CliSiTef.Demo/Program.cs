using System;
using System.Windows.Forms;

namespace ACBr.CliSiTef.Demo
{
    internal static class Program
    {
        /// <summary>
        /// CliSiTef e ACBrLib.PosPrinter usam DLLs nativas 32 bits (x86), single-thread (ST cdecl).
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IntPtr.Size != 4)
            {
                MessageBox.Show(
                    "Este aplicativo deve ser executado em processo 32 bits (x86).\r\n\r\n" +
                    "No Visual Studio, use Platform target = x86 e Prefer 32-bit = true.",
                    "ACBr CliSiTef Demo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPdv());
        }
    }
}
