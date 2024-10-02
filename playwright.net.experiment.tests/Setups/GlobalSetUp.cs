using Microsoft.Playwright.NUnit;

namespace playwright.net.experiment.tests.Setups;

[SetUpFixture]
public class GlobalSetUp : PageTest
{
    [SetUp]
    public async Task SetUp()
    {
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        await Page
            .GotoAsync("https://cito.nl/")
            .ConfigureAwait(false);
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
        })
        .ConfigureAwait(false);
    }
}
