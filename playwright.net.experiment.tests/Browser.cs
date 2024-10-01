using Microsoft.Playwright;

namespace playwright.net.experiment.tests
{
    internal class Browser
    {
        public static async Task<IBrowser> LaunchBrowserAsync(IPlaywright playwright, string browserType, bool isRunningHeadless)
        {
            return browserType.ToLower() switch
            {
                "chromium" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = isRunningHeadless }),
                "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = isRunningHeadless }),
                "webkit" => await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = isRunningHeadless, }),
                _ => throw new ArgumentException($"Unknown browser type: {browserType}")
            };
        }
    }
}
