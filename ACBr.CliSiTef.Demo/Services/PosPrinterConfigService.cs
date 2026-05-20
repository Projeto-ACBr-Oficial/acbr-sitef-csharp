using ACBr.CliSiTef.Demo.Helpers;
using ACBrLib.Core;
using ACBrLib.Core.PosPrinter;
using ACBrLib.PosPrinter;
using System;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ACBr.CliSiTef.Demo.Services
{
    /// <summary>
    /// Instância única da ACBrLib.PosPrinter (Windows/x86, ST cdecl).
    /// Uma instância por processo; chamadas sempre na thread STA da UI.
    /// </summary>
    public sealed class PosPrinterConfigService : IDisposable
    {
        private static PosPrinterConfigService _instancia;
        private static readonly object SyncCriacao = new object();

        private readonly ACBrPosPrinter _printer;
        private bool _disposed;

        public static PosPrinterConfigService ObterInstancia()
        {
            return AcbrNativeThread.Executar(ObterInstanciaInterno);
        }

        private static PosPrinterConfigService ObterInstanciaInterno()
        {
            lock (SyncCriacao)
            {
                if (_instancia == null || _instancia._disposed)
                    _instancia = new PosPrinterConfigService();
                return _instancia;
            }
        }

        private PosPrinterConfigService()
        {
            _printer = new ACBrPosPrinter();
            string logDir = Path.Combine(Application.StartupPath, "Logs");
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            string arqLogPadrao = Path.Combine(logDir, "PosPrinter.log");

            try
            {
                _printer.ConfigLer();
                _printer.ConfigGravarValor(ACBrSessao.Principal, "LogNivel", 4);
                _printer.ConfigGravarValor(ACBrSessao.Principal, "LogPath", logDir);

                if (string.IsNullOrWhiteSpace(_printer.Config.ArqLog) ||
                    Directory.Exists(_printer.Config.ArqLog.TrimEnd('\\', '/')))
                {
                    _printer.Config.ArqLog = arqLogPadrao;
                }

                _printer.ConfigGravar();
                _printer.ConfigLer();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    "Não foi possível inicializar ACBrLib.PosPrinter (x86 / single-thread). " +
                    "Confira se ACBrLib.PosPrinter.dll e dependências estão na pasta do executável.",
                    ex);
            }
        }

        public ACBrPosPrinter Instancia => _printer;

        public void Carregar()
        {
            AcbrNativeThread.Executar(() => _printer.ConfigLer());
        }

        public void Gravar()
        {
            AcbrNativeThread.Executar(() =>
            {
                NormalizarArqLog(_printer.Config);
                try
                {
                    _printer.ConfigGravar();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(
                        "Erro ao gravar configurações da impressora (ACBrLib.ini): " + ex.Message, ex);
                }
            });
        }

        public static string NormalizarCaminhoArqLog(string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho))
                return Path.Combine(Application.StartupPath, "Logs", "PosPrinter.log");

            caminho = caminho.Trim();
            if (Directory.Exists(caminho))
                return Path.Combine(caminho, "PosPrinter.log");

            if (!Path.HasExtension(caminho))
                return Path.Combine(caminho, "PosPrinter.log");

            return caminho;
        }

        private static void NormalizarArqLog(PosPrinterConfig cfg)
        {
            cfg.ArqLog = NormalizarCaminhoArqLog(cfg.ArqLog);
            string dir = Path.GetDirectoryName(cfg.ArqLog);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        public string[] ListarPortas()
        {
            return AcbrNativeThread.Executar(ListarPortasInterno);
        }

        private string[] ListarPortasInterno()
        {
            var lista = new System.Collections.Generic.List<string>();
            try
            {
                lista.AddRange(_printer.AcharPortas());
            }
            catch { }

            lista.Add("LPT1");
            lista.Add("LPT2");
            lista.Add(Path.Combine(Application.StartupPath, "comprovante_simulado.txt"));

            foreach (string printer in PrinterSettings.InstalledPrinters)
                lista.Add("RAW:" + printer);

            return lista.Distinct().ToArray();
        }

        public void GarantirAtiva()
        {
            AcbrNativeThread.Executar(() =>
            {
                try
                {
                    _printer.Ativar();
                }
                catch
                {
                    // Ativação pode falhar em modo simulado.
                }
            });
        }

        public void Desativar()
        {
            AcbrNativeThread.Executar(() =>
            {
                try
                {
                    _printer.Desativar();
                }
                catch { }
            });
        }

        public void Imprimir(string texto)
        {
            AcbrNativeThread.Executar(() => _printer.Imprimir(texto));
        }

        public void Dispose()
        {
            AcbrNativeThread.Executar(DisposeInterno);
        }

        private void DisposeInterno()
        {
            if (_disposed)
                return;

            try
            {
                _printer.Desativar();
            }
            catch { }

            _printer?.Dispose();
            _disposed = true;

            lock (SyncCriacao)
            {
                if (ReferenceEquals(_instancia, this))
                    _instancia = null;
            }
        }
    }
}
