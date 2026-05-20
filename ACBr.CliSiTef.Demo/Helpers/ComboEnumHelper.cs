using System;
using System.Windows.Forms;

namespace ACBr.CliSiTef.Demo.Helpers
{
    internal static class ComboEnumHelper
    {
        public static void PopularEnum<TEnum>(ComboBox combo, TEnum valorSelecionado) where TEnum : struct
        {
            combo.Items.Clear();
            foreach (TEnum item in Enum.GetValues(typeof(TEnum)))
                combo.Items.Add(item);

            if (combo.Items.Count > 0)
            {
                combo.SelectedItem = valorSelecionado;
                if (combo.SelectedIndex < 0)
                    combo.SelectedIndex = 0;
            }
        }

        public static TEnum ObterSelecionado<TEnum>(ComboBox combo, TEnum padrao) where TEnum : struct
        {
            if (combo.SelectedItem is TEnum valor)
                return valor;
            return padrao;
        }
    }
}
