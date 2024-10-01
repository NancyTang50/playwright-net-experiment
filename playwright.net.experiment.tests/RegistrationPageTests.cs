using Microsoft.Playwright;
using playwright.net.experiment.tests.Extensions;

namespace playwright.net.experiment.tests;

public class Tests
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _browserContext;
    private IPage _page;
    private IPage _registrationPage;

    [SetUp]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions { 
                Headless = false 
            }
        );

        _browserContext = await _browser.NewContextAsync();
        _page = await _browserContext.NewPageAsync();
        await _page.GotoAsync("https://cito.nl/");
        await _page.GetByRole(AriaRole.Link, new() { Name = "Bestellen" }).ClickAsync();

        _registrationPage = await _page.Context.RunAndWaitForPageAsync(async () =>
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Aanvragen bestelaccount" }).ClickAsync();             
        });
    }

    [Test, Name(
        "Heeft registreren titel", 
        "Er wordt gekeken of de registreren titel heeft in de html"
    )]
    public async Task RegistrationPageShouldHaveTitle()
    {
        var title = await _registrationPage.TitleAsync();
        Assert.That(title, Is.EqualTo("Registreren"));
    }

    [TearDown]
    public async Task TearDown()
    {
        await _browserContext.CloseAsync();
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}