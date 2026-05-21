# ACBr CliSiTef Demo

Exemplo **WinForms** (.NET 4.8, **x86**) para integração **CliSiTef** (Fiserv), pelo Projeto ACBr. Inclui PDV de exemplo, impressão utilizando o **ACBrLib.PosPrinter**.

---

## Início rápido

```bash
git clone https://github.com/antoniocarlosjr97/acbr-clisitef-demo.git
cd acbr-clisitef-demo
```

Crie `ACBr.CliSiTef.Demo\App.config` conforme o [exemplo abaixo](#configuração).

Abra `ACBr.CliSiTef.sln`, restaure os pacotes NuGet (se necessário) e compile em **Debug**. Em seguida:

1. Copie o **SDK CliSiTef Windows** (`CliSiTef32I.dll` + dependências) para `ACBr.CliSiTef.Demo\bin\Debug\`.
2. Copie `ACBrPosPrinter32.dll` para `ACBr.CliSiTef.Demo\bin\Debug\ACBrLib\x86\`.
3. Inicie o **SitDemo**, execute o `.exe` e aguarde **TEF inicializado com sucesso** no log.

---

## Requisitos

- Windows 10+, **.NET Framework 4.8**, Visual Studio 2022 ou Build Tools
- Aplicação configurada para **32 bits**
- SitDemo / SDK CliSiTef Windows
- DLLs nativas (CliSiTef32.dll + dependências e ACBrLibPosPrinter)

---

## DLLs (copiar manualmente)

| Origem | Destino |
|--------|---------|
| SDK CliSiTef Windows  | `bin\Debug\` (mesma pasta do `.exe`) |
| `ACBrPosPrinter32.dll` (Projeto ACBr) | `bin\Debug\ACBrLib\x86\` |

DLL CliSiTef e DLLs dependências: `CliSiTef32I.dll`, `libcurl32.dll`, `libemv.dll`, `QREncode32.dll`, `RechargeRPC.dll`.

NuGet (`ACBrLib.Core`, `ACBrLib.PosPrinter`) gera só assemblies gerenciados — versões no `.csproj`.

---

## Solução

| Projeto | Função |
|---------|--------|
| `ACBr.CliSiTef.Demo` | PDV Exemplo (`FrmPdv`, `FrmConfiguracao`) |
| `Lib.CliSitef` | Motor TEF / P/Invoke |
| `Lib.FormsAuxiliares` | Telas interativas SiTef |
| `Lib.Utils` | QR Code, helpers |

---

## Uso

1. Valor da operação → pagamento (parcial ou total) → **Débito** (2), **Crédito** (3) ou **Carteira digital** (122).
2. Preview do comprovante e grid de pagamentos; **Nova venda** limpa a tela.
3. **Configuração:** TEF (IP, empresa, terminal, pinpad), impressora ESC/POS, envio à impressora.
4. QR na tela: `Tef_PinPadQrCode=0` e transação carteira digital; comandos SiTef **50** / **51**.

**Deploy:** copie a pasta `bin\Debug` ou `Release` inteira (exe, `Lib.*.dll`, DLLs TEF e `ACBrLib\x86\`).

---

## Configuração

Exemplo em `ACBr.CliSiTef.Demo\App.config`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="Tef_Ip" value="127.0.0.1"/>
    <add key="Tef_Empresa" value="00000000"/>
    <add key="Tef_EmpresaCnpj" value="11111111111111"/>
    <add key="Tef_Terminal" value="000001"/>
    <add key="Tef_SoftwareHouseCnpj" value="22222222222222"/>
    <add key="Tef_PinPadVerificar" value="1"/>
    <add key="Tef_PinPadQrCode" value="0"/>
    <add key="Tef_PinPadPorta" value="AUTO_USB"/>
    <add key="Tef_PinPadMensagem" value="ACBr CliSiTef Demo"/>
    <add key="Tef_SenhaCodigoSupervisor" value="1234"/>
    <add key="Tef_TipoComunicacaoExterna" value=""/>
    <add key="Tef_ConfirmacaoAutomatica" value="1"/>
    <add key="PosPrinter_EnviarImpressora" value="0"/>
  </appSettings>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.8"/>
  </startup>
</configuration>
```

| Chave | Uso |
|-------|-----|
| `Tef_Ip`, `Tef_Empresa`, `Tef_Terminal` | Conexão SiTef |
| `Tef_EmpresaCnpj`, `Tef_SoftwareHouseCnpj` | CNPJs |
| `Tef_PinPadQrCode` | `0` = QR na tela; `1` = pinpad |
| `Tef_ConfirmacaoAutomatica` | `1` = confirma pendências ao finalizar |
| `PosPrinter_EnviarImpressora` | `1` imprime; `0` só preview |

Valores de exemplo — ajuste conforme seu SitDemo. Impressora detalhada: `ACBrLib.ini` (tela de configuração). `CliSiTef.ini` é criado na pasta do exe se não existir.

---

## Desenvolvimento

- **x86** — `PlatformTarget=x86`, `Prefer32Bit=true`
- **ACBrLibPosPrinter** — uma instância (`PosPrinterConfigService`); chamadas via `AcbrNativeThread.Executar` na thread da UI
- Serviços principais: `TefDemoService`, `TefInteracaoUi`, `ComprovanteBuilder` (vias 713/715)
- Constantes TEF/SAT: `Lib.CliSitef\ConstantValues\`

---

## Problemas comuns

| Sintoma | O que checar |
|---------|----------------|
| Aviso 32 bits | Build x86, não Any CPU 64 |
| TEF não inicia | SitDemo, IP/empresa/terminal, DLLs no exe |
| Erro impressora | `ACBrLib\x86\ACBrPosPrinter32.dll` |
| Sem impressão | `PosPrinter_EnviarImpressora=1` |
| Sem QR | `Tef_PinPadQrCode=0`, função 122, módulo CardSE |

Logs: pasta `Logs\` e painel no PDV.

---

## Homologação

Para mais detalhes, consulte o tópico no fórum:

**[SiTEF: Como iniciar a Homologação por DLL - CliSiTef](https://www.projetoacbr.com.br/forum/topic/87428-sitef-como-iniciar-a-homologa%C3%A7%C3%A3o-por-dll-clisitef/)**

### Roteiro de homologação

Na [plataforma de cursos do Projeto ACBr](https://www.projetoacbr.com.br/cursos/) há um **curso completo** com todos os passos do roteiro de homologação. Recomendamos assistir a esse conteúdo **antes** de iniciar os testes:

- **[Roteiro Pré Homologação CliSiTef - Windows](https://acbr.nutror.com/curso/2561928d2d0381ba19afa98908a21252ba2603a4)**

---

## Referências

| Recurso | Link |
|---------|------|
| SDK CliSiTef Windows | https://www.projetoacbr.com.br/forum/files/file/524-sdk-clisitef-windows-homologa%C3%A7%C3%A3o/ |
| SitDemo Fiserv | https://www.projetoacbr.com.br/forum/files/file/526-sitdemo-fiserv/ |
| SitDemo Configurado ACBr | https://www.projetoacbr.com.br/forum/files/file/523-sitdemo-configurado-acbr/ |
| Projeto ACBr | https://www.projetoacbr.com.br/ |
| NuGet PosPrinter | https://www.nuget.org/packages/ACBrLib.PosPrinter |


---

## Suporte

Em caso de dúvidas, entre em contato pelos canais abaixo:

- [Fórum do Projeto ACBr — Homologação TEF SiTef](https://www.projetoacbr.com.br/forum/forum/101-homologa%C3%A7%C3%A3o-tef-sitef/)
- [Discord do Projeto ACBr](https://discord.com/channels/798697718800318484/1412153365743407256) — canal `#sitef-homologação`
- [Suporte via tickets](https://suporte.projetoacbr.com.br/)