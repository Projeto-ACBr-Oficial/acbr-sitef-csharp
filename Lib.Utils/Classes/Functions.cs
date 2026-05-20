using System.Drawing;

namespace Lib.Utils.Classes
{
    public class Functions
    {
        public static Bitmap Gerar_QRCode(int width, int height, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            if (width < 120)
                width = 180;
            if (height < 120)
                height = 180;

            var bw = new ZXing.Windows.Compatibility.BarcodeWriter();
            var encOptions = new ZXing.Common.EncodingOptions { Width = width, Height = height, Margin = 0 };
            bw.Options = encOptions;
            bw.Format = ZXing.BarcodeFormat.QR_CODE;
            return new Bitmap(bw.Write(text));
        }
    }
}
