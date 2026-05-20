using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ACBr.CliSiTef.Demo.Helpers
{
    internal static class AppIconHelper
    {
        private const string NomeArquivoIcone = "logo_topo.ico";
        private static Icon _icone;

        public static Icon ObterIcone()
        {
            if (_icone != null)
                return _icone;

            string path = Path.Combine(Application.StartupPath, "ico", NomeArquivoIcone);
            if (!File.Exists(path))
                return null;

            _icone = new Icon(path);
            return _icone;
        }

        public static void AplicarIcone(Form form)
        {
            var icon = ObterIcone();
            if (icon != null)
                form.Icon = (Icon)icon.Clone();
        }
    }
}
