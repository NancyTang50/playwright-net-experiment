using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using playwright.net.experiment.tests.Extensions;

namespace playwright.net.experiment.tests.EndToEndTests;

public class RegistrationPageTests : PageTest
{
    private IPage _registrationPage;

    [SetUp]
    public async Task Setup()
    {
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        await Page.GotoAsync("https://cito.nl/");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Bestellen" }).ClickAsync();

        _registrationPage = await Page.Context.RunAndWaitForPageAsync(async () =>
        {
            await Page.GetByRole(AriaRole.Link, new() { Name = "Aanvragen bestelaccount" }).ClickAsync();
        });
    }

    [Test, Name(
        "Heeft registreren titel",
        "Er wordt gekeken of de registreren titel heeft in de html"
    )]
    public async Task RegistrationPageShouldHaveTitle()
    {
        await Expect(_registrationPage).ToHaveTitleAsync("Registreren");
    }

    [TearDown]
    public async Task TearDown()
    {
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }
}