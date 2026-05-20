# ACBr CliSiTef Demo

Demonstração **PDV WinForms** para integração e homologação da biblioteca **CliSiTef** (Fiserv / Software Express), mantida pelo **Projeto ACBr**.

O projeto evolui o demo de referência da Software Express (`App.CliSiTef_DLL`), com interface de caixa unificada, impressão de comprovantes via **ACBrLib.PosPrinter** (NuGet) e fluxo de QR Code Pix na tela do PDV.

> **Atenção:** este repositório é uma **aplicação de demonstração**. Não substitui um PDV fiscal completo nem dispensa a homologação oficial junto à Software Express/Fiserv.

---

## Índice

1. [Visão geral](#visão-geral)
2. [Requisitos](#requisitos)
3. [Estrutura do repositório](#estrutura-do-repositório)
4. [Configuração do ambiente](#configuração-do-ambiente)
5. [Compilar e executar](#compilar-e-executar)
6. [Distribuição / deploy](#distribuição--deploy)
7. [Utilizando o demo](#utilizando-o-demo)
8. [Configurações](#configurações)
9. [Arquitetura do código](#arquitetura-do-código)
10. [Impressão de comprovantes](#impressão-de-comprovantes)
11. [QR Code (Pix / carteira digital)](#qr-code-pix--carteira-digital)
12. [Arquivos gerados em runtime](#arquivos-gerados-em-runtime)
13. [Homologação TEF (SiTef Demo)](#homologação-tef-sitef-demo)
14. [Solução de problemas](#solução-de-problemas)
15. [Referências](#referências)

---

## Visão geral

| Item | Detalhe |
|------|---------|
| **Plataforma** | Windows, .NET Framework **4.8** |
| **Arquitetura do processo** | **x86 (32 bits)** — obrigatório para CliSiTef e ACBrLib |
| **UI** | WinForms (`FrmPdv` + `FrmConfiguracao`) |
| **TEF** | `Lib.CliSitef` → P/Invoke em `CliSiTef32I.dll` |
| **Impressão** | Pacotes NuGet `ACBrLib.Core` + `ACBrLib.PosPrinter` + DLL nativa `ACBrPosPrinter32.dll` |
| **Formulários TEF** | `Lib.FormsAuxiliares` (menu, coleta, aguarde, etc.) |

### Funcionalidades do PDV

- Aba **Venda**: documento, valor da operação, pagamentos parciais (débito, crédito, carteira digital).
- Grid de pagamentos com status até **Nova venda**.
- **Comprovante (preview)** e **Log de execução** em tempo real.
- **QR Code** centralizado sobre o grid (comandos SiTef 50/51, campo 584).
- Aba **Administrativo** (menu SiTef).
- **Configuração** de TEF, pinpad e impressora ESC/POS.

---

## Requisitos

### Software

- **Windows** 10 ou superior (64 bits; o **processo** do demo é 32 bits).
- **.NET Framework 4.8** ([download Microsoft](https://dotnet.microsoft.com/download/dotnet-framework/net48)).
- **Visual Studio 2022** (ou Build Tools) com carga de trabalho **Desenvolvimento para desktop com .NET**.
- **Gerenciador TEF SiTef** instalado e configurado (ambiente de homologação/simulado).

### Artefatos que você precisa obter separadamente

| Origem | O que copiar | Destino no projeto |
|--------|----------------|-------------------|
| Kit **CliSiTef simulado** (Software Express) | `CliSiTef32I.dll` e dependências | Pasta do **executável** (`bin\Debug\` ou `bin\Release\`) |
| Distribuição **ACBrLib PosPrinter** (Projeto ACBr) | `ACBrPosPrinter32.dll` (e dependências, se houver) | `ACBrLib\x86\` junto ao executável (ver [Distribuição](#distribuição--deploy)) |

Links do ambiente simulado estão na seção [Referências](#referências).

---

## Estrutura do repositório

```
CliSiTef/
└── src/
    ├── .gitignore
    ├── README.md
    ├── ACBr.CliSiTef.sln
    ├── ACBr.CliSiTef.Demo/           # Aplicação PDV (WinExe, x86)
    │   ├── FrmPdv.cs                 # Tela principal
    │   ├── FrmConfiguracao.cs        # TEF + impressora
    │   ├── Services/                 # Orquestração TEF e impressão
    │   └── Helpers/                  # Thread UI para DLLs nativas
    ├── Lib.CliSitef/                 # Motor TEF (transações, retornos)
    ├── Lib.FormsAuxiliares/          # Formulários interativos SiTef
    └── Lib.Utils/                    # Log, QR Code, utilitários

### Dependências gerenciadas (NuGet)

| Pacote | Projeto | Uso |
|--------|---------|-----|
| `ACBrLib.Core`, `ACBrLib.PosPrinter` | ACBr.CliSiTef.Demo | Impressão ESC/POS |
| `ZXing.Net.Bindings.Windows.Compatibility` | Lib.Utils | QR Code na tela |
| `System.Drawing.Common` | Lib.Utils | Bitmap do QR |

Valores monetários nos formulários usam `NumericUpDown` (BCL). Não há pasta `ExternalLibraries` no repositório.

### Projetos da solution

| Projeto | Descrição |
|---------|-----------|
| **ACBr.CliSiTef.Demo** | PDV + configuração. `PlatformTarget=x86`, `Prefer32Bit=true`. |
| **Lib.CliSitef** | Classes `TefSoftwareExpress`, cupom, retornos, P/Invoke. |
| **Lib.FormsAuxiliares** | UI auxiliar acionada pelos eventos do TEF. |
| **Lib.Utils** | `Functions.Gerar_QRCode`, enums, helpers. |

---

## Configuração do ambiente

### 1. Clonar o repositório

```powershell
git clone <url-do-repositorio> CliSiTef
cd CliSiTef\src
```

### 2. DLLs do CliSiTef (TEF)

1. Baixe o pacote simulado (`clisitefwin32_simulado.zip`) — link na seção [Referências](#referências).
2. Compile o projeto uma vez (para gerar a pasta de saída).
3. Copie **todas** as DLLs do kit **diretamente na pasta do executável**:

   ```
   src\ACBr.CliSiTef.Demo\bin\Debug\
   ```

   (ou `bin\Release\` em produção de release)

   Mínimo esperado na mesma pasta do `.exe`:

   - `CliSiTef32I.dll`
   - `libcurl32.dll`
   - `libemv.dll`
   - `QREncode32.dll`
   - `RechargeRPC.dll`  
   (e demais dependências que vierem no pacote Software Express)

   > O build **não** copia DLLs do TEF automaticamente. Cada desenvolvedor coloca as DLLs ao lado do `.exe`.

### 3. DLL nativa da ACBrLib PosPrinter (obrigatório)

Os pacotes NuGet **não substituem** a biblioteca nativa. Eles trazem apenas os assemblies gerenciados (`ACBrLib.Core.dll`, `ACBrLib.PosPrinter.dll`).

Obtenha a DLL nativa no pacote oficial do **ACBrLib PosPrinter** (versão compatível com o NuGet do projeto) e copie **manualmente** para a pasta de saída do build:

```
src\ACBr.CliSiTef.Demo\bin\Debug\ACBrLib\x86\ACBrPosPrinter32.dll
```

(Em Release, use `bin\Release\` no lugar de `bin\Debug\`.)

> Os pacotes NuGet trazem apenas os assemblies gerenciados. A DLL nativa **não** vem no repositório nem é copiada pelo build. **Quem distribuir o demo** deve incluir `ACBrLib\x86\ACBrPosPrinter32.dll` no pacote de instalação.

### 4. Restaurar pacotes NuGet

No Visual Studio: clique com o botão direito na solution → **Restaurar pacotes NuGet**.

Ou via linha de comando:

```powershell
msbuild ACBr.CliSiTef.sln /t:Restore
```

Pacotes atuais do demo:

| Pacote | Versão |
|--------|--------|
| ACBrLib.Core | 1.2.47 |
| ACBrLib.PosPrinter | 1.0.11 |

---

## Compilar e executar

1. Abra `src\ACBr.CliSiTef.sln` no Visual Studio.
2. Selecione **Debug | Any CPU** (o projeto do demo força saída **x86**).
3. Compile a solution (**Ctrl+Shift+B**).
4. Confirme que existem:
   - DLLs CliSiTef na pasta `bin\Debug\`
   - `ACBrLib\x86\ACBrPosPrinter32.dll` na pasta `bin\Debug\`
5. Execute:

   ```
   src\ACBr.CliSiTef.Demo\bin\Debug\ACBr.CliSiTef.Demo.exe
   ```

Na inicialização, o demo valida se o processo é **32 bits**. Se `IntPtr.Size != 4`, exibe aviso e encerra — configure **Platform target = x86** e **Prefer 32-bit = true** (já definido no `.csproj`).

---

## Distribuição / deploy

Ao publicar para outra máquina, copie **toda** a pasta de saída (`bin\Debug` ou `bin\Release`), incluindo:

```
ACBr.CliSiTef.Demo.exe
ACBr.CliSiTef.Demo.exe.config
Lib.CliSitef.dll
Lib.FormsAuxiliares.dll
Lib.Utils.dll
CliSiTef32I.dll                    (+ demais DLLs do kit TEF)
ACBrLib.Core.dll                   (NuGet — gerenciado)
ACBrLib.PosPrinter.dll             (NuGet — gerenciado)
ACBrLib\x86\ACBrPosPrinter32.dll   (NATIVA — copiar manualmente)
```

Estrutura mínima recomendada:

```
App\
├── ACBr.CliSiTef.Demo.exe
├── ACBr.CliSiTef.Demo.exe.config
├── CliSiTef32I.dll
├── ACBrLib.Core.dll
├── ACBrLib.PosPrinter.dll
├── ACBrLib\
│   └── x86\
│       └── ACBrPosPrinter32.dll
├── Lib.*.dll
└── (outras dependências do kit TEF)
```

Na primeira execução são criados/atualizados, se necessário:

- `CliSiTef.ini` — pinpad e parâmetros SiTef
- `ACBrLib.ini` — configuração da impressora (gravada pela tela de configuração)
- pastas `Logs\`, `TefRetorno\`, `imp\`

---

## Utilizando o demo

### Fluxo de venda

1. Aguarde a mensagem **TEF inicializado com sucesso** no log (inicialização em background).
2. Informe o **valor da operação** e, se quiser, clique em **Gerar documento** (número do cupom vinculado ao SiTef).
3. Informe o **valor do pagamento** (pode ser parcial).
4. Escolha a forma:
   - **Débito** — função SiTef `2`
   - **Crédito** — função SiTef `3`
   - **Carteira digital** — função SiTef `122` (Pix e outras carteiras, conforme módulos instalados no SiTef)
5. Siga as telas interativas do TEF (senha, parcelas, confirmação, etc.).
6. O comprovante aparece no painel **Comprovante (preview)**; o grid registra cada pagamento.
7. Quando o total pago atingir o valor da operação, a venda é finalizada no TEF; o grid permanece até **Nova venda**.
8. Use **Imprimir** para enviar o comprovante à impressora (se habilitado na configuração).

### Aba Administrativo

Permite executar o **menu administrativo** do SiTef (reimpressão, pendências, testes, etc., conforme habilitado no servidor).

### Configuração

Botão **Configuração** na barra superior:

- **TEF:** IP do SiTef, empresa, terminal, CNPJs, pinpad, QR no pinpad, senha supervisor.
- **Impressora:** modelo ESC/POS, porta, colunas, buffer, tags, log, ativar/desativar, teste de impressão.
- Opção **Enviar comprovante para impressora** — quando desmarcada, apenas preview na tela.

---

## Configurações

### `App.config` (preferências do demo)

Chaves principais em `ACBr.CliSiTef.Demo\App.config`:

| Chave | Descrição | Exemplo |
|-------|-----------|---------|
| `Tef_Ip` | Endereço do SiTef | `127.0.0.1` |
| `Tef_Empresa` | Código da loja | `00000000` |
| `Tef_Terminal` | ID do terminal | `000001` |
| `Tef_EmpresaCnpj` | CNPJ estabelecimento | |
| `Tef_SoftwareHouseCnpj` | CNPJ software house | |
| `Tef_PinPadVerificar` | Verificar pinpad na inicialização | `1` |
| `Tef_PinPadQrCode` | `0` = QR na tela; `1` = QR no pinpad | `0` |
| `Tef_PinPadPorta` | Porta do pinpad | `AUTO_USB` |
| `Tef_PinPadMensagem` | Mensagem no display | |
| `Tef_SenhaCodigoSupervisor` | Senha funções restritas | `1234` |
| `PosPrinter_EnviarImpressora` | `1` imprime; `0` só preview | `0` |

As demais opções da impressora (modelo, porta, colunas, etc.) são persistidas em **`ACBrLib.ini`** ao salvar na tela de configuração.

### `CliSiTef.ini`

Gerado automaticamente na pasta do executável se não existir (`TefConfigService.GarantirCliSiTefIni`). Ajuste pinpad e transações habilitadas conforme documentação Software Express.

---

## Arquitetura do código

```
FrmPdv
  ├── TefDemoService          # Cupom, Crt, admin, cache comprovante, eventos
  ├── DemoPosPrinterService   # Impressão e flag EnviarImpressora
  └── TefInteracaoUi          # Ponte para Lib.FormsAuxiliares

FrmConfiguracao
  ├── TefConfigService        # App.config + CliSiTef.ini
  └── PosPrinterConfigService # Singleton ACBrPosPrinter (x86, STA)

Helpers\AcbrNativeThread      # Marshaling: DLLs nativas só na thread STA da UI
Services\ComprovanteBuilder   # Vias 713/715, tags </corte_parcial>, ESC/POS
```

### Regras importantes para quem for estender o código

1. **Processo x86** — CliSiTef e ACBrLib PosPrinter são 32 bits.
2. **Uma instância** de `ACBrPosPrinter` por processo (`PosPrinterConfigService` singleton).
3. **Chamadas nativas na thread da UI** — use `AcbrNativeThread.Executar(...)`; não chame a lib de threads de background.
4. **QR Code na tela** — handlers em `FrmPdv` (`OnCallPanelQrCode` / `OnClosePanelQrCode`), alinhados ao demo Fiserv (`FrmTelaTesteVenda`).

---

## Impressão de comprovantes

- Montagem das vias a partir dos retornos SiTef **713** (cliente) e **715** (estabelecimento).
- Entre as vias: marcador interno convertido em `</corte_parcial>` na impressão; ao final, `</corte_total>`.
- No preview, o corte aparece como `[ CORTE PAPEL ]`.
- Tags ESC/POS ACBr (`</ce>`, `</linha_dupla>`, etc.) via `ComprovanteBuilder.ParaEscPos`.
- **Testar impressão** na configuração envia cupom de teste com corte total.
- Para simular sem hardware: configure a **porta** como arquivo (ex.: `comprovante_simulado.txt` na pasta do exe) ou use o driver RAW do Windows.

---

## QR Code (Pix / carteira digital)

| Configuração | Valor recomendado para QR na tela |
|--------------|-----------------------------------|
| `Tef_PinPadQrCode` | `0` |
| Lib.CliSitef | `{DevolveStringQRCode=1}` no fluxo CRT (quando QR não vai ao pinpad) |

Fluxo:

1. SiTef envia comando **50** → painel `pnlQr` visível, imagem em `lblQrCode` (campo **584**).
2. Comando **51** → painel oculto.
3. Posicionamento: centralizado sobre o **grid de pagamentos** (`CentralizarPainelQr`).

Para **Pix em homologação**, instale o módulo **CardSE** (portal Software Express — ver [Referências](#referências)).

---

## Arquivos gerados em runtime

| Pasta/arquivo | Conteúdo |
|---------------|----------|
| `TefRetorno\*.tef` | Dump dos retornos SiTef (layout compatível com NTK/PayGo) |
| `Logs\` | Log do demo e logs ACBrLib PosPrinter |
| `ACBrLib.ini` | Configuração persistida da impressora |
| `CliSiTef.ini` | Configuração CliSiTef / pinpad |
| `imp\` | Arquivos de impressão simulada (se configurado) |

---

## Homologação TEF (SiTef Demo)

1. Instale o **SiTef Demo** (`sitdemo.zip`) e o **CliSiTef simulado** — links na seção [Referências](#referências).
2. Configure IP, empresa e terminal no `App.config` conforme seu ambiente.
3. Para **Pix**, instale o módulo **CardSE** (versão indicada pela Software Express no portal do cliente).
4. Valide débito, crédito e carteira digital; confira os arquivos `.tef` em `TefRetorno\` para integração com seu ERP.

A homologação oficial e regras de produção seguem a documentação Software Express/Fiserv.

---

## Solução de problemas

| Sintoma | Verificação |
|---------|-------------|
| Aviso “processo 32 bits” | Recompile com `PlatformTarget=x86`. Não execute como Any CPU 64 bits. |
| `InicializarTef` diferente de 0 | SiTef rodando? IP/empresa/terminal corretos? DLLs TEF na pasta do exe? |
| Erro ao abrir configuração / impressora | `ACBrLib\x86\ACBrPosPrinter32.dll` presente? Versão compatível com o NuGet? |
| Comprovante não imprime | `PosPrinter_EnviarImpressora=1`? Impressora ativada na config? Porta correta (`RAW:...` ou arquivo)? |
| QR não aparece | `Tef_PinPadQrCode=0`? Transação carteira digital (122)? Módulo Pix/CardSE no SiTef? |
| `StackOverflow` em telas ACBr | Não criar múltiplas instâncias `ACBrPosPrinter`; usar sempre `PosPrinterConfigService`. |
| DLL TEF ausente / erro 8 | `CliSiTef32I.dll` e dependências na **mesma pasta** do `ACBr.CliSiTef.Demo.exe`? |

Consulte também `Logs\ACBrLibPosPrinter-*.log` e `Logs\PosPrinter.log` para detalhes da biblioteca nativa.

---

## Referências

### Software Express / Fiserv (homologação)

| Recurso | Download |
|---------|----------|
| SiTef Demo (`sitdemo.zip`) | https://portaldocliente.softwareexpress.com.br/distri/aplicativos/simulado/sitdemo.zip |
| CliSiTef simulado (`clisitefwin32_simulado.zip`) | https://portaldocliente.softwareexpress.com.br/distri/aplicativos/simulado/clisitefwin32_simulado.zip |
| Recarga celular (simulado) | https://portaldocliente.softwareexpress.com.br/distri/aplicativos/simulado/sitgwcel_simulado.zip |

Documentação CliSiTef (interface, carteiras digitais) e módulo **CardSE** para Pix: portal do cliente Software Express.

### Projeto ACBr

- Demo original Software Express: repositório Fiserv `App.CliSiTef_DLL` / `FrmTelaTesteVenda`
- **ACBrLib PosPrinter:** [Projeto ACBr](https://www.projetoacbr.com.br/) — pacote nativo e exemplos
- NuGet: [ACBrLib.PosPrinter](https://www.nuget.org/packages/ACBrLib.PosPrinter)

---

## Licenciamento e responsabilidade

- **CliSiTef / SiTef:** software e credenciais fornecidos pela Software Express/Fiserv conforme contrato de homologação.
- **ACBrLib:** siga a licença do Projeto ACBr para uso e redistribuição das DLLs nativas.
- Este demo é mantido pelo **Projeto ACBr** como referência de integração CliSiTef. Para uso em produção, realize a homologação oficial e adapte o código às regras da Software Express/Fiserv e ao seu negócio.
