namespace ACBr.CliSiTef.Demo.Models
{
    /// <summary>
    /// Linha do grid de pagamentos (campos alinhados ao layout NTK / arquivo .tef).
    /// </summary>
    public class PagamentoGridItem
    {
        public int Item { get; set; }
        public string FormaPagamento { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }

        /// <summary>013-000 — NSU SiTef.</summary>
        public string Nsu { get; set; }

        /// <summary>012-000 — NSU do host autorizador.</summary>
        public string Host { get; set; }

        /// <summary>013-001 — Código de autorização.</summary>
        public string Autorizacao { get; set; }

        /// <summary>010-001 — Nome da rede/adquirente.</summary>
        public string Rede { get; set; }

        /// <summary>010-000 — Código da rede.</summary>
        public string CodigoRede { get; set; }

        /// <summary>748-000 / 748-002 — Bandeira.</summary>
        public string Bandeira { get; set; }

        /// <summary>731-001 — Modalidade (grupo).</summary>
        public string Modalidade { get; set; }

        /// <summary>732-001 — Submodalidade.</summary>
        public string SubModalidade { get; set; }

        /// <summary>011-000 — Tipo da transação.</summary>
        public string TipoTransacao { get; set; }

        /// <summary>740-000 — Cartão mascarado.</summary>
        public string Cartao { get; set; }

        /// <summary>740-001 — BIN.</summary>
        public string Bin { get; set; }

        /// <summary>741-000 — Titular.</summary>
        public string Titular { get; set; }

        /// <summary>022-000 — Data (dd/MM/yyyy).</summary>
        public string DataTransacao { get; set; }

        /// <summary>023-000 — Hora (HH:mm:ss).</summary>
        public string HoraTransacao { get; set; }

        /// <summary>002-001 — Identificador único da transação.</summary>
        public string IdTransacao { get; set; }

        /// <summary>603-001 — CNPJ da credenciadora (quando disponível).</summary>
        public string Cnpj { get; set; }

        /// <summary>603-001 — Nome/código da credenciadora (SAT/NFCe).</summary>
        public string Credenciadora { get; set; }
    }
}
