namespace ACBr.CliSiTef.Demo.Models
{
    /// <summary>
    /// Dados extraídos de <see cref="Lib.CliSitef.Classes.TefTransacao"/> para o grid (layout NTK).
    /// </summary>
    public class DadosTransacaoGrid
    {
        public string Nsu { get; set; } = "";
        public string Host { get; set; } = "";
        public string Autorizacao { get; set; } = "";
        public string Rede { get; set; } = "";
        public string CodigoRede { get; set; } = "";
        public string Bandeira { get; set; } = "";
        public string Modalidade { get; set; } = "";
        public string SubModalidade { get; set; } = "";
        public string TipoTransacao { get; set; } = "";
        public string Cartao { get; set; } = "";
        public string Bin { get; set; } = "";
        public string Titular { get; set; } = "";
        public string DataTransacao { get; set; } = "";
        public string HoraTransacao { get; set; } = "";
        public string IdTransacao { get; set; } = "";
        public string Cnpj { get; set; } = "";
        public string Credenciadora { get; set; } = "";

        public PagamentoGridItem ParaGridItem(int item, string formaPagamento, decimal valor, string status)
        {
            return new PagamentoGridItem
            {
                Item = item,
                FormaPagamento = formaPagamento,
                Valor = valor,
                Status = status,
                Nsu = Nsu,
                Host = Host,
                Autorizacao = Autorizacao,
                Rede = Rede,
                CodigoRede = CodigoRede,
                Bandeira = Bandeira,
                Modalidade = Modalidade,
                SubModalidade = SubModalidade,
                TipoTransacao = TipoTransacao,
                Cartao = Cartao,
                Bin = Bin,
                Titular = Titular,
                DataTransacao = DataTransacao,
                HoraTransacao = HoraTransacao,
                IdTransacao = IdTransacao,
                Cnpj = Cnpj,
                Credenciadora = Credenciadora
            };
        }
    }
}
