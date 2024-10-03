# Playwright .NET demo project.
Deze testen zijn herschreven vanuit het [playwright-demo-project](https://github.com/jeroenhuinink/playwright-demo)

## Installatie
De onderstaande commando moet eerst uitgevoerd worden, omdat het mogelijk is dat de 2e commando anders niet werkt
`dotnet tool update --global PowerShell`

Vervolgens moet deze commando uitgevoerd worden om daadwerkelijk de browsers te installeren
`pwsh bin/Debug/net8.0/playwright.ps1 install`

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

<br>
LET OP: De dockerfile werkt nog niet
