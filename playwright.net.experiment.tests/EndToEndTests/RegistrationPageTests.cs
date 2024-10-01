using Microsoft.Playwright;

namespace playwright.net.experiment.tests.EndToEndTests;

[TestFixture("chromium", false)]
[TestFixture("firefox", false)]
[TestFixture("webkit", false)]
public class RegistrationPageTests
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _browserContext;
    private IPage _page;
    private IPage _registrationPage;

    private string _browserType;
    private bool _isRunningHeadless;

    public RegistrationPageTests(string browserType, bool isRunningHeadless)
    {
        _browserType = browserType;
        _isRunningHeadless = isRunningHeadless;
    }

    [SetUp]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await Browser.LaunchBrowserAsync(_playwright, _browserType, _isRunningHeadless);
        _browserContext = await _browser.NewContextAsync();
        _page = await _browserContext.NewPageAsync();

        await _page.GotoAsync("https://cito.nl/");
        await _page.GetByRole(AriaRole.Link, new() { Name = "Bestellen" }).ClickAsync();

        _registrationPage = await _page.Context.RunAndWaitForPageAsync(async () =>
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Aanvragen bestelaccount" }).ClickAsync();
        });
    }

    [Test]
    public async Task RegistrationPageShouldHaveTitle()
    {
        var title = await _registrationPage.TitleAsync();
        Assert.That(title, Is.EqualTo("Registreren"));
    }

    [TearDown]
    public async Task TearDown()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}