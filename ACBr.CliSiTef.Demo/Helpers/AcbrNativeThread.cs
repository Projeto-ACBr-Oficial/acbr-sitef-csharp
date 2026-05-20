using System;
using System.Threading;
using System.Windows.Forms;

namespace ACBr.CliSiTef.Demo.Helpers
{
    /// <summary>
    /// ACBrLib.PosPrinter / CliSiTef: binários nativos Windows x86, convenção ST cdecl (single-thread).
    /// Não é seguro chamar a DLL de threads em background — use sempre a thread STA da UI.
    /// </summary>
    internal static class AcbrNativeThread
    {
        private static Control _controleUi;

        public static void RegistrarControleUi(Control controle)
        {
            _controleUi = controle;
        }

        public static void Executar(Action acao)
        {
            if (acao == null)
                return;

            if (_controleUi != null && _controleUi.IsHandleCreated)
            {
                if (_controleUi.InvokeRequired)
                    _controleUi.Invoke(acao);
                else
                    acao();
                return;
            }

            if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
            {
                throw new InvalidOperationException(
                    "ACBrLib (x86, single-thread) deve ser usada na thread STA da interface. " +
                    "Registre o formulário principal com AcbrNativeThread.RegistrarControleUi.");
            }

            acao();
        }

        public static T Executar<T>(Func<T> funcao)
        {
            if (funcao == null)
                return default(T);

            T resultado = default(T);
            // Action explícito: "() => resultado = funcao()" seria Func<T> e causaria StackOverflow.
            Executar(new Action(() => { resultado = funcao(); }));
            return resultado;
        }
    }
}
