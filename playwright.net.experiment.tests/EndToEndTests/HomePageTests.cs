using Microsoft.Playwright;
using playwright.net.experiment.tests.Extensions;
using playwright.net.experiment.tests.Setups;

namespace playwright.net.experiment.tests.EndToEndTests;

[TestFixture]
internal class HomePageTests : GlobalSetUp
{
    [Test, Name(
        "De homepagina heeft een titel",
        "Als ik op de homepagina zit van Cito, verwacht ik de titel Cito: toetsen, examens, volgsystemen, certificeringen en trainingen te zien"
    )]
    public async Task HomePageShouldHaveTitle()
    {
        await Expect(Page)
            .ToHaveTitleAsync("Cito: toetsen, examens, volgsystemen, certificeringen en trainingen")
            .ConfigureAwait(false);
    }

    [Test, Name(
        "Kan de bestellen pagina openen",
        "Als ik op de homepagina zit van Cito, wil ik de bestellen pagina kunnen openen"
    )]
    public async Task CanOpenBestellenPage()
    {
        await Page
            .GetByRole(AriaRole.Link, new() { Name = "Bestellen"})
            .ClickAsync()
            .ConfigureAwait(false);

        await Expect(Page
            .GetByRole(AriaRole.Heading, new() { Name = "Productaanbod" }))
            .ToBeVisibleAsync();
    }

    [Test, Name(
        "Kan de registratie pagina openen", 
        "Als ik op de homepagina zit van Cito, wil ik de registratie pagina kunnen openen"
    )]
    public async Task CanOpenRegistratiePage()
    {
        IPage registrationPage;
        
        await Page
            .GetByRole(AriaRole.Link, new() { Name = "Bestellen" })
            .ClickAsync()
            .ConfigureAwait(false);

        registrationPage = await Page.Context.RunAndWaitForPageAsync(async () =>
        {
            await Page
                .GetByRole(AriaRole.Link, new() { Name = "Aanvragen bestelaccount" })
                .ClickAsync()
                .ConfigureAwait(false);
        });

        await Expect(registrationPage)
            .ToHaveTitleAsync("Registreren")
            .ConfigureAwait(false);
    }
}