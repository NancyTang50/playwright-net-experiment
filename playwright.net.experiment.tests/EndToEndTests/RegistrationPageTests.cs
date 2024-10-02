using Microsoft.Playwright;
using playwright.net.experiment.tests.Extensions;
using playwright.net.experiment.tests.Setups;

namespace playwright.net.experiment.tests.EndToEndTests;

[TestFixture]
internal class RegistrationPageTests : GlobalSetUp
{
    private IPage _registrationPage;

    [SetUp]
    public async Task SetupRegistrationPage()
    {
        await Page
            .GetByRole(AriaRole.Link, new() { Name = "Bestellen" })
            .ClickAsync()
            .ConfigureAwait(false);

        _registrationPage = await Page.Context.RunAndWaitForPageAsync(async () =>
        {
            await Page.GetByRole(AriaRole.Link, new() { Name = "Aanvragen bestelaccount" })
                .ClickAsync()
                .ConfigureAwait(false);
        });
    }

    [Test, Name(
        "Heeft registreren titel",
        "Als ik op de aanvragen bestelaccount pagina zit, wil ik dat er registreren titel in de html staat"
    )]
    public async Task RegistrationPageShouldHaveTitle()
    {
        await Expect(_registrationPage)
            .ToHaveTitleAsync("Registreren")
            .ConfigureAwait(false);
    }

    [Test, Name(
        "Geen lege formulier verzenden",
        "Als ik op de aanvragen bestelaccount pagina zit, wil ik geen lege formulier verzenden"
    )]
    public async Task CannotSubmitEmptyForm()
    {
        string expected = _registrationPage.Url;
    
        await _registrationPage.GetByRole(AriaRole.Button, new() {Name = "Verzenden" })
            .ClickAsync()
            .ConfigureAwait(false);
   
        await Expect(_registrationPage.GetByPlaceholder("99XX00")).ToBeFocusedAsync();
        await Expect(_registrationPage).ToHaveURLAsync(expected);
    }
}