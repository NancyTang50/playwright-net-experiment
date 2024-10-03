# Playwright .NET demo project.
Deze testen zijn herschreven vanuit het [playwright-demo-project](https://github.com/jeroenhuinink/playwright-demo)
LET OP: De dockerfile werkt nog niet.
## Installatie
De onderstaande commando moet eerst uitgevoerd worden, omdat het mogelijk is dat de 2e commando anders niet werkt
```powershell
dotnet tool update --global PowerShell
```

Vervolgens moet deze commando uitgevoerd worden om daadwerkelijk de browsers te installeren

```powershell
pwsh bin/Debug/net8.0/playwright.ps1 install
```

## Test commando's
Deze onderstaande test commando's zijn beschikbaar vanuit Playwright .NET

Deze commando voert alle testen uit:
```powershell
dotnet test
```

Deze powershell commando voert elke test uit op de browser:

```powershell
$env:HEADED="1"
dotnet test
```

Deze commando voert de testen uit in een specifieke browser, in dit geval webkit.
```powershell
$env:BROWSER="webkit"
dotnet test
```

Voor meer informatie zie de officiële documentatie van [Playwright](https://playwright.dev/dotnet/docs/running-tests)

## Traceviewer commando
Als er een test faalt worden er screenshots van gemaakt en omgezet traceviewer. 
Deze commando moet worden uitgevoerd om in de traceviewer van een specifieke test te komen.

Hieronder een voorbeeld:
```powershell
pwsh bin/Debug/net8.0/playwright.ps1 show-trace bin/Debug/net8.0/playwright-traces/playwright.net.experiment.tests.EndToEndTests.RegistrationPageTests.RegistrationPageShouldHaveTitle.zip
```
