using Lib.CliSitef.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACBr.CliSiTef.Demo.Services
{
    public static class ComprovanteBuilder
    {
        /// <summary>Marcador interno substituído na impressão por &lt;/corte_parcial&gt; (ACBr).</summary>
        public const string MarcadorCorteEntreVias = "{{ACBR_CORTE_ENTRE_VIAS}}";

        public static string MontarComprovante(string documentoVinculado, List<TefRetorno> linhas, string terminal)
        {
            if (linhas == null || linhas.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine("     ACBr CliSiTef - Demo");
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "   Cupom: " + documentoVinculado);
            sb.AppendLine("----------------------------------------------");

            foreach (var item in linhas)
            {
                if (item == null)
                    continue;
                string linha = item.Valor?.Replace("\"", "");
                if (!string.IsNullOrWhiteSpace(linha))
                    sb.AppendLine(linha);
            }

            sb.AppendLine("----------------------------------------------");
            sb.AppendLine("Caixa: " + terminal);
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine();
            return sb.ToString();
        }

        public static string MontarDeCupom(Cupom cupom, string terminal)
        {
            if (cupom == null || cupom.Transacoes.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var transacao in cupom.Transacoes)
            {
                var cliente = transacao.Retornos.Where(p => p.Codigo == 713).OrderBy(p => p.Indice).ToList();
                var estab = transacao.Retornos.Where(p => p.Codigo == 715).OrderBy(p => p.Indice).ToList();

                if (cliente.Count > 0)
                {
                    sb.AppendLine("=== VIA CLIENTE ===");
                    sb.Append(MontarComprovante(cupom.DocumentoVinculado, cliente, terminal));
                }
                if (cliente.Count > 0 && estab.Count > 0)
                    sb.AppendLine(MarcadorCorteEntreVias);
                if (estab.Count > 0)
                {
                    sb.AppendLine("=== VIA ESTABELECIMENTO ===");
                    sb.Append(MontarComprovante(cupom.DocumentoVinculado, estab, terminal));
                }
            }
            return sb.ToString();
        }

        /// <summary>Texto bruto para ACBr (contém <see cref="MarcadorCorteEntreVias"/> entre as vias).</summary>
        public static string MontarParaImpressao(Cupom cupom, string terminal)
        {
            return MontarDeCupom(cupom, terminal);
        }

        private static readonly string BlocoCortePreview =
            "----------------------------------------------\r\n" +
            "              [ CORTE PAPEL ]\r\n" +
            "----------------------------------------------\r\n";

        public static string FormatarParaPreview(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            return texto.Replace(MarcadorCorteEntreVias, BlocoCortePreview);
        }

        /// <summary>Reconstrói texto de impressão a partir do preview (após LimparCupom).</summary>
        public static string PreviewParaImpressao(string preview)
        {
            if (string.IsNullOrWhiteSpace(preview))
                return string.Empty;

            return preview.Replace(BlocoCortePreview, MarcadorCorteEntreVias);
        }

        public static string ParaEscPos(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "</zera>";

            // Corte parcial entre 1ª e 2ª via (equivalente ao PartialPaperCut do demo Fiserv).
            string corpo = texto
                .Replace(MarcadorCorteEntreVias, "\n</corte_parcial>\n")
                .Replace("\r\n", "\n")
                .Replace("\n", "</lf>");

            return "</zera></ae>" + corpo + "</lf></corte_total>";
        }
    }
}
